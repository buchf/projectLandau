using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSPractice : MonoBehaviour
{

    public TextMesh gelb;
    public TextMesh rot;
    public TextMesh blau;

    public TextMesh feeText;
    public TextMesh sternText;
    public TextMesh hutText;

    public TextMesh einFee;
    public TextMesh zweiFee;
    public TextMesh dreiFee;


    public GameObject gelbFee;
    public GameObject rotFee;
    public GameObject blauFee;

    public GameObject fee;
    public GameObject stern;
    public GameObject hut;

    public GameObject feeEinzel;
    public GameObject feeDoppelt;
    public GameObject feeDreifach;

    public TextMesh inhaltText;
    public TextMesh anzahlText;
    public GameObject button;
    
    int zaehler;

    // Start is called before the first frame update
    void Start()
    {
        zaehler = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(zaehler == 1)
        {
            rot.gameObject.SetActive(false);
            blau.gameObject.SetActive(true);

        }
        if (zaehler == 2)
        {
            blau.gameObject.SetActive(false);
            gelb.gameObject.SetActive(true);
        }
        if (zaehler == 3)
        {
            gelb.gameObject.SetActive(false);
            gelbFee.SetActive(false);
            rotFee.SetActive(false);
            blauFee.SetActive(false);
            inhaltText.gameObject.SetActive(true);
            button.SetActive(true);
        }

        if (zaehler == 4)
        {
            button.SetActive(false);
            inhaltText.gameObject.SetActive(false);
            fee.SetActive(true);
            stern.SetActive(true);
            hut.SetActive(true);
            feeText.gameObject.SetActive(true);
        }
        if(zaehler == 5)
        {
            feeText.gameObject.SetActive(false);
            sternText.gameObject.SetActive(true);
        }
        if(zaehler == 6)
        {
            sternText.gameObject.SetActive(false);
            hutText.gameObject.SetActive(true);
        }
        if(zaehler == 7)
        {
            hutText.gameObject.SetActive(false);
            fee.SetActive(false);
            stern.SetActive(false);
            hut.SetActive(false);
            button.SetActive(true);
            anzahlText.gameObject.SetActive(true);
        }

        if(zaehler == 8)
        {
            feeEinzel.SetActive(true);
            feeDoppelt.SetActive(true);
            feeDreifach.SetActive(true);
            button.SetActive(false);
            anzahlText.gameObject.SetActive(false);
            einFee.gameObject.SetActive(true);
        }

        if(zaehler == 9)
        {
            einFee.gameObject.SetActive(false);
            zweiFee.gameObject.SetActive(true);
        }

        if (zaehler == 10)
        {
            zweiFee.gameObject.SetActive(false);
            dreiFee.gameObject.SetActive(true);
        }

    }

    public void IncreaseCounter()
    {
        zaehler++;
    }

}
