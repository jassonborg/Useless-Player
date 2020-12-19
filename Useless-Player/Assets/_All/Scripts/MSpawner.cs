using System.Collections.Generic;
using UnityEngine;

public class MSpawner : MonoBehaviour
{
    public static MSpawner Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject prefab;
    public int prefabCount;
    PoolManager pool;

    void Start()
    {
        pool = PoolManager.Instance;
        pool.GetSpawnPoints();
        pool.CreatePool(prefab, prefabCount);
        for (int i = 0; i < prefabCount; i++)
        {
            pool.ReuseObject(prefab, pool.RandomSpawnpoint(), Quaternion.identity);
        }
    }

}
