using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMoArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            FindObjectOfType<CustomGravity>().gravityScale = 2f;
            FindObjectOfType<PlayerMovement>().Geschwindigkeitsfaktor = 17;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if ( other.gameObject == GameObject.Find("Player"))
        {
            FindObjectOfType<CustomGravity>().gravityScale = 4f;
            FindObjectOfType<PlayerMovement>().Geschwindigkeitsfaktor = 20;
        }
    }
}
