using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 40f;
    public Rigidbody2D rb;
    public GameObject ShootAnimation;
    void Start()
    {
        if (rb != null)
            rb.velocity = transform.right * speed;
        if (ShootAnimation != null)
            Instantiate(ShootAnimation, gameObject.transform.position, gameObject.transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.GetComponent<Health>() != null)
        {
            var enemyHealth = hitInfo.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}