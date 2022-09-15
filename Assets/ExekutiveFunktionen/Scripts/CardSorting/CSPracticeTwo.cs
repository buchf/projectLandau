using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class CSPracticeTwo : MonoBehaviour
{

    


    public Button continueButton;
    public TextMesh continueText;

    //Introduction
    public AudioSource STS_27;
    public AudioSource STS_28;
    public AudioSource STS_29;
    public AudioSource STS_16;

    public GameObject one_Fairy_Blue;


    //Practice Trial 4
    public GameObject three_Flower_Yellow;
    public GameObject one_Flower_Red;
    public GameObject two_Fairy_Red;

    //Practice Trial 5
    public GameObject two_Hat_Yellow;
    public GameObject two_Flower_Blue;
    public GameObject one_Hat_Red;

    //Practice Trial 6
    public GameObject three_Fairy_Blue;
    public GameObject two_Flower_Yellow;
    public GameObject three_Hat_Yellow;


    public GameObject correct;
    public GameObject incorrect;

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
        PhaseTwoIntro();
        currentTrial = 4;
        //currentTask(currentTrial);
    }

    private void Update()
    {
        if(!STS_27.isPlaying && buff == 0)
        {
            STS_28.Play();
            buff++;
        }
        if(!STS_28.isPlaying && buff == 1)
        {
            left.GetComponent<Button>().interactable = true;
            left.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            middle.GetComponent<Button>().interactable = true;
            middle.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            right.GetComponent<Button>().interactable = true;
            right.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
            left.SetActive(false);
            right.SetActive(false);
            middle.SetActive(false);
            currentTask(currentTrial);
            
            buff++;
        }
        if (!STS_29.isPlaying && buff >= 2)
        {
            timer.Reset();
            right.GetComponent<Button>().interactable = true;
            middle.GetComponent<Button>().interactable = true;
            left.GetComponent<Button>().interactable = true;
            timer.Start();
            buff++;
        }
    }
    void PhaseTwoIntro()
    {
        STS_27.Play();
        left = two_Hat_Yellow;
        middle = one_Fairy_Blue;
        right = one_Hat_Red;
        left.GetComponent<Button>().interactable = false;
        left.GetComponent<Button>().transition = Selectable.Transition.None;
        middle.GetComponent<Button>().interactable = false;
        middle.GetComponent<Button>().transition = Selectable.Transition.None;
        right.GetComponent<Button>().interactable = false;
        right.GetComponent<Button>().transition = Selectable.Transition.None;
        SpawnFunction(left, middle, right);
        StartCoroutine(Highlight(right));
    }

    IEnumerator Highlight(GameObject item)
    {
        yield return new WaitForSeconds(8f);
        item.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
    }

    public void currentTask(int currentTrial)
    {
        if (currentTrial == 4)
        {
            left = three_Flower_Yellow;
            middle = one_Flower_Red;
            right = two_Fairy_Red;
            targetItem = middle;
            STS_29.Play();
            SpawnFunction(left, middle, right);
            left.GetComponent<Button>().interactable = false;
            middle.GetComponent<Button>().interactable = false;
            right.GetComponent<Button>().interactable = false;
            
        }

        if (currentTrial == 5)
        {
            left = two_Hat_Yellow;
            middle = two_Flower_Blue;
            right = one_Hat_Red;
            targetItem = left;
            STS_29.Play();
            SpawnFunction(left, middle, right);
            left.GetComponent<Button>().interactable = false;
            middle.GetComponent<Button>().interactable = false;
            right.GetComponent<Button>().interactable = false;
        }
        if (currentTrial == 6)
        {
            left = three_Fairy_Blue;
            middle = two_Flower_Yellow;
            right = three_Hat_Yellow;
            targetItem = right;
            STS_29.Play();
            SpawnFunction(left, middle, right);
            left.GetComponent<Button>().interactable = false;
            middle.GetComponent<Button>().interactable = false;
            right.GetComponent<Button>().interactable = false;
        }

        if (currentTrial == 7)
        {
            STS_16.Play(); // STS_16.Play();
            continueButton.gameObject.SetActive(true);
            continueText.gameObject.SetActive(true);
        }
    }


    public void StartPhaseTwo()
    {
        //SceneSwitch auf alte scene mit task nummer 19
        CSPlay.currentTrial = 19;
        CSPlay.blockNummer = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SpawnFunction(GameObject left, GameObject middle, GameObject right)
    {
        SpawnLeft(left);
        SpawnMiddle(middle);
        SpawnRight(right);
        timer.Start();
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
        }

        if (cresp == 0 && test == 1)
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

    void WriteInDataSaver(int currentTrial, string left, string middle, string right, string targetItem, double reaction, int CRESP)
    {
        CSDataSaver.MeasurePracticeTwo(currentTrial, left, middle, right, targetItem, reaction, CRESP);
        timer.Reset();
    }
}
