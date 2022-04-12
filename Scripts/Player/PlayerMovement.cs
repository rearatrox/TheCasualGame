using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 MausPosition;
    public float Mausx;
    public Vector3 Richtungsvektor;
    public Vector3 Ausgangspunkt;
    private Rigidbody rb;
    private Vector3 mousepos;
    public GameObject cam;
    private Vector3 CamPosition;
    private Vector3 PlayerPos;

    public int Geschwindigkeitsfaktor = 20;

    public bool gameOver = true;
    // Start is called before the first frame update
    void Start()
    {

        cam = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<Starter>().startGame && gameOver == true)
        {
            //Variable "PlayerPos" bekommt aktuelle Position vom Objekt, die das Skript trägt
            PlayerPos = transform.position;
            PlayerPos.z = 0f;
            transform.position = PlayerPos;

            mousepos = Input.mousePosition;
            mousepos.z = 25f;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ausgangspunkt = transform.position;
                Ausgangspunkt.x = 0f;
                MausPosition = Camera.main.ScreenToWorldPoint(mousepos);
                if (FindObjectOfType<GameManager>().IstInReverseArea)
                    MausPosition.x = -MausPosition.x;

                Ausgangspunkt.y = MausPosition.y - 10;
                //Debug.Log(MausPosition);
                Richtungsvektor = (MausPosition - Ausgangspunkt).normalized;
                Richtungsvektor.z = 0f;
                // Debug.Log("Richtungsvektor: " + Richtungsvektor);
                rb.velocity = Richtungsvektor * Geschwindigkeitsfaktor;

            }
        }
        


    }
}
