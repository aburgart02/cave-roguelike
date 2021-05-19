using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public int damage = 10;
    public GameObject ShootAnimation;
    [SerializeField] private AudioSource Explosion;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy") || hitInfo.gameObject.CompareTag("Player"))
        {
            var explosionPosition = GameObject.FindGameObjectWithTag("ExplosionPosition").transform;
            Instantiate(ShootAnimation, explosionPosition.position, Quaternion.identity);
            var enemyHealth = hitInfo.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
            Explosion.Play();
        }
        Destroy(gameObject);
    }
}
