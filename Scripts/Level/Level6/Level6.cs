﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Level6 : MonoBehaviour,IPointerDownHandler
{

    private int level = 5;

    public void OnPointerDown(PointerEventData eventData)
    {


        if (level <= PlayerPrefs.GetInt("AnzAbgeschlosseneLevel"))
        {
            //Setzt den LevelIndex, damit man weiß, welches Level geladen werden soll bei GameManager(LadeLevel)
            PlayerPrefs.SetInt("levelIndex", 6);
            FindObjectOfType<GameManager>().ÖffnePopUpPanel();
        }
        else Debug.Log("Fehler°!");

    }
}
