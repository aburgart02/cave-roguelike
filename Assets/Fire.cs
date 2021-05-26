using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Transform Fireposition;
    public GameObject arrow;
    public int maxBullets = 1;
    public List<GameObject> bullets = new List<GameObject>();
    [SerializeField] private AudioSource Shot;

    public void Shoot()
    {
        bullets.Add(Instantiate(arrow, Fireposition.position, Fireposition.rotation));
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
            Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            Debug.Log(worldPosition);
            if (!(worldPosition[0] <= 0.2 && worldPosition[0] >= -1.4 && worldPosition[1]>=-0.7 && worldPosition[1]<=-0.3))
            {
                Shoot();
                Shot.Play();
            }
        }
    }
}
