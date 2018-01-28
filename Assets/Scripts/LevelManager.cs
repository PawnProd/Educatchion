using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public ATHManager ath;

    public ClassroomScript classroom;

    public TransmissionController plateform;

    public static LevelState levelState;

    public int nbStudent = 12;

    public float levelDuration = 180.0f;

    public float progressSpeed = 0;

    public float progressAmout = 0;

    public float ratioSpeed;

    public bool tuto = false;

    private float _time = 0;

    private float _rotationSpeed = 0;

    private bool endGame = false;

    

	// Use this for initialization
	void Start () {
        _rotationSpeed =  ((2 * Mathf.PI) - 0.25f) / levelDuration;
        if(tuto)
        {
            levelState = LevelState.paused;
        } 
        else
        {
            levelState = LevelState.running;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!endGame && Time.timeScale != 0 && levelState == LevelState.running)
        {
            _time += Time.deltaTime;
            ath.UpdateTime(_time, _rotationSpeed, ((int)levelDuration));
            if (plateform.isOnPlateform)
            {
               
                progressSpeed = ((nbStudent - classroom.studentNotListening) * ratioSpeed) / 100;
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
            if (Input.GetKeyUp(KeyCode.Space))
            {
                levelState = LevelState.paused;
                ath.ShowPopupPause();
                Time.timeScale = 0;
            }
        }
	}

    public void EndGame(bool isWin)
    {
        levelState = LevelState.endGame;
        endGame = true;
        if(isWin)
        {
            int score = Mathf.Abs((nbStudent - classroom.studentNotListening) * (int)((levelDuration * 60) - _time));
            print("NbListening : " + (nbStudent - classroom.studentNotListening));
            print("Ratio score : " + (levelDuration * 60 - _time));
            ath.ShowPopupWin(score);
        }
        else
        {
            ath.ShowPopupFailed();
        }
    }



}

public enum LevelState
{
    running,
    paused,
    endGame
}
