using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6fürLevelObjekt : MonoBehaviour
{
    private float benötigteZeit = 10.0f;
    private int anzDias = 9;
    private string TimerLevel = "TimerPerfectLvl6";

    // Start is called before the first frame update
    void Awake()
    {

        PlayerPrefs.SetInt("DiasLevel", anzDias);
        //Timer, wie schnell sich der Visualisierungstimer im Level bewegen soll.
        PlayerPrefs.SetFloat("TimerPerfect", benötigteZeit);
        //Wird im KapitelManager benötigt, um Flammen anzuzeigen
        PlayerPrefs.SetFloat(TimerLevel, PlayerPrefs.GetFloat("TimerPerfect"));
        //Setzt den KapitelIndex, damit man weiß, in welchem Kapitel man sich aktuell befindet
        FindObjectOfType<GameManager>().KapitelIndex = 1;

    }
}
