using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    public HealthBar healthBar;
    public GameObject DeathAnimation;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (healthBar != null)
        {
            healthBar.SetHealth();
        }
        
        if (health <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
            }
            else
                Die();
        }

    }

    public void Die()
    {
        Instantiate(DeathAnimation, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
