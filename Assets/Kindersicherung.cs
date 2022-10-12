using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Kindersicherung : MonoBehaviour
{
    public float entsicherung = 0.0f;
    public float sicherung = 2.0f;
    bool Clicku = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicku)
        {
            entsicherung += Time.deltaTime;
            if (entsicherung >= sicherung)
            {
                Destroy(gameObject, 0.1f);
            }
        }
        if (!Clicku)
            entsicherung = 0.0f;
    }


    public void OnMouseDown()
    {
        Clicku = true;
    }

    public void OnMouseUp()
    {
        Clicku = false;
    }
}
