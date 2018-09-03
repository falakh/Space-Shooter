using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    public float jeda;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(shoot());
        }
	}
    IEnumerator shoot()
    {
        while (Input.GetKey(KeyCode.J))
        {
            ObjectPooling._objectPool.summon(bullet.tag, transform.position, bullet.transform.rotation);
            yield return new WaitForSecondsRealtime(jeda);
        }
        yield return null;
    }
}
