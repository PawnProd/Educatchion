using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutoScript : MonoBehaviour {
    public Image bubble;
    public Text textBubble;
    public LevelManager levelManager;
    public string[] listText;
    public float textDuration;
    private int _indexText = 0;
    private float _timer = 0;

    // Use this for initialization
    void Start () {
        textBubble.text = listText[_indexText];
        bubble.transform.parent.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if(_indexText < listText.Length)
        {
            _timer += Time.deltaTime;
            if (_timer >= textDuration)
            {
                _timer = 0;
                ++_indexText;
                if(_indexText < listText.Length)
                    textBubble.text = listText[_indexText];
            }
        } else
        {
            bubble.transform.parent.gameObject.SetActive(false);
<<<<<<< HEAD
            LevelManager.levelState = LevelState.running;
=======
            levelManager.levelState = LevelState.running;
>>>>>>> 77127bd5d73b46b433fe498169f2819a20da0f2d
        }
    }
}
