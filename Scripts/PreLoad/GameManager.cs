using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Assertions.Must;

public class GameManager : MonoBehaviour
{

    public int KapitelIndex;


    public GameObject Kap1_Button;
    public GameObject WinPanel;
    public GameObject WinPanelTextTime;
    public GameObject WinPanelTextBestTime;
    public GameObject GameOverPanel;
    public GameObject PopUpPanel;
    public GameObject LevelNamePopUp;
    public GameObject ZeitPopUp;
    public GameObject BesteZeitPopUp;
    public GameObject PopUpPanel_Button_Left;
    public GameObject PopUpPanel_Button_Right;

    //Buttons
    public GameObject Button_BackToKapitel;
    public GameObject Button_Reload;
    public GameObject Button_BackToKapitelGameOver;
    public GameObject Button_ReloadGameOver;
    public GameObject Button_NextLevel;
    public GameObject Button_Home;
    public GameObject Button_Settings;
    public GameObject Button_Quit;

    public GameObject Button_WerteReseten;

    public float timerPopUp = 0.00f;
    public bool PopUpPanelOpened = false;

    //Wird in ReverseArea gebraucht
    public bool IstInReverseArea = false;


    private void Awake()
    {

      
    }
    // Start is called before the first frame update
    void Start()
    {
        
        SetObjects();
        Debug.Log(PlayerPrefs.GetInt("AnzAbgeschlosseneLevel"));

    }

    // Update is called once per frame
    void Update()
    {
        AnimationFürZeitPopUp();
    }


    public void SetObjects()
        {

        //Werte Reseten
        Button_WerteReseten = GameObject.Find("Button_WerteReseten");
        if (Button_WerteReseten != null)
            Button_WerteReseten.GetComponent<Button>().onClick.AddListener(ResetPlayerPrefs);

        //Kapitel1
        Kap1_Button = GameObject.Find("Button_Kapitel1");
        if (Kap1_Button != null)
            Kap1_Button.GetComponent<Button>().onClick.AddListener(LadeKapitel1);
        //Kapitel2

        //Kapitel3

        //Kapitel4

        //Kapitel5

        //Quit
        Button_Quit = GameObject.Find("Button_Quit");
        if (Button_Quit != null)
            Button_Quit.GetComponent<Button>().onClick.AddListener(QuitGame);

        //Home
        Button_Home = GameObject.Find("Button_Home");
        if (Button_Home != null)
            Button_Home.GetComponent<Button>().onClick.AddListener(Home);

        //PausePanel
        Button_Settings = GameObject.Find("Button_Settings");
        if (Button_Settings != null)
            //SettingsPanel.SetActive(false);
        if (Button_Settings != null)
            Button_Settings.GetComponent<Button>().onClick.AddListener(Settings);

        //BackToKapitel
        Button_BackToKapitel = GameObject.Find("Button_Kapitel");
        Button_BackToKapitelGameOver = GameObject.Find("Button_KapitelGO");
        if(Button_BackToKapitel != null)
            Button_BackToKapitel.GetComponent<Button>().onClick.AddListener(BackToKapitel);
        if (Button_BackToKapitelGameOver != null)
            Button_BackToKapitelGameOver.GetComponent<Button>().onClick.AddListener(BackToKapitel);

        //RestartLevel
        Button_Reload = GameObject.Find("Button_Reload");
        Button_ReloadGameOver = GameObject.Find("Button_ReloadGO");
        if (Button_ReloadGameOver != null)
            Button_ReloadGameOver.GetComponent<Button>().onClick.AddListener(RestartLevel);
        if (Button_Reload != null)
            Button_Reload.GetComponent<Button>().onClick.AddListener(RestartLevel);
        //NextLevel
        Button_NextLevel = GameObject.Find("Button_NextLevel");
        if (Button_NextLevel != null)
            Button_NextLevel.GetComponent<Button>().onClick.AddListener(LadeNextLevel);

        //WinPanel
        WinPanel = GameObject.Find("WinPanel");
        WinPanelTextTime = GameObject.Find("TimeScore");
        WinPanelTextBestTime = GameObject.Find("TimeBestScore");
        if (WinPanel != null)
           WinPanel.SetActive(false);

        //GameOverPanel
        GameOverPanel = GameObject.Find("GameOverPanel");
        if (GameOverPanel != null)
            GameOverPanel.SetActive(false);

        //PopUpPanel
        PopUpPanel = GameObject.Find("PopUpPanel");
        PopUpPanel_Button_Left = GameObject.Find("Button_Back_PopUp");
        PopUpPanel_Button_Right = GameObject.Find("Button_Start_PopUp");
        ZeitPopUp = GameObject.Find("Uhr_Text");
        BesteZeitPopUp = GameObject.Find("Best_Text");

        if (PopUpPanel  != null)
            PopUpPanel.SetActive(false);
        if (PopUpPanel_Button_Left != null)
            PopUpPanel_Button_Left.GetComponent<Button>().onClick.AddListener(SchließePopUpPanel);
        if (PopUpPanel_Button_Right != null)
            PopUpPanel_Button_Right.GetComponent<Button>().onClick.AddListener(LadeLevel);


    }

