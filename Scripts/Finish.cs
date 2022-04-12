using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour
{
    public int anzAbgeschlosseneLevelKap1 = 0;
    public GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("DiasGesammelt") >= PlayerPrefs.GetInt("DiasLevel"))
        {

            gameObject.GetComponent<BoxCollider>().isTrigger = true;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerPrefs.GetInt("DiasGesammelt") < PlayerPrefs.GetInt("DiasLevel"))
        {
            Debug.Log("Nicht genügend Dias");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
            if (PlayerPrefs.GetInt("DiasGesammelt") >= PlayerPrefs.GetInt("DiasLevel"))
            {
                //Timer stoppen
                FindObjectOfType<Starter>().startTimer = false;
                //WinPanel anzeigen
                Debug.Log("Hier Komm ich rein");
                FindObjectOfType<GameManager>().PopUpPanel.SetActive(true);
                gm.LevelNamePopUp = GameObject.Find("LevelName");

                //LevelName anzeigen
                gm.LevelNamePopUp.GetComponent<Text>().text = "Level " + (SceneManager.GetActiveScene().buildIndex - 2).ToString();
                //erspielte Zeit anzeigen
                gm.ZeitPopUp.GetComponent<Text>().text = FindObjectOfType<Timer>().seconds.ToString("00") + "." + FindObjectOfType<Timer>().milliseconds.ToString("00") + "s";
                //Button zuweisen
                FindObjectOfType<GameManager>().PopUpPanel_Button_Left.transform.GetChild(0).gameObject.GetComponent<Text>().text = "MENU";
                FindObjectOfType<GameManager>().PopUpPanel_Button_Right.transform.GetChild(0).gameObject.GetComponent<Text>().text = "NEXT";
                gm.PopUpPanel_Button_Left.GetComponent<Button>().onClick.AddListener(gm.BackToKapitel);
                gm.PopUpPanel_Button_Right.GetComponent<Button>().onClick.AddListener(gm.LadeNextLevel);
                //Überprüfung, ob erspielte Zeit geringer als BestScore
                //wenn ja, dann neue Bestzeit
                //Best Score nach Aktualisierung anzeigen
                CheckForBestScoreAndDisplayIfTrue();
                //Abgeschlossene Level erhöhen
                if (PlayerPrefs.GetInt("levelIndex") >= PlayerPrefs.GetInt("AnzAbgeschlosseneLevel"))
                    PlayerPrefs.SetInt("AnzAbgeschlosseneLevel", PlayerPrefs.GetInt("levelIndex"));
                //Zeit anhalten
                Time.timeScale = 0;
            }
    }

    private void CheckForBestScoreAndDisplayIfTrue()
    {
        if (FindObjectOfType<Timer>().timer <
               float.Parse(PlayerPrefs.GetString(SceneManager.GetActiveScene().name, "99.99"), System.Globalization.CultureInfo.InvariantCulture))
        {
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, FindObjectOfType<Timer>().seconds.ToString("00") + "." + FindObjectOfType<Timer>().milliseconds.ToString("00"));
            
        }
        gm.BesteZeitPopUp.GetComponent<Text>().text = PlayerPrefs.GetString(SceneManager.GetActiveScene().name) + "s";

    }
}
