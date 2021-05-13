using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public int rate = 5;
    public GameObject entity;
    public Transform position;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, rate * 60) < 1)
            Instantiate(entity, position.position, position.rotation);
    }
}
