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

    public void TakeDamage(float damage)
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
            if (gameObject.CompareTag("Boss"))
            {
                Instantiate(item, spawnPosition.position, Quaternion.identity);
                Die();
            }
            else
            {
                var value = Random.Range(0, 10);
                if (value < 5)
                {
                    if (item != null)
                        Instantiate(item, spawnPosition.position, Quaternion.identity);
                }
                Die();
            }
        }
    }

    public void HealPlayer(float heal)
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
