using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {
    [System.Serializable]
   public  class Pool
    {
        public string tag;
        public GameObject prefab;
        public int jumlah;
    }
    //singgleton
    public static ObjectPooling _objectPool;
    public Dictionary<string, Queue<GameObject>> poolsData;
    public List<Pool> pools;
    private void Awake()
    {
        _objectPool = this;
        poolsData = new Dictionary<string, Queue<GameObject>>();
        for (int i = 0; i < pools.Count; i++)
        {
            string key = pools[i].tag;
            poolsData[key] = new Queue<GameObject>();
            for (int j = 0; j < pools[i].jumlah; j++)
            {
                GameObject obj = Instantiate(pools[i].prefab);
                poolsData[key].Enqueue(obj);
                obj.SetActive(false);
            }
        }
    }
	
    public GameObject summon(string tag,Vector3 posisi,Quaternion rotasi)
    {
        if (!poolsData.ContainsKey(tag))
        {
            Debug.LogWarning("Tag Not Found " + tag);
            return null;
        }
        var result = poolsData[tag].Dequeue();
        result.transform.position=(posisi);
        result.SetActive(true);
        result.transform.rotation = rotasi;
        poolsData[tag].Enqueue(result);
        var poolable = result.GetComponent<IPoolable>();
      if ( poolable!= null)
        {
            poolable.onRespawn();
        }
        return result;
    }

}
