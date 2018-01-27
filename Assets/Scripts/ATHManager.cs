using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATHManager : MonoBehaviour {


    public GameObject timeNeedle;

    public GameObject popupWin;

    public GameObject popupFailed;

    public Text scoreText;

    public Text time;

    public Text ammo;

    public int defaultHour;

    public Image progressBar;

	public void UpdateTime(float newTime, float rotationSpeed, int levelDuration)
    {
        int hour = defaultHour;
        int minutes = ((int)newTime / levelDuration);
        string minutesString = minutes.ToString();

        if(minutes < 10)
        {
            minutesString = "0" + minutes.ToString();
        }
        else if (minutes >= 60)
        {
            minutes = 0;
            hour++;
            minutesString = "0" + minutes.ToString();
        }

        timeNeedle.transform.Rotate(new Vector3(0, 0, -(rotationSpeed * Time.deltaTime)));
        time.text = string.Format("Heure : {0} : {1}", hour, minutesString);
    }

    public void UpdateAmmo(int newAmmoAmount)
    {
        ammo.text = newAmmoAmount.ToString();
    }

    public void UpdateProgessBar(float progressSpeed)
    {
        progressBar.fillAmount -= progressSpeed;
    }

    public void ShowPopupWin(int score)
    {
        popupWin.SetActive(true);
        scoreText.text = score.ToString();
    }

    public void ShowPopupFailed()
    {
        popupFailed.SetActive(true);
    }
}
