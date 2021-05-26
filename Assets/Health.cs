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
    public GameObject item;
    public Transform spawnPosition;

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
            {
                var value = Random.Range(0,10);
                if (value < 5)
                {
                    Instantiate(item, spawnPosition.position, Quaternion.identity);
                }
                Die();
            }
        }
    }

    public void HealPlayer(int heal)
    {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        if (healthBar != null)
        {
            healthBar.SetHealth();
        }
    }

    public void Die()
    {
        if (DeathAnimation != null)
            Instantiate(DeathAnimation, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
