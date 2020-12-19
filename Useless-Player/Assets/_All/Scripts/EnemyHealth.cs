using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public Slider hpBar;
    public GameObject hpBarUI;
    public Transform cam;

    void Start()
    {
        currentHealth = maxHealth;
        hpBar.value = CalculateHealth();
    }

    void Update()
    {
        hpBar.value = CalculateHealth();

        if(currentHealth < maxHealth)
        {
            hpBarUI.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
