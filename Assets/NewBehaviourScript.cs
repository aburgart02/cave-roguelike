using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float acceleration = 15;
    private Rigidbody2D rigidBodyComponent;

    private void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var w = Input.GetKey(KeyCode.W) ? 1 : 0;
        var s = Input.GetKey(KeyCode.S) ? -1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 1 : 0;
        var d = Input.GetKey(KeyCode.D) ? -1 : 0;
        var movementVector = new Vector2(-(a + d), w + s);
        rigidBodyComponent.velocity = movementVector * acceleration;
    }
}

public static class VecExt
{

    public static float GetAngle(this Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
}
