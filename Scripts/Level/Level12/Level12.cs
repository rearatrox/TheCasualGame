using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Level12 : MonoBehaviour,IPointerDownHandler
{
    

    public void OnPointerDown(PointerEventData eventData)
    {
        //Setzt den LevelIndex, damit man weiß, welches Level geladen werden soll bei GameManager(LadeLevel)
        PlayerPrefs.SetInt("levelIndex", 12);
        //Lädt das Level
        FindObjectOfType<GameManager>().LadeLevel();
        
    }

}
