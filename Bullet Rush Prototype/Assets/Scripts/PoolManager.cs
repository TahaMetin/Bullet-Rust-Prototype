using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }
    [SerializeField] GameObject enemySceneContainer;
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;
    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)    // create enemys and add them into pool
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                switch (pool.tag)
                {
                    case "SimpleEnemy":
                    case "BigEnemy":
                        obj.transform.parent = enemySceneContainer.transform; // make enemys child of enemy container in scene
                        break;
                    case "Bullet":
                        break;
                    default:
                        break;
                }
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector3 position)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            throw new System.Exception("Pool with tag  '" + tag + "' doesn't exist.");
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}
