using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHealth : MonoBehaviour
{
    public int maxHealth = 1;
    public int currentHealth;
    public Vector3 startPosition;
    public MoneyManager money;
    private int value;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        startPosition = transform.position;
        money = FindObjectOfType<MoneyManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            //Destroy(gameObject);
            value = Random.Range(100, 1000);
            money.subtractMoney(value);
            transform.position = startPosition;
            
        }

    }

}
