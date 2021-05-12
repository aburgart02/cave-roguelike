using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public HealthBar healthBar;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth();
        }
        
        if (health <= 0)
        {
            if (!gameObject.CompareTag("Player"))
            {
                Die();
            }
        }

    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
