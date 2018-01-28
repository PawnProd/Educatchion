using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoScript : MonoBehaviour {
    public GameObject bubble;
    public SpriteRenderer bubbleSprite;
    public float currentTime;
    private bool tutoIsHide = true;
    private float i = 0;
    // Use this for initialization
    void Start () {
        bubbleSprite = bubble.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (tutoIsHide)
        {
            tutoIsHide = !tutoIsHide;
            bubbleSprite.enabled = !bubbleSprite.enabled;
        }
            if (currentTime >= 0)
            {
                currentTime -= Time.deltaTime;
            }else if(i == 0)
            {
                i++;
                bubbleSprite.enabled = !bubbleSprite.enabled;
            }
    }
}
