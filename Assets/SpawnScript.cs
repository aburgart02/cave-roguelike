using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public int rate = 5;
    public int maxEntities = 3;
    public float distance = 5;
    private List<GameObject> entities = new List<GameObject>();
    public GameObject entity;
    public Transform position;

    // Update is called once per frame
    void Update()
    {
        foreach (var entity in entities.ToArray())
            if (entity == null)
                entities.Remove(entity);
        if (Random.Range(0, rate * 60) < 1 && entities.Count < maxEntities && Vector3.Distance(gameObject.transform.position, GameObject.FindGameObjectWithTag("DropPosition").transform.position) < distance)
            entities.Add(Instantiate(entity, position.position, position.rotation));
    }
}
