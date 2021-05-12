using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform Fireposition;
    public GameObject arrow;

    public void Shoot()
    {
        Instantiate(arrow, Fireposition.position, Fireposition.rotation);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
}
