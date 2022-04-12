using System.Collections;
using UnityEngine;

public class Schweif : MonoBehaviour
{

    public float minGeschw = 0.1f;
    public float speed = 1F;

    private Vector3 lastmousepos;
    private Vector3 mouseGeschw;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SchweifFollow();
    }

    void SchweifFollow()
    {
        var mousePos = transform.parent.transform.position;
        rb.position = mousePos;
    }
}
