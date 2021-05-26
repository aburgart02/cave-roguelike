using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeriodShoot : MonoBehaviour
{
    public int Period;
    public Transform firePoint;
    public GameObject bullet;
    [SerializeField] public AudioSource Shot;

    void Update()
    {
        if (Random.Range(0, Period * 60) < 1)
        {
            Shoot();
        }

    }

    public void Shoot()
    {
        if (Shot!=null)
            Shot.Play();
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
