using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionBehavior : MonoBehaviour {

    public StudentScript student = null;
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Student")
        {
            student = other.gameObject.GetComponent<StudentScript>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        student = null;
    }
}
