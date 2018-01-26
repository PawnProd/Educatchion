using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerMovement pM;

    private void Start()
    {
        pM = GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        
        if(Input.GetAxis("Horizontal") > 0) // RIGHT
        {
            pM.MoveRight();
        }
        else if(Input.GetAxis("Horizontal") < 0) // LEFT
        {
            pM.MoveLeft();
        }
        else if(Input.GetAxis("Vertical") > 0)
        {
            pM.MoveUp();
        }
        else if(Input.GetAxis("Vertical") < 0)
        {
            pM.MoveDown();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Student" && Input.GetMouseButtonDown(0))
        {
            print("BAFFE !");
        }
    }
}
