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

        // Другой вариант. Тогда будут промежуточные повороты и будет работать джойстик.
        //var v = (int)Input.GetAxis("Vertical"); // Возвращают от -1 до 1
        //var h = (int)Input.GetAxis("Horizontal");
        //var movementVector = new Vector2(h, v);

        // В Rigidbody2D можно выбрать Body Type Kinematic, чтобы не действовала гравитация и другие силы.
        // В этом случае не будут автоматически происходить collision и их придется обрабатывать вручную

        rigidBodyComponent.velocity = movementVector * acceleration;
        //if (movementVector.magnitude > Mathf.Epsilon)
        //{
        //    var angle = new Vector3(0, 0, movementVector.GetAngle());
        //    transform.rotation = Quaternion.Euler(angle);
        //}

        // Другой вариант, без Rigidbody2D.
        // Указываются абсолютные координаты, а не смещение.
        // Перемещение происходит мгновенно, в отличие от скорости.
        // transform.position = new Vector3(...)
    }
}

public static class VecExt
{

    public static float GetAngle(this Vector2 vector)
    {
        return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
    }
}
