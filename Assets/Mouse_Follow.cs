using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Follow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
