using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    // pivot, objet pour faire tourner l'aiguille
    // hourtext -> text du temps
    // timepasse temps passe
    // timeEnd, quand le temps est passe
    public GameObject pivot;
    public Text hourText;
    public float speedTimer;
    public float timePasse;
    public bool timeEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timePasse<9.5)
        {
            hourText.text = "heure : 11:0" + System.Convert.ToInt32(timePasse);
        }
        else
        {
            hourText.text = "heure : 11:" + System.Convert.ToInt32(timePasse);
        }
        if (timePasse<=60)
        {
            timePasse += Time.deltaTime * speedTimer / 6;
            pivot.transform.Rotate(new Vector3(0, 0, -(speedTimer * Time.deltaTime)));
        }
        else
        {
            hourText.text = "heure : 12:00";
            timeEnd = true;
        }
	}
}
