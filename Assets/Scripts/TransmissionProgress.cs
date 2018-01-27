using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransmissionProgress: MonoBehaviour {

    //speedtransmission correspond à la vitesse de remplissage
    //transmissionLevel correspont à la transmission de savoir requise
    //transmissionprogresscorrespond à la quantité déjà transmise
    //progressEnd correspond à la condition de victoire
    //is savoirtransmis correspond à si le prof est sur l'estrade
    public float speedTransmission;
    public Image progressFill;
    public Text progressText;
    public bool progressEnd;
    public bool isSavoirTransmis;
    public float transmissionLevel=1;
    public float transmissionProgress;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((transmissionProgress / transmissionLevel) <= 1)
        {
            progressFill.fillAmount = transmissionProgress / transmissionLevel;
            if (isSavoirTransmis && speedTransmission>=0)
                transmissionProgress += Time.deltaTime * speedTransmission;
        }
        else
        {
            progressText.text = "PROGRAM: FINISHED";
            progressEnd = true;
        }
    }
}
