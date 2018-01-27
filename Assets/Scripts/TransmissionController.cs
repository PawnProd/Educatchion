﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransmissionController : MonoBehaviour {

    public float transmission;

    public bool isOnPlateform;

    private void Update()
    {
        if(isOnPlateform)
        {
            // On calcul la transmission en fonction du nombre d'élève à l'écoute
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isOnPlateform = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isOnPlateform = false;
        }

    }
}
