using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().SetObjects();
    }

}
