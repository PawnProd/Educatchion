using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager: MonoBehaviour {

    public bool pause;
    public Button jouez;
    public Button quittez;
    public Text Pause;
    public Button PauseMoment;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void fixedUpdate () {
        
        if(Input.GetKeyUp("space"))
        {
            if (!pause)
            {
                jouez.GetComponent<GameObject>().SetActive(false);
                quittez.GetComponent<GameObject>().SetActive(false);
                Pause.GetComponent<GameObject>().SetActive(false);
                PauseMoment.GetComponent<GameObject>().SetActive(true);
                pause = true;
            }
            else
            {
                jouez.GetComponent<GameObject>().SetActive(true);
                quittez.GetComponent<GameObject>().SetActive(true);
                Pause.GetComponent<GameObject>().SetActive(true);
                PauseMoment.GetComponent<GameObject>().SetActive(false);
                pause = false;
            }
        }
    }

    private void pauseStop()
    {
        if (!pause)
        {
            jouez.GetComponent<GameObject>().SetActive(false);
            quittez.GetComponent<GameObject>().SetActive(false);
            Pause.GetComponent<GameObject>().SetActive(false);
            PauseMoment.GetComponent<GameObject>().SetActive(true);
            pause = true;
        }
        else
        {
            jouez.GetComponent<GameObject>().SetActive(true);
            quittez.GetComponent<GameObject>().SetActive(true);
            Pause.GetComponent<GameObject>().SetActive(true);
            PauseMoment.GetComponent<GameObject>().SetActive(false);
            pause = false;
        }
    }
}
