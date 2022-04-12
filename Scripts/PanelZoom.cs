using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelZoom : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }


    void Start()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
