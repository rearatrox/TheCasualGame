using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1.0f;

    // Global Gravity doesn't appear in the inspector. Modify it here in the code
    // (or via scripting) to define a different default gravity for all objects.

    public static float globalGravity = -9.81f;

    Rigidbody m_rb;

    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    void FixedUpdate()
    {
        //  if(m_rb.velocity.y >= 5)
        // {
        //     m_rb.AddForce(new Vector3(0,0,0), ForceMode.Acceleration);
        // }
        //  else
        //  {
            Vector3 gravity = globalGravity * gravityScale * Vector3.up;
            m_rb.AddForce(gravity, ForceMode.Acceleration);
      //  Debug.Log("Geschwindigkeit: " + m_rb.velocity);
       // }
       

    }
}
