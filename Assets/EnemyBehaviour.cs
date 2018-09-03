using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour ,IPoolable{
    private int currentHealth;
    public EnemyData enemyData;
  
    // Use this for initialization
    private void Start()
    {
        StartCoroutine(shoot());
    }
    public void onRespawn()
    {
        setData();
        StartCoroutine(shoot());
    }
    public void setData()
    {
        currentHealth = enemyData.health;
        GetComponent<SpriteRenderer>().sprite = enemyData.enemySprite;
    }
    // Update is called once per frame
    void Update () {
        transform.Translate(Vector2.down *Time.deltaTime);
	}
        
    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(enemyData.shootRate);
            ObjectPooling._objectPool.summon("Enemy Bullet", transform.position, Quaternion.identity);
        }
    }
  
    public void takeDamage(int value)
    {
        currentHealth -= value;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
