using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSPractice : MonoBehaviour
{

    public TextMesh gelb;
    public TextMesh rot;
    public TextMesh blau;

    public TextMesh one_flower_text;
    public TextMesh two_flower_text;
    public TextMesh three_flower_text;

    public TextMesh einFee;
    public TextMesh zweiFee;
    public TextMesh dreiFee;


    public GameObject one_fairy_yellow;
    public GameObject one_fairy_red;
    public GameObject one_fairy_blue;

    public GameObject one_fairy_white;
    public GameObject one_flower_white;
    public GameObject one_hat_white;

    public GameObject one_flower;
    public GameObject two_flower;
    public GameObject three_flower;

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
        
        
    }

    public void IncreaseCounter()
    {
        zaehler++;

        if (zaehler == 1)
        {
           // rot.gameObject.SetActive(false);
            StartCoroutine(Wait(rot.gameObject, blau.gameObject));
           // blau.gameObject.SetActive(true);

        }
        if (zaehler == 2)
        {
            //blau.gameObject.SetActive(false);
            StartCoroutine(Wait(blau.gameObject, gelb.gameObject));
            //gelb.gameObject.SetActive(true);
        }
        if (zaehler == 3)
        {
            gelb.gameObject.SetActive(false);
            one_fairy_yellow.SetActive(false);
            one_fairy_red.SetActive(false);
            one_fairy_blue.SetActive(false);
            anzahlText.gameObject.SetActive(true);
            button.SetActive(true);
        }

        if (zaehler == 4)
        {
            button.SetActive(false);
            anzahlText.gameObject.SetActive(false);
            one_flower.SetActive(true);
            two_flower.SetActive(true);
            three_flower.SetActive(true);
            three_flower_text.gameObject.SetActive(true);
        }
        if (zaehler == 5)
        {
            //feeText.gameObject.SetActive(false);
            StartCoroutine(Wait(three_flower_text.gameObject, one_flower_text.gameObject));
            //sternText.gameObject.SetActive(true);
        }
        if (zaehler == 6)
        {
            StartCoroutine(Wait(one_flower_text.gameObject, two_flower_text.gameObject));
        }
        if (zaehler == 7)
        {
            two_flower_text.gameObject.SetActive(false);
            one_flower.SetActive(false);
            two_flower.SetActive(false);
            three_flower.SetActive(false);
            button.SetActive(true);
            inhaltText.gameObject.SetActive(true);
        }

        if (zaehler == 8)
        {
            one_hat_white.SetActive(true);
            one_fairy_white.SetActive(true);
            one_flower_white.SetActive(true);
            button.SetActive(false);
            inhaltText.gameObject.SetActive(false);
            einFee.gameObject.SetActive(true);
        }

        if (zaehler == 9)
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

    IEnumerator Wait(GameObject a, GameObject b)
    {
        a.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(1f);
        b.gameObject.SetActive(true);
        Debug.Log("test");
        
    }
}
