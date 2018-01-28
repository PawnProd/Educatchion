using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionController : MonoBehaviour {

    public AudioClip[] listAudio;

    public AudioSource sourceBlablaProf;

    public Animator animator;

    public float transmission;

    public bool isOnPlateform;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(LevelManager.levelState == LevelState.endGame || LevelManager.levelState == LevelState.paused)
        {
            sourceBlablaProf.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            isOnPlateform = true;
            animator.SetBool("isOnPlateform", true);
            sourceBlablaProf.clip = listAudio[Random.Range(0, listAudio.Length)];
            sourceBlablaProf.Play();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOnPlateform = false;
            animator.SetBool("isOnPlateform", false);
            sourceBlablaProf.Stop();
        }

    }
}
