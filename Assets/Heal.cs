using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            var playerHealth = hitInfo.GetComponent<Health>();
            playerHealth.HealPlayer(30);
        }
        Destroy(gameObject);
    }
}
