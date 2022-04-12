using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sammelobjekt : MonoBehaviour
{
    public int test;
    public int anzDiasLevel = 5;
    public static int anzDiasGesammelt = 0;
    public int anzDias;
    private void OnEnable()
    {
        PlayerPrefs.SetInt("DiasGesammelt", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        PlayerPrefs.SetInt("DiasGesammelt", PlayerPrefs.GetInt("DiasGesammelt") + 1);
        Debug.Log("Anzahl Diamanten: " + PlayerPrefs.GetInt("DiasGesammelt"));
    }

}
