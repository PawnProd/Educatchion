using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentScript : MonoBehaviour {

    // Use this for initialization
    SpriteRenderer spriteRenderer;
    private bool isListening = true;
    public float timeBeforeCanStopListening = 3.0f;
    public float currentTime;
    public GameObject classroom;
    public float notListeningRandom;
    public float switchRate = 75.0f;
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = timeBeforeCanStopListening;
        //Set the GameObject's Color quickly to a set Color (blue)
        //spriteRenderer.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(isListening)
        {
            stopListening();
        }
    }

    void stopListening()
    {
        if(currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
        }else
        {
            currentTime = timeBeforeCanStopListening;
            if(classroom.GetComponent<ClassroomScript>().studentNotListening < classroom.GetComponent<ClassroomScript>().maxStudentNotListening)
            {
                notListeningRandom = Random.value*100;
                if(notListeningRandom >= switchRate)
                {
                chooseAction();
                }
            }
        }

    }
    void chooseAction()
    {
        isListening = false;
        classroom.GetComponent<ClassroomScript>().studentNotListening++;
        spriteRenderer.color = Color.red;


    }
    void getHit()
    {   
        if(!isListening)
        {
        classroom.GetComponent<ClassroomScript>().studentNotListening--;
        spriteRenderer.color = Color.green;
        isListening = true;
        }
    }
}
