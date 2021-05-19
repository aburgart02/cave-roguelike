using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Key1"))
        {
            Destroy(gameObject);
            Destroy(hitInfo.gameObject);
        }
    }
}
