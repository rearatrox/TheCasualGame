using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveUpwardds : MonoBehaviour
{
    private Rigidbody rb;
    private bool reached;
    private void Awake()
    {
        reached = true;
    }
    // Start is called before the first frame update
    void Update()
    {
        if(FindObjectOfType<Starter>().startGame && reached == true)
        {
            StartCoroutine(move());
            reached = false;
        }
       

    }

    IEnumerator move()
    {
        if (FindObjectOfType<Starter>().startGame)
        {
            FindObjectOfType<Starter>().startTimer = true;
            LeanTween.move(gameObject, new Vector3(transform.position.x, 50, 0f), PlayerPrefs.GetFloat("TimerPerfect"));
            
        }
        
        yield return new WaitForSeconds(.1f);
    }
    private void moveUp()
    {
       
    }
}
