using Michsky.UI.ModernUIPack;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressKaptitel : MonoBehaviour
{

    public GameObject FortschrittAnzeige;
    private float anzLevelKap1 = 12f;
    private float timer = 1.0f;
    float progress;
    // Start is called before the first frame update

    private void Start()
    {
        FortschrittAnzeige = GameObject.Find("FortschrittKap1");
    }
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        ErrechneKapitelProgress();
    }

    void ErrechneKapitelProgress()
    {
         progress = (PlayerPrefs.GetInt("AnzCheckbox") / anzLevelKap1) * 100;
        
        if (FortschrittAnzeige.GetComponent<ProgressBar>().currentPercent < progress)
        {
            
            FortschrittAnzeige.GetComponent<ProgressBar>().speed = 1;
            FortschrittAnzeige.GetComponent<ProgressBar>().currentPercent++;
        }
        else
        {
            FortschrittAnzeige.GetComponent<ProgressBar>().speed = 0;
        }
        
    }
}
