using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDetection : MonoBehaviour
{
    public GameObject door;
    public bool opening;
    public Transform openingPosition;
    public Transform closingPosition;
    public bool canBeOpenedByKey;
    [SerializeField] public string keyTag = "GreenKey";
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(keyTag))
        {
            opening = true;
            canBeOpenedByKey = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canBeOpenedByKey && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Idi na hui");
            opening = !opening;
        }
    }

    void Update()
    {
        if (opening)
            door.transform.position = Vector3.Lerp(door.transform.position, openingPosition.transform.position,  Time.deltaTime / 4);
        else
            door.transform.position = Vector3.Lerp(door.transform.position, closingPosition.transform.position, Time.deltaTime / 4);
    }


}
