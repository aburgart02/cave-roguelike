using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    public GameObject door;
    public bool isClosing;
    public Transform closingPosition;
    [SerializeField] public string keyTag = "GreenKey";
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(keyTag))
        {
            isClosing = true;
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (isClosing)
            door.transform.position = Vector3.Lerp(door.transform.position, closingPosition.transform.position,  Time.deltaTime / 5);
    }


}
