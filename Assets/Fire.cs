using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform Fireposition;
    public GameObject bullet;
    public int maxBullets = 1;
    public List<GameObject> bullets = new List<GameObject>();
    [SerializeField] private AudioSource Shot;

    public void Shoot()
    {
        if (bullets.Count < maxBullets)
            bullets.Add(Instantiate(bullet, Fireposition.position, Fireposition.rotation));
    }

    void Update()
    {
        foreach (var bullet in bullets.ToArray())
        {
            if (bullet == null)
                bullets.Remove(bullet);
        }
        if (Input.GetButtonDown("Fire1") && bullets.Count < maxBullets)
        {
            Shoot();
            Shot.Play();
        }
    }
}
