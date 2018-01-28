using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionController : MonoBehaviour {

    public AudioClip[] listAudio;

    public AudioSource sourceBlablaProf;

    public float transmission;

    public bool isOnPlateform;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isOnPlateform = true;
            sourceBlablaProf.clip = listAudio[Random.Range(0, listAudio.Length)];
            sourceBlablaProf.Play();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOnPlateform = false;
            sourceBlablaProf.Stop();
        }

    }
}
