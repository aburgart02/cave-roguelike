using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    public Transform spawnPosition;

    public void Start()
    {
        spawnPosition = GameObject.FindGameObjectWithTag("DropPosition")?.transform;
    }

    public void SpawnDroppedItem()
    {
        Instantiate(item, spawnPosition.position, Quaternion.identity);
    }
}
