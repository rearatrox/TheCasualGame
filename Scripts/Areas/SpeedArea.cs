using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            FindObjectOfType<CustomGravity>().gravityScale = 8f;
            FindObjectOfType<PlayerMovement>().Geschwindigkeitsfaktor = 27;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            FindObjectOfType<CustomGravity>().gravityScale = 4f;
            FindObjectOfType<PlayerMovement>().Geschwindigkeitsfaktor = 20;
        }
    }
}
