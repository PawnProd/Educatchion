using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backPackScript : MonoBehaviour {
    public Collider2D backPackCollider;
    public SpriteRenderer backPackRenderer;
    // Use this for initialization
    void Start () {
        backPackCollider = gameObject.GetComponent<BoxCollider2D>();
        backPackRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void toggleBackpack()
    {
        backPackCollider.enabled = ! backPackCollider.enabled;
        backPackRenderer.enabled = !backPackRenderer.enabled;
    }
}
