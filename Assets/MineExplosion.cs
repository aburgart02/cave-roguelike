using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour
{
    public int damage = 10;
    public GameObject ShootAnimation;
    public Transform explosionPosition;
    [SerializeField] private AudioClip Sound;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Enemy") || hitInfo.gameObject.CompareTag("Player"))
        {
            if (Sound != null)
                AudioSource.PlayClipAtPoint(Sound, gameObject.transform.position);
            Instantiate(ShootAnimation, explosionPosition.position, Quaternion.identity);
            var enemyHealth = hitInfo.GetComponent<Health>();
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
