using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3fürGameObject : MonoBehaviour
{
    private float benötigteZeit = 8.0f;
    private int anzDias = 6;
    private string TimerLevel = "TimerPerfectLvl3";

    // Start is called before the first frame update
    void Start()
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