using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletMovement : MonoBehaviour, IPoolable
{
    public type jenis;
    public enum type
    {
        player,enemy
    }
    public int damage;
    public Vector2 direction;
    private int speed;
    private void Start()
    {
        speed = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (jenis.Equals(type.enemy))
        {
            Debug.Log(transform.position);
        }
        transform.Translate(direction * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyBehaviour>() != null && jenis.Equals(type.player))
        {
            speed = 0;
            GetComponent<Animator>().SetTrigger("Hit");
            StartCoroutine(destroy());
            collision.GetComponent<EnemyBehaviour>().takeDamage(damage);
        }
        if(collision.tag =="Player" && jenis.Equals(type.enemy))
        {
            speed = 0;
            GetComponent<Animator>().SetTrigger("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    IEnumerator destroy()
    {

        yield return new WaitForSecondsRealtime(0.25f);
        gameObject.SetActive(false);
    }
    public void onRespawn()
    {
        speed = 1; ;
    }
}