    void ResetPlayerPrefs()
    {
            //Werte reseten
            PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("AnzAbgeschlosseneLevel", 0);
       

    }



    public void QuitGame()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        PopUpPanel.SetActive(true);
        Time.timeScale = 0;
        //PopUpPanel Text ändern
        LevelNamePopUp = GameObject.Find("LevelName");
        LevelNamePopUp.transform.localScale = new Vector3(.7f, .7f, 1);
        LevelNamePopUp.GetComponent<Text>().text = "Game paused";
        //aktuelle Zeit des Timers reinschreiben
        ZeitPopUp.GetComponent<Text>().text = FindObjectOfType<Timer>().TimerText.text;
        BesteZeitPopUp.GetComponent<Text>().text = PlayerPrefs.GetString(SceneManager.GetActiveScene().name) + "s";
        //Buttons zuweisen
        PopUpPanel_Button_Left.transform.GetChild(0).gameObject.GetComponent<Text>().text = "RESUME";
        PopUpPanel_Button_Right.transform.GetChild(0).gameObject.GetComponent<Text>().text = "MENU";
        PopUpPanel_Button_Left.GetComponent<Button>().onClick.AddListener(SchließePopUpPanel);
        PopUpPanel_Button_Right.GetComponent<Button>().onClick.AddListener(BackToKapitel);

    }

    public void LadeNextLevel()
    {
        PlayerPrefs.SetInt("levelIndex", PlayerPrefs.GetInt("levelIndex") + 1);
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + (SceneManager.GetActiveScene().buildIndex -2 + 1).ToString());
    }

    public void BackToKapitel()
    {
        Time.timeScale = 1;
        switch (KapitelIndex)
        {
            case 1:


                SceneManager.LoadScene("Kapitel1");


                break;
            case 2:
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("Kapitel2");
                break;

        }
    }

    public void SchließePopUpPanel()
    {
        
        PopUpPanel.SetActive(false);
        PopUpPanelOpened = false;
        timerPopUp = 0.00f;
        Time.timeScale = 1;

    }
    public void ÖffnePopUpPanel()
    {
        PopUpPanel.SetActive(true);
        PopUpPanel.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(PopUpPanel.transform.GetChild(0).gameObject, new Vector3(1, 1, 1), .2f);
        LevelNamePopUp = GameObject.Find("LevelName");
        PopUpPanelOpened = true;

        LevelNamePopUp.GetComponent<Text>().text = "LEVEL " + PlayerPrefs.GetInt("levelIndex").ToString();
        ZeitPopUp.GetComponent<Text>().text = PlayerPrefs.GetString("Level" + PlayerPrefs.GetInt("levelIndex").ToString()) + "s";
        if (PlayerPrefs.GetString("Level" + PlayerPrefs.GetInt("levelIndex").ToString()) == "")
            ZeitPopUp.GetComponent<Text>().text = "--.--" + " s";
    }


    public void LadeLevel()
    {
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("levelIndex"));
    }

    private void LadeKapitel1()
    {
         SceneManager.LoadScene("Kapitel1");
     

    }

    public void RestartLevel()
    {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;

    }

    public void AnimationFürZeitPopUp()
    {
        if (PopUpPanelOpened && SceneManager.GetActiveScene().name == "Kapitel1")

        {
            if ((PlayerPrefs.GetString("Level" + PlayerPrefs.GetInt("levelIndex").ToString()) == ""))
                ZeitPopUp.GetComponent<Text>().text = "--.--s";
           else if (timerPopUp < float.Parse(PlayerPrefs.GetString("Level" + PlayerPrefs.GetInt("levelIndex").ToString()), System.Globalization.CultureInfo.InvariantCulture))
            {
                timerPopUp += Time.deltaTime * 5;
                int seconds = Mathf.FloorToInt(timerPopUp % 60F);
                int milliseconds = Mathf.FloorToInt((timerPopUp * 100F) % 100F);
                ZeitPopUp.GetComponent<Text>().text = seconds.ToString("00") + ":" + milliseconds.ToString("00") + "s";
            }
            else
            {
                ZeitPopUp.GetComponent<Text>().text = PlayerPrefs.GetString("Level" + PlayerPrefs.GetInt("levelIndex").ToString()) + "s";
            }

        }
    }
    
}
