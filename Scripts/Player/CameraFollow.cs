using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.1f;
    public Vector3 offset;
    private Vector3 velocity = new Vector3(1f, 1f, 1f);

    private void FixedUpdate()
    {
        if (FindObjectOfType<Starter>().startGame)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            //smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
            smoothedPosition.x = 0;
            smoothedPosition.z = -25;
            transform.position = smoothedPosition;
        }
        

       
    }
}
