using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class CSPractice : MonoBehaviour
{
    public AudioSource STS_14;
    public AudioSource STS_15;
    public AudioSource STS_16;

    public Button continueButton;
    public Button redoButton;
    public TextMesh continueText;

    public GameObject correct;
    public GameObject incorrect;

    //Practice Trial 1
    public GameObject one_Fairy_Red;
    public GameObject two_Fairy_Yellow;
    public GameObject three_Flower_Yellow;

    //Practice Trial 2
    public GameObject two_Flower_Blue;
    public GameObject three_Hat_Blue;
    public GameObject two_Fairy_Red;

    //Practice Trial 3
    public GameObject one_Flower_Red;
    public GameObject one_Hat_Yellow;
    public GameObject two_Hat_Blue;


    private GameObject left;
    private GameObject right;
    private GameObject middle;

    private GameObject targetItem;
    private GameObject clickedItem;

    public static Stopwatch timer = new Stopwatch();

    int currentTrial = 0;
    int test = 0;

    int buff = 0;

    void Start()
    {
        test = 0;
        currentTrial = 1;
        STS_14.Play();
        currentTask(currentTrial);
        
        
    }

    [System.Obsolete]
    void Update()
    {
        if (currentTrial == 1)
        {
            if (!STS_14.isPlaying && !STS_15.isPlaying && buff == 0)
            {
                SpawnRight(right);
                STS_15.Play();
                buff = 1;
            }
            if (!STS_15.isPlaying && buff == 1)
            {
                EnableField();
                timer.Reset();
                buff = 2;
            }
        }

        if (currentTrial == 4 && !STS_16.isPlaying && buff == 2 && correct.active == false)
        {
            STS_16.Play();
            continueButton.gameObject.SetActive(true);
            buff = 3;
            
        }
        if (currentTrial == 4 && !STS_16.isPlaying && buff == 3)
        {
            continueButton.interactable = true;
            buff = 4;
        }
    }
    
    public void currentTask(int currentTrial)
    {
        if(currentTrial == 1)
        {
            left = one_Fairy_Red;
            middle = two_Fairy_Yellow;
            right = three_Flower_Yellow;
            targetItem = middle;
            SpawnFirst(left, middle);
        }

        if (currentTrial == 2)
        {
            left = two_Flower_Blue;
            middle = three_Hat_Blue;
            right = two_Fairy_Red;
            targetItem = left;
            SpawnFunction(left, middle, right);
        }
        if (currentTrial == 3)
        {
            left = one_Flower_Red;
            middle = one_Hat_Yellow;
            right = two_Hat_Blue;
            targetItem = middle;
            SpawnFunction(left, middle, right);
        }

       
    }

    void SpawnFirst(GameObject left, GameObject middle)
    {
        SpawnLeft(left);
        SpawnMiddle(middle);
        DisableField();
    }

    void SpawnFunction(GameObject left, GameObject middle, GameObject right)
    {
        SpawnLeft(left);
        SpawnMiddle(middle);
        DisableField();
        StartCoroutine(Wait(right));
    }

    void SpawnLeft(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-200, 0, 0);
        item.SetActive(true);
    }

    void SpawnMiddle(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        item.SetActive(true);
    }

    void SpawnRight(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(200, 0, 0);
        item.SetActive(true);
        item.GetComponent<Button>().transition = Selectable.Transition.None;
        item.GetComponent<Button>().interactable = false;
        
    }

    IEnumerator Wait(GameObject right)
    { 
        yield return new WaitForSecondsRealtime(1f);
        SpawnRight(right);
        EnableField();
        timer.Start();
    }

    public void Compare(GameObject clicked)
    {
        Debug.Log(targetItem.name);
        Debug.Log(clicked.name);
        int cresp = 0;
        incorrect.SetActive(false);
        correct.SetActive(false);
        if (targetItem == clicked)
        {
            
            cresp = 1;
            
            correct.SetActive(true);
            
        }
        else
            
        {
            test++;
            incorrect.SetActive(true);
            StartCoroutine(incorrectDisappear());
        }

        if(cresp == 0 && test ==1)
        {
            WriteInDataSaver(currentTrial, left.name.ToString(), middle.name.ToString(), right.name.ToString(), targetItem.name.ToString(), timer.ElapsedMilliseconds, cresp);
        }

        if (cresp == 1 && test == 0)
        {
            test = 0;
            WriteInDataSaver(currentTrial, left.name.ToString(), middle.name.ToString(), right.name.ToString(), targetItem.name.ToString(), timer.ElapsedMilliseconds, cresp);
            currentTrial++;
            StartCoroutine(DespawnObject());
        }

        if (cresp == 1 && test >= 1)
        {
            test = 0;
            currentTrial++;
            StartCoroutine(DespawnObject());
        }
    }

    IEnumerator DespawnObject()
    {
        yield return new WaitForSeconds(1f);
        right.SetActive(false);
        middle.SetActive(false);
        left.SetActive(false);
        correct.SetActive(false);
        incorrect.SetActive(false);
        currentTask(currentTrial);
    }

    public void repeatPractice()
    {
        CSDataSaver.practice.Clear();
        redoButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        continueText.gameObject.SetActive(false);
        currentTrial = 1;
        currentTask(currentTrial);
    }

    void DisableField()
    {
        left.GetComponent<Button>().enabled = false;
        middle.GetComponent<Button>().enabled = false;
    }

    void EnableField()
    {
        left.GetComponent<Button>().enabled = true;
        middle.GetComponent<Button>().enabled = true;
    }

    IEnumerator incorrectDisappear()
    {
        yield return new WaitForSeconds(1f);
        incorrect.SetActive(false);
    }

    void WriteInDataSaver(int currentTrial, string left, string middle, string right, string targetItem, double reaction, int CRESP)
    {
        CSDataSaver.MeasurePractice(currentTrial, left, middle, right, targetItem, reaction, CRESP);
        timer.Reset();
    }
}
