using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentScript : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer spriteRenderer;
    private bool isListening = true;
    public float timeBeforeCanStopListening = 3.0f;
    public float currentTime;
    public GameObject classroom;
    public float notListeningRandom;
    public float switchRate = 75.0f;
    public float actionNumber = 2.0f;
    public float actionChoice;
    public GameObject studentBag = null;
    public backPackScript studentBagScript = null;
    public bool haveBag = false;
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = timeBeforeCanStopListening;
        if (studentBag !=null)
        {
        studentBagScript = studentBag.GetComponent<backPackScript>();
        }
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
        actionChoice = Random.Range(0.0f,(actionNumber-1));
        actionChoice = Mathf.Round(actionChoice);
        //print(actionChoice);
        if(actionChoice == 0 && haveBag == true)
        {
            studentBagScript.toggleBackpack();
        }
        else if(actionChoice == 1 )
        {

        }
        isListening = false;
        classroom.GetComponent<ClassroomScript>().studentNotListening++;
        spriteRenderer.color = Color.red;


    }
    void getHit()
    {   
        if(!isListening)
        {
            if(actionChoice == 0 && haveBag == true)
            {
                studentBagScript.toggleBackpack();
            }
        classroom.GetComponent<ClassroomScript>().studentNotListening--;
        spriteRenderer.color = Color.green;
        isListening = true;
        }
    }
}
