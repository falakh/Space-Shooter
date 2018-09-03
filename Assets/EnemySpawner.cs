using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public int interval;
    public float maxPos, minPos;
    public EnemyData[] data;

	// Use this for initialization
	void Start () {
        StartCoroutine(summon());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator summon()
    {
        while (true)
        {
            Vector3 pos = new Vector2(Random.Range(minPos, maxPos), transform.position.y);
           GameObject summon = ObjectPooling._objectPool.summon("Enemy", pos, Quaternion.identity);
            summon.GetComponent<EnemyBehaviour>().enemyData = data[Random.Range(0, data.Length)];
            summon.GetComponent<EnemyBehaviour>().setData();
            yield return new WaitForSecondsRealtime(interval);
        }
       
    }
}
