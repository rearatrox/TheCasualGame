using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System;

public class KapitelManager : MonoBehaviour
{
    public int levelIndex;
    private int sizeOfButtons = 3;
    public GameObject[] Start_Button;
    public GameObject[] EntsperreTexte;
    public GameObject[] GesperrtIcon;
    public GameObject[] CheckBox;
    public GameObject[] Kreuz;
    private int sizeOfEntsperreTexte = 12;
    private int sizeOfGesperrtIcon = 12;
    private int sizeOfFlameIcons = 12;
    public GameObject[] Texte;

    private int AnzCheckBox = 0;
    public bool ZustandGeändert = true;

    public string[] ZuständeCheckbox;
    public bool LevelPerfect;

    private void OnEnable()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        SetzeButtons();
        EntsperreTexteGUI();
        ZuständeCheckbox = new string[12];
        Debug.Log(PlayerPrefs.GetString("Level5"));
    }

    // Update is called once per frame
    void Update()
    {
       /* if(PlayerPrefs.GetString("Level2") == "")
            if (float.Parse(PlayerPrefs.GetString("Level2"), System.Globalization.CultureInfo.InvariantCulture) < PlayerPrefs.GetFloat("TimerPerfectLvl2"))
            {
                FlameIcon[1].SetActive(true);

            } */

    }

    private void SetzeButtons()
    {
        Texte = GameObject.FindGameObjectsWithTag("TestText");
        Start_Button = new GameObject[sizeOfButtons];
        Start_Button = GameObject.FindGameObjectsWithTag("Start_Button");

        //GesperrtIcons
        GesperrtIcon = new GameObject[sizeOfGesperrtIcon];
        GesperrtIcon[0] = GameObject.Find("GesperrtIcon0");
        GesperrtIcon[1] = GameObject.Find("GesperrtIcon1");
        GesperrtIcon[2] = GameObject.Find("GesperrtIcon2");
        GesperrtIcon[3] = GameObject.Find("GesperrtIcon3");
        GesperrtIcon[4] = GameObject.Find("GesperrtIcon4");
        GesperrtIcon[5] = GameObject.Find("GesperrtIcon5");
        GesperrtIcon[6] = GameObject.Find("GesperrtIcon6");
        GesperrtIcon[7] = GameObject.Find("GesperrtIcon7");
        GesperrtIcon[8] = GameObject.Find("GesperrtIcon8");
        GesperrtIcon[9] = GameObject.Find("GesperrtIcon9");
        GesperrtIcon[10] = GameObject.Find("GesperrtIcon10");
        GesperrtIcon[11] = GameObject.Find("GesperrtIcon11");

        //EntsperrteTexte
        EntsperreTexte = new GameObject[sizeOfEntsperreTexte];
        EntsperreTexte[0] = GameObject.Find("EntsperrteTexte0");
        EntsperreTexte[1] = GameObject.Find("EntsperrteTexte1");
        EntsperreTexte[2] = GameObject.Find("EntsperrteTexte2");
        EntsperreTexte[3] = GameObject.Find("EntsperrteTexte3");
        EntsperreTexte[4] = GameObject.Find("EntsperrteTexte4");
        EntsperreTexte[5] = GameObject.Find("EntsperrteTexte5");
        EntsperreTexte[6] = GameObject.Find("EntsperrteTexte6");
        EntsperreTexte[7] = GameObject.Find("EntsperrteTexte7");
        EntsperreTexte[8] = GameObject.Find("EntsperrteTexte8");
        EntsperreTexte[9] = GameObject.Find("EntsperrteTexte9");
        EntsperreTexte[10] = GameObject.Find("EntsperrteTexte10");
        EntsperreTexte[11] = GameObject.Find("EntsperrteTexte11");

        //FlameIcons

        CheckBox = new GameObject[sizeOfGesperrtIcon];
        CheckBox[0] = GameObject.Find("CheckBox0");
        CheckBox[1] = GameObject.Find("CheckBox1");
        CheckBox[2] = GameObject.Find("CheckBox2");
        CheckBox[3] = GameObject.Find("CheckBox3");
        CheckBox[4] = GameObject.Find("CheckBox4");
        CheckBox[5] = GameObject.Find("CheckBox5");
        CheckBox[6] = GameObject.Find("CheckBox6");
        CheckBox[7] = GameObject.Find("CheckBox7");
        CheckBox[8] = GameObject.Find("CheckBox8");
        CheckBox[9] = GameObject.Find("CheckBox9");
        CheckBox[10] = GameObject.Find("CheckBox10");
        CheckBox[11] = GameObject.Find("CheckBox11");

        Kreuz = new GameObject[sizeOfGesperrtIcon];
        Kreuz[0] = GameObject.Find("Kreuz0");
        Kreuz[1] = GameObject.Find("Kreuz1");
        Kreuz[2] = GameObject.Find("Kreuz2");
        Kreuz[3] = GameObject.Find("Kreuz3");
        Kreuz[4] = GameObject.Find("Kreuz4");
        Kreuz[5] = GameObject.Find("Kreuz5");
        Kreuz[6] = GameObject.Find("Kreuz6");
        Kreuz[7] = GameObject.Find("Kreuz7");
        Kreuz[8] = GameObject.Find("Kreuz8");
        Kreuz[9] = GameObject.Find("Kreuz9");
        Kreuz[10] = GameObject.Find("Kreuz10");
        Kreuz[11] = GameObject.Find("Kreuz11");



    }

   public void EntsperreTexteGUI()
    {
        //Muss zurückgesetzt werden, da es sonst ein Überlauf des Wertes geben würde
        PlayerPrefs.SetInt("AnzCheckbox", 0);

        //Geht alle Level durch und überprüft, ob sie freigeschalten werden können oder nicht
        for (int i = 0; i < sizeOfEntsperreTexte; i++)
        {
            
            if (i <= PlayerPrefs.GetInt("AnzAbgeschlosseneLevel"))
            {
                //Extra Abfrage, wegen den PlayerPrefs, sonst evtl. falsches String-Format bei nächster If-Abfrage
                if(PlayerPrefs.GetString("Level" + (i + 1).ToString()) == "")
                {
                    CheckBox[i].SetActive(false);
                    Kreuz[i].SetActive(true);
                }
                 //erspielte Zeit wird mit der zu schaffenden Zeit verglichen für jedes Level -> falls besser, gibt es die Checkbox
                else if (float.Parse(PlayerPrefs.GetString("Level" + (i + 1).ToString()), System.Globalization.CultureInfo.InvariantCulture) < PlayerPrefs.GetFloat("TimerPerfectLvl" + (i + 1).ToString()))
                {
                    CheckBox[i].SetActive(true);
                    Kreuz[i].SetActive(false);
                    PlayerPrefs.SetInt("AnzCheckbox", PlayerPrefs.GetInt("AnzCheckbox")+1);
                }
                else
                {
                    CheckBox[i].SetActive(false);
                    Kreuz[i].SetActive(true);
                }


             EntsperreTexte[i].SetActive(true);
             GesperrtIcon[i].SetActive(false);
            }

            else
            {
               
                EntsperreTexte[i].SetActive(false);
                CheckBox[i].SetActive(false);
                Kreuz[i].SetActive(true);
                GesperrtIcon[i].SetActive(true);
            }

            
                
        }
    }

}
