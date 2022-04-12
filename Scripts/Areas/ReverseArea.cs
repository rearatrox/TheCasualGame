using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseArea : MonoBehaviour
{

    

    //Im Playermovement findet die Auswirkung statt
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            FindObjectOfType<GameManager>().IstInReverseArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            FindObjectOfType<GameManager>().IstInReverseArea = false;
        }
    }
}
