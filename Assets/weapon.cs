using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public int maxBullets = 1;
    private List<GameObject> bullets = new List<GameObject>();
    void Update()
    {
        if (Input.GetButton("Fire1") && bullets.Count < maxBullets)
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        bullets.Add(Instantiate(bullet, firePoint.position, firePoint.rotation));
    }
}
