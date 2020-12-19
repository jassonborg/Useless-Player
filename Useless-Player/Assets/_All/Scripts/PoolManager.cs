using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PoolManager : MonoBehaviour
{
	Dictionary<int, Queue<ObjectInstance>> poolDictionary = new Dictionary<int, Queue<ObjectInstance>>();
	static PoolManager _instance;
	public List<Transform> spawnPoints = new List<Transform>();
	public static PoolManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = FindObjectOfType<PoolManager>();
			}
			return _instance;
		}
	}
	public void CreatePool(GameObject prefab, int poolSize)
	{
		int poolKey = prefab.GetInstanceID();
		if (!poolDictionary.ContainsKey(poolKey))
		{
			poolDictionary.Add(poolKey, new Queue<ObjectInstance>());
			GameObject poolHolder = new GameObject(prefab.name + " pool");
			poolHolder.transform.parent = transform;
			
			for (int i = 0; i < poolSize; i++)
			{
				ObjectInstance newObject = new ObjectInstance(Instantiate(prefab) as GameObject);
				poolDictionary[poolKey].Enqueue(newObject);
				newObject.SetParent(poolHolder.transform);
			}
		}
	}
	public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation)
	{
		int poolKey = prefab.GetInstanceID();
		if (poolDictionary.ContainsKey(poolKey))
		{
			ObjectInstance objectToReuse = poolDictionary[poolKey].Dequeue();
			poolDictionary[poolKey].Enqueue(objectToReuse);
			objectToReuse.Reuse(position, rotation);
		}
	}
	public class ObjectInstance
	{
		GameObject gameObject;
		Transform transform;
		bool hasPoolObjectComponent;
		PoolObject poolObjectScript;
		public ObjectInstance(GameObject objectInstance)
		{
			gameObject = objectInstance;
			transform = gameObject.transform;
			gameObject.SetActive(false);
			if (gameObject.GetComponent<PoolObject>())
			{
				hasPoolObjectComponent = true;
				poolObjectScript = gameObject.GetComponent<PoolObject>();
			}
		}

		public void Reuse(Vector3 position, Quaternion rotation)
		{
			if (hasPoolObjectComponent)
			{
				poolObjectScript.OnObjectReuse();
			}

			gameObject.SetActive(true);
			transform.position = position;
			transform.rotation = rotation;

			if (hasPoolObjectComponent)
			{
				poolObjectScript.OnObjectReuse();
			}
		}

		public void SetParent(Transform parent)
		{
			transform.parent = parent;
		}
	}

	//public method for getting a random spawnpoint
	public Vector3 RandomSpawnpoint()
	{
		int randomSP = Random.Range(0, (spawnPoints.Count));
		Vector3 randomSpawnPoint = spawnPoints[randomSP].transform.position;
		return randomSpawnPoint;
	}

	public void GetSpawnPoints()
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

}