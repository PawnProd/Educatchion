using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentScript : MonoBehaviour {

    // Use this for initialization
    private SpriteRenderer spriteRenderer;
    public bool isListening = true;
    public float timeBeforeCanStopListening = 3.0f;
    public float currentTime;
    public GameObject classroom;
    public GameObject blood;
    public float notListeningRandom;
    public float switchRate = 75.0f;
    private float actionNumber = 3.0f;
    public float actionChoice;
    public GameObject studentBag = null;
    public backPackScript studentBagScript = null;
    public bool haveBag = false;
    public GameObject[] studentToSpeak ;
    public int numberOfStudentToSpeak;
    public GameObject studentSpeakingWith;
    public Animator animator;
    private bool speakingToSomeone = false;
    void Start()
    {
        //Fetch the SpriteRenderer from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTime = timeBeforeCanStopListening;
        if (studentBag !=null)
        {
        studentBagScript = studentBag.GetComponent<backPackScript>();
        }
        animator = GetComponent<Animator>();
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

        if( blood.activeSelf && blood.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Blood"))
        {
            blood.GetComponent<Animator>().SetBool("isBlood", false);
            blood.SetActive(false);  
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
        print(actionChoice);
        //print(actionChoice);
        if(actionChoice == 0 && haveBag == true)
        {
            studentBagScript.toggleBackpack();
        }
        else if(actionChoice == 1 )
        {

        }
        else if (actionChoice == 2)
        {
            numberOfStudentToSpeak = studentToSpeak.Length;
            studentSpeakingWith = studentToSpeak[Random.Range(0, studentToSpeak.Length -1)];
            
            studentSpeakingWith.GetComponent<StudentScript>().SendMessage("youreTalkingToMe",gameObject, SendMessageOptions.DontRequireReceiver);
            speakingToSomeone = true;
        }
        isListening = false;
        classroom.GetComponent<ClassroomScript>().studentNotListening++;
        animator.SetBool("isSleep", true);


    }
    void getHit()
    {   
        if(!isListening)
        {
            if(actionChoice == 0 && haveBag == true)
            {
                studentBagScript.toggleBackpack();
            }else if(speakingToSomeone == true)
            {
                studentSpeakingWith.SendMessage("getHit", SendMessageOptions.DontRequireReceiver);
            }
            blood.SetActive(true);
            blood.GetComponent<Animator>().SetBool("isBlood", true);
            classroom.GetComponent<ClassroomScript>().studentNotListening--;
            animator.SetBool("isSleep", false);
            isListening = true;
        }
    }
    void youreTalkingToMe(GameObject studentTalkingToMe)
    {
        isListening = false;
        classroom.GetComponent<ClassroomScript>().studentNotListening++;
        animator.SetBool("isSleep", true);
        studentSpeakingWith = studentTalkingToMe;
    }
}
