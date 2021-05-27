using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        var pos = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(pos);
    }
}
