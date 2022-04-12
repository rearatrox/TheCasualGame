using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GegnerMovement : MonoBehaviour
{
    public bool IsMovingHorizontal;
    public bool IsMovingVertical;
    public bool IsRotating;
    public bool IsScaling;
    private bool forward = true;
    public Vector3 rotationAngle;
    public bool goingRight = true;
    public bool goingLeft = false;
    public float movingSpeed = 1.0f;


    public Vector3 startScale;
    public Vector3 endScale;

    private bool scalingUp = true;
    public float scaleSpeed;
    public float scaleRate;
    private float scaleTimer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsMovingHorizontal && !IsRotating)
        {

            if(transform.position.x < 3.5f && goingRight == true)
            {
                transform.Translate(Vector3.right * movingSpeed * Time.deltaTime);
                if (transform.position.x >= 3.5f)
                {
                    goingRight = false;
                    goingLeft = true;
                }


            }

            if (transform.position.x > -3.5f && goingLeft == true)
            {
                transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
                if (transform.position.x <= -3.5f)
                {
                    goingRight =true;
                    goingLeft = false;
               }

            }

        }

        
        if(IsMovingHorizontal && IsRotating)
        {
            transform.Translate(Vector3.up * movingSpeed * Time.deltaTime);
            transform.Rotate(new Vector3(0,0,3));
        }

        if (IsRotating)
        {
            transform.Rotate(rotationAngle * movingSpeed * Time.deltaTime);
        }

        if (IsScaling)
        {
            scaleTimer += Time.deltaTime;

            if (scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
            }
            else if (!scalingUp)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
            }

            if (scaleTimer >= scaleRate)
            {
                if (scalingUp) { scalingUp = false; }
                else if (!scalingUp) { scalingUp = true; }
                scaleTimer = 0;
            }
        }
    }
}
