﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public ATHManager ath;

    public ClassroomScript classroom;

    public TransmissionController plateform;

    public int nbStudent = 12;

    public float levelDuration = 180.0f;

    public float progressSpeed = 0;

    public float progressAmout = 0;

    private float _time = 0;

    private float _rotationSpeed = 0;

    private bool endGame = false;

    

	// Use this for initialization
	void Start () {
        _rotationSpeed =  ((2 * Mathf.PI) - 0.25f) / levelDuration;
	}
	
	// Update is called once per frame
	void Update () {
        if(!endGame)
        {
            _time += Time.deltaTime;
            ath.UpdateTime(_time, _rotationSpeed, ((int)levelDuration));
            if (plateform.isOnPlateform)
            {
                progressSpeed = ((nbStudent - classroom.studentNotListening) * 0.002f) / 100;
                progressAmout += progressSpeed;
                ath.UpdateProgessBar(progressSpeed);
            }

            if (progressAmout >= 1)
            {
                EndGame(true);
            }
            else if (_time > levelDuration * 60)
            {
                EndGame(false);
            }
        }
	}

    public void EndGame(bool isWin)
    {
        endGame = true;
        if(isWin)
        {
            int score = (nbStudent - classroom.studentNotListening) * (int)(levelDuration - _time);
            ath.ShowPopupWin(score);
        }
        else
        {
            ath.ShowPopupFailed();
        }
    }

}