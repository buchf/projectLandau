using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TellMeOnceTrigger : MonoBehaviour
{
    public AudioSource Instruct;
    bool triggered = false;
    public float clickedTime = 0.0f;
    float timeForEffect = 1.0f;

    bool LocallySelecto = false;
    bool Clicko = false;
    bool IsTotallySelected = false;

    // Start is called before the first frame update
    void Start()
    {
        // Instruct = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicko && !triggered)
        {
            if (!LocallySelecto)
                clickedTime += Time.deltaTime;

            if (clickedTime > timeForEffect)
            {
                clickedTime = timeForEffect;
                LocallySelecto = true;
                IsTotallySelected = true;
                if (Instruct != null)
                {
                    Instruct.Play();
                    triggered = true;
                }
            }
        }

        if (LocallySelecto && !IsTotallySelected) // es wurde zu kurz gedrückt
            Deselecto();

        if (!Clicko && !LocallySelecto)
            clickedTime = 0.0f;


        
        
        if (triggered && !Instruct.isPlaying)
            Destroy(gameObject, 0.1f);
    }

    void InstructNow()
    {
        if (Instruct != null)
        {
            Instruct.Play();
            triggered = true;
        }
    }

        //

    public void OnMouseDown()
    {
        Clicko = true;
    }

    public void OnMouseUp()
    {
        Clicko = false;
    }

    public void Deselecto()
    {
        LocallySelecto = false;
    }
        //

}
