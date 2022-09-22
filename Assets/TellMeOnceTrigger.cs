using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TellMeOnceTrigger : MonoBehaviour
{
    public AudioSource Instruct;
     bool triggered = false;
    public float clickedTime = 0.0f;
    public float timeForEffect = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instruct = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && !Instruct.isPlaying)
            Destroy(gameObject, 0.1f);
    }

    void OnMouseDown()
    {
        if (Instruct != null)
        {
            Instruct.Play();
            triggered = true;
        }
    }

}
