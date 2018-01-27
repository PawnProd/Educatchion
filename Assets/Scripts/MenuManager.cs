using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jouez : MonoBehaviour {

    //SceneManager gotomain;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void clickJouez()
    {
        SceneManager.GetSceneByName("Main");
    }
}
