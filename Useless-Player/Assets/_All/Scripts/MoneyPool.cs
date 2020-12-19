using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class MoneyPool : MonoBehaviour
{
    #region Singleton
    public static MoneyPool Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public GameObject moneyPrefab;
    public int spawnCount;
    public List<GameObject> moneyCountList;
    public List<Transform> spawnPoints = new List<Transform>();

    void Start()
    {
        GetSpawnPoints();
        //CreatePool();
        
    }

    public void CreatePool(GameObject prefab, int poolSize)
    {
        int poolKey = prefab.GetInstanceID();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject money = Instantiate(prefab) as GameObject;
            money.SetActive(true);
            money.transform.position = RandomSpawnpoint();
            money.transform.parent = this.transform;
            moneyCountList.Add(money);
        }
    }

    public Vector3 RandomSpawnpoint()
    {
        int randomSP = Random.Range(0, (spawnPoints.Count));
        Vector3 randomSpawnPoint = spawnPoints[randomSP].transform.position;
        return randomSpawnPoint;
    }

    void GetSpawnPoints()
    {
        //List using standard library and look through nested children
        Transform[] spList = transform.GetComponentsInChildren<Transform>();
        for (int i = 0; i < spList.Length; i++)
        {
            if (spList[i].tag == "SpawnPoints")
            {
                //add tagged gameobject to the list
                spawnPoints.Add(spList[i]);
            }
        }
    }



    //public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    //{
    //    //If poolDictionary does not contain the tag assigned on the inspector, then debug
    //    if (!poolDictionary.ContainsKey(tag))
    //    {
    //        Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
    //        return null;
    //    }

    //    //Remove prefab from the queue and set it active on the scene
    //    GameObject objectToSpawn = poolDictionary[tag].Dequeue();

    //    if (!objectToSpawn.activeInHierarchy)
    //    {
    //        objectToSpawn.SetActive(true);
    //        objectToSpawn.transform.position = position;
    //        objectToSpawn.transform.rotation = rotation;
    //    }

    //    //After using the prefab, put it back on the queue
    //    poolDictionary[tag].Enqueue(objectToSpawn);

    //    return objectToSpawn;

    //    //Reference to the IPooler script, enable prefab (money) to be picked up and add value on fixedupdate
    //    //IPooler pooledObject = objectToSpawn.GetComponent<IPooler>();
    //    //if (pooledObject != null)
    //    //{
    //    //    pooledObject.OnOjectSpawn();
    //    //}
    //}
}
