using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadTimes : MonoBehaviour
{
    private GameObject[] ZeitTexte;
    public int sizeOfZeitTexte = 12;
    private void Awake()
    {
        ZeitTexte = new GameObject[sizeOfZeitTexte];

    }

    // Start is called before the first frame update
    void Start()
    {
        //SetzeZeitTexte();
    }

    void SetzeZeitTexte()
    {
        for(int i = 0; i < sizeOfZeitTexte; i++)
        {
            ZeitTexte[i] = GameObject.FindGameObjectWithTag("ZeitText" + (i+1).ToString());
            ZeitTexte[i].GetComponent<Text>().text = PlayerPrefs.GetString("Level" + (i+1).ToString(),"--.--") + " s";
        }
    }

    
}
