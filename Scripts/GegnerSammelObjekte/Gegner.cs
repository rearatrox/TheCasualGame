using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Gegner : MonoBehaviour
{
    private bool startSlowMo;
    private float timer = 1.0f;
    private string[] Ausdrücke = { "Game Over!", "Try Again :)", "Close :^)", "You died :(", "Ouh noo..", "You were so young.." };

    private void Update()
    {
        if (startSlowMo)
        {
            if (Time.timeScale > 0.01f)
            {
                
                Time.timeScale -= .007f;
            }
            else
            {
                Time.timeScale = 0;
            }
            
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        FindObjectOfType<PlayerMovement>().gameOver = false;
        startSlowMo = true;
        FindObjectOfType<Starter>().startTimer = false;
        var rand = new System.Random();

        //Sperrt die Steuerung des Players
        FindObjectOfType<PlayerMovement>().gameOver = false;
        //Startet SlowMotion
        startSlowMo = true;
        //Zeigt GameOverPanel
        FindObjectOfType<GameManager>().PopUpPanel.SetActive(true);
        FindObjectOfType<GameManager>().LevelNamePopUp = GameObject.Find("LevelName");
        int randomIndizesFürAusdrücke = rand.Next(Ausdrücke.Length);
        string PrintAusdruck = Ausdrücke[randomIndizesFürAusdrücke];
        FindObjectOfType<GameManager>().LevelNamePopUp.transform.localScale = new Vector3(.7f, .7f, 1);
        FindObjectOfType<GameManager>().LevelNamePopUp.GetComponent<Text>().text = Ausdrücke[randomIndizesFürAusdrücke];

        //Zeit trotzdem mittig anzeigen
        FindObjectOfType<GameManager>().ZeitPopUp.transform.parent.gameObject.transform.localPosition = new Vector2(40, 0);
        //Zeit Text
        FindObjectOfType<GameManager>().ZeitPopUp.GetComponent<Text>().text = FindObjectOfType<Timer>().seconds.ToString("00") + "." + FindObjectOfType<Timer>().milliseconds.ToString("00") + "s";
        //Beste Zeit Text entfernen
        FindObjectOfType<GameManager>().BesteZeitPopUp.transform.parent.gameObject.SetActive(false);
        //Buttons Text verändern
        FindObjectOfType<GameManager>().PopUpPanel_Button_Left.transform.GetChild(0).gameObject.GetComponent<Text>().text = "RETRY";
        FindObjectOfType<GameManager>().PopUpPanel_Button_Right.transform.GetChild(0).gameObject.GetComponent<Text>().text = "MENU";
        //Buttons zuweisen
        FindObjectOfType<GameManager>().PopUpPanel_Button_Left.GetComponent<Button>().onClick.AddListener(FindObjectOfType<GameManager>().RestartLevel);
        FindObjectOfType<GameManager>().PopUpPanel_Button_Right.GetComponent<Button>().onClick.AddListener(FindObjectOfType<GameManager>().BackToKapitel);

    }
    IEnumerator Wait(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        
    }
   
}
