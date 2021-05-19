using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeriodShoot : MonoBehaviour
{
    public int Period;
    public Transform firePoint;
    public GameObject bullet;
    [SerializeField] private AudioSource Shot;

    void Update()
    {
        if (Random.Range(0, Period * 60) < 1)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        Shot.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
