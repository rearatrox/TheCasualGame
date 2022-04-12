using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Level1 : MonoBehaviour, IPointerDownHandler
{
    //Level - 1

    private int level = 0;

    public void OnPointerDown(PointerEventData eventData)
    {


        if (level <= PlayerPrefs.GetInt("AnzAbgeschlosseneLevel"))
        {
            //Setzt den LevelIndex, damit man weiß, welches Level geladen werden soll bei GameManager(LadeLevel)
            PlayerPrefs.SetInt("levelIndex", 1);
            FindObjectOfType<GameManager>().ÖffnePopUpPanel();
        }
        else Debug.Log("Fehler°!");

    }

}
