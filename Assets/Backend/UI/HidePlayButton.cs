using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayButton : MonoBehaviour
{
    public float SekundenBisVerschwinden;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, SekundenBisVerschwinden);
    }
}
