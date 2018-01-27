using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 1.0f;


    public void MoveLeft()
    {
        transform.Translate(Vector3.zero);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 90, transform.localEulerAngles.z);
        Move();
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.zero);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, -90, transform.localEulerAngles.z);
        Move();
    }

    public void MoveUp()
    {
        transform.Translate(Vector3.zero);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
        Move();
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.zero);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, 0, transform.localEulerAngles.z);
        Move();
    }

    public void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
