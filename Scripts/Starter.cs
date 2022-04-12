using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{

    public Animation anim;
    public bool startGame = false;
    public bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Close") && this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
        {
            startGame = true;
            
        }
    }
}
