using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class CSIntroduction : MonoBehaviour
{

    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();

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

    private GameObject left;
    private GameObject right;
    private GameObject middle;

    private int zaehler;

    // Start is called before the first frame update
    void Start()
    {
        left = one_fairy_blue;
        middle = one_fairy_yellow;
        right = one_fairy_red;

        zaehler = 0;
        audioFiles[zaehler].Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioFiles[zaehler].isPlaying && zaehler == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (audioFiles[zaehler].isPlaying)

        {
            left.GetComponent<Button>().enabled = false;
            middle.GetComponent<Button>().enabled = false;
            right.GetComponent<Button>().enabled = false;
        }
        else
        {
            left.GetComponent<Button>().enabled = true;
            middle.GetComponent<Button>().enabled = true;
            right.GetComponent<Button>().enabled = true;
        }
    }

    public void IncreaseCounter()
    {
        zaehler++;

        if (zaehler == 1)
        {
            // rot.gameObject.SetActive(false);
            audioFiles[zaehler].Play();
           // blau.gameObject.SetActive(true);

        }
        if (zaehler == 2)
        {
            //blau.gameObject.SetActive(false);
            audioFiles[zaehler].Play();
            //gelb.gameObject.SetActive(true);
        }
        if (zaehler == 3)
        {
            left = three_flower;
            middle = one_flower;
            right = two_flower;
            audioFiles[zaehler].Play();
            one_fairy_yellow.SetActive(false);
            one_fairy_red.SetActive(false);
            one_fairy_blue.SetActive(false);
            one_flower.SetActive(true);
            two_flower.SetActive(true);
            three_flower.SetActive(true);  
        }

        if (zaehler == 4)
        {
            audioFiles[zaehler].Play();  
        }
        if (zaehler == 5)
        {
            audioFiles[zaehler].Play();
        }
        if (zaehler == 6)
        {
            left = one_hat_white;
            middle = one_fairy_white;
            right = one_flower_white;
            audioFiles[zaehler].Play();
            one_flower.SetActive(false);
            two_flower.SetActive(false);
            three_flower.SetActive(false);
            one_hat_white.SetActive(true);
            one_fairy_white.SetActive(true);
            one_flower_white.SetActive(true);
        }
        if (zaehler == 7)
        {
            audioFiles[zaehler].Play();
        }

        if (zaehler == 8)
        {
            audioFiles[zaehler].Play();
        }

        if (zaehler == 9)
        {
            audioFiles[zaehler].Play();
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
