using UnityEditor;
using UnityEngine;

public class SmallMoneyPickup : PoolObject
{
    
    private int value;
    public MoneyManager money;
    PoolManager pool;
    MSpawner mspawner;

    public void Start()
    {
        pool = PoolManager.Instance;
        mspawner = FindObjectOfType<MSpawner>();
        money = FindObjectOfType<MoneyManager>();
    }

    public void OnTriggerEnter(Collider player)
    {
        
        if (player.gameObject.tag == "Player" && mspawner.prefab != null)
        {
            //int get = mspawner.prefab.GetInstanceID();
            GameObject obj = gameObject;
            value = Random.Range(100, 1000);
            money.addMoney(value);
            for (int i = 0; i < mspawner.prefabCount; i++)
            {
                if (obj.activeSelf == true)
                {
                    obj.SetActive(false);
                    //pool.ReuseObject(mspawner.prefab, pool.RandomSpawnpoint(), Quaternion.identity);
                    obj.SetActive(true);
                    obj.transform.position = pool.RandomSpawnpoint();
                    break;
                }
            }
                
            
            //for (int i = 0; i < mspawner.prefabCount; i++)
            //{

            //    break;
            //}

        }
        
    }

    //public void OnTriggerEnter(Collider player)
    //{
    //    for (int i = 0; i < moneyPooler.moneyCountList.Count; i++)
    //    {
    //        if (player.gameObject.tag == "Player" && moneyPooler.moneyCountList[i].activeInHierarchy == true)
    //        {
    //            GameObject prefab = moneyPooler.moneyCountList[i];
    //            prefab.SetActive(false);
    //            value = Random.Range(100, 10000);
    //            money.addMoney(value);
    //            prefab.SetActive(true);
    //            prefab.transform.position = moneyPooler.RandomSpawnpoint();
    //            break;
    //        }
    //    }
    //}


}
