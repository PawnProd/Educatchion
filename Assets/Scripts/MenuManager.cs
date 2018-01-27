using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager: MonoBehaviour {

    public bool pause;
    public GameObject objetPause;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(Input.GetKeyUp(KeyCode.P))
        {
            if (!pause)
            {
                objetPause.SetActive(true);
                pause = true;
            }
            else
            {
                objetPause.SetActive(false);
                pause = false;
            }
        }
    }

    public void pauseStop()
    {
        if (!pause)
        {
            objetPause.SetActive(false);
            pause = true;
        }
        else
        {
            objetPause.SetActive(false);
            pause = false;
        }
    }
}
