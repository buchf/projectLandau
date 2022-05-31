using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public GameObject one_fairy_yellow;
    public GameObject one_fairy_red;
    public GameObject one_fairy_blue;

    public GameObject one_fairy_white;
    public GameObject one_flower_white;
    public GameObject one_hat_white;

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
            StartCoroutine(Wait());
            blau.gameObject.SetActive(true);

        }
        if (zaehler == 2)
        {
            blau.gameObject.SetActive(false);
            StartCoroutine(Wait());
            gelb.gameObject.SetActive(true);
        }
        if (zaehler == 3)
        {
            gelb.gameObject.SetActive(false);
            one_fairy_yellow.SetActive(false);
            one_fairy_red.SetActive(false);
            one_fairy_blue.SetActive(false);
            inhaltText.gameObject.SetActive(true);
            button.SetActive(true);
        }

        if (zaehler == 4)
        {
            button.SetActive(false);
            inhaltText.gameObject.SetActive(false);
            one_fairy_white.SetActive(true);
            one_flower_white.SetActive(true);
            one_hat_white.SetActive(true);
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
            one_fairy_white.SetActive(false);
            one_flower_white.SetActive(false);
            one_hat_white.SetActive(false);
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

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("test");
        
    }
}
