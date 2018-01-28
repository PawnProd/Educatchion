using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentScript : MonoBehaviour {

    // Use this for initialization
    public AudioClip[] listAudio;
    public AudioSource sourceBlablaStudent;
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
    public GameObject studentToSpeak ;
    public Animator animator;
    public bool principalTalker = false ;
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
        if(LevelManager.levelState != LevelState.paused)
        {
            if (isListening)
            {
                stopListening();
            }

            if (blood.activeSelf && blood.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Blood"))
            {
                blood.GetComponent<Animator>().SetBool("isBlood", false);
                blood.SetActive(false);
            }
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
                if(notListeningRandom <= switchRate)
                {
                chooseAction();
                }
            }
        }

    }
    void chooseAction()
    {
        if(isListening)
        {
            isListening = false;
            actionChoice = Random.Range(0.0f, (actionNumber - 1));
            actionChoice = Mathf.Round(actionChoice);
            print(actionChoice);
            //print(actionChoice);
            if (actionChoice == 0 && haveBag == true)
            {
                animator.SetBool("isSleep", true);
                studentBagScript.toggleBackpack();
                classroom.GetComponent<ClassroomScript>().studentNotListening++;
            }
            else if (actionChoice == 1)
            {
                animator.SetBool("isSleep", true);
                classroom.GetComponent<ClassroomScript>().studentNotListening++;
            }
            else if (actionChoice == 2 && studentToSpeak != null && classroom.GetComponent<ClassroomScript>().studentNotListening < (classroom.GetComponent<ClassroomScript>().maxStudentNotListening - 1))
            {
                principalTalker = true;
                animator.SetBool("isTalking", true);
                classroom.GetComponent<ClassroomScript>().studentNotListening++;
                studentToSpeak.GetComponent<StudentScript>().SendMessage("youreTalkingToMe", gameObject, SendMessageOptions.DontRequireReceiver);
                speakingToSomeone = true;
                sourceBlablaStudent.clip = listAudio[Random.Range(0, listAudio.Length)];
                sourceBlablaStudent.Play();
            }

            
        }
       
        


    }
    public void getHit()
    {
        if (haveBag && studentBag.GetComponent<SpriteRenderer>().enabled)
        {
            studentBagScript.toggleBackpack();

        }
        if (!isListening)
        {
           
            if(speakingToSomeone == true)
            {
                studentToSpeak.GetComponent<StudentScript>().getHit();
                speakingToSomeone = false;
            }
            blood.SetActive(true);
            blood.GetComponent<Animator>().SetBool("isBlood", true);
            animator.SetBool("isTalking", false);
            classroom.GetComponent<ClassroomScript>().studentNotListening--;
            animator.SetBool("isSleep", false);
            isListening = true;
            sourceBlablaStudent.Stop();
        }
    }
    void youreTalkingToMe(GameObject studentTalkingToMe)
    {
        isListening = false;
        animator.SetBool("isSleep", false);
        animator.SetBool("isTalking", true);
        classroom.GetComponent<ClassroomScript>().studentNotListening++;
    }
}
