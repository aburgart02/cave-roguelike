using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy") || hitInfo.gameObject.CompareTag("Player"))
        {
            var enemyHealth = hitInfo.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}