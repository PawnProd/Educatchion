using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public GameObject student;

    public int speed;
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, student.transform.position, speed * Time.deltaTime);
        print(student.transform.position);
        print(transform.position);
        if (transform.position == student.transform.position)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == student)
        {
            collision.gameObject.SendMessage("getHit", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
