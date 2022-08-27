using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellMeTrigger : MonoBehaviour
{
    public AudioSource Instruct;
    // Start is called before the first frame update
    void Start()
    {
        Instruct = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (Instruct != null){
            Instruct.Play();
        }
    }

}
