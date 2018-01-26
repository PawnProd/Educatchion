using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;


    public void MoveLeft()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        Move();
    }

    public void MoveRight()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        Move();
    }

    public void MoveUp()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -90, transform.localEulerAngles.z);
        Move();
    }

    public void MoveDown()
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
