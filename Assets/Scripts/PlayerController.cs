using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public PlayerMovement pM;

    public DetectionBehavior detect;

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
        else if(Input.GetAxis("Vertical") > 0) // UP
        {
            pM.MoveUp();
        }
        else if(Input.GetAxis("Vertical") < 0) // DOWN
        {
            pM.MoveDown();
        }
        
        if(Input.GetMouseButtonDown(0) && detect.student != null) // HIT a student
        {
            detect.student.SendMessage("getHit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
