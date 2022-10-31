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
    public AudioSource STS_18;
    public AudioSource STS_20;

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
    public string targetDimension1;
    public string targetDimension2;

    public static Stopwatch timer = new Stopwatch();

    int currentTrial = 0;
    int test = 0;
    private int exit;
    public int buff = 0;
    public int buff2 = 0;

    void Start()
    {
        exit = 0;
        buff2 = 0;
        buff = 0;
        test = 0;
        currentTrial = 1;
        currentTask(currentTrial);
    }

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
            }
        }
        if (currentTrial == 2)
        {
            if (!STS_20.isPlaying && !STS_15.isPlaying && buff == 2)
            {
                SpawnRight(right);
                STS_15.Play();
                buff = 3;
            }
            if (!STS_15.isPlaying && buff == 3)
            {
                EnableField();
                //buff = 4;
            }
        }
        if (currentTrial == 3)
        {
            if (!STS_18.isPlaying && !STS_15.isPlaying && buff == 4)
            {
                SpawnRight(right);
                STS_15.Play();
                buff = 5;
            }
            if (!STS_15.isPlaying && buff == 5)
            {
                EnableField();
                buff = 6;
            }
        }

        if (currentTrial == 4 && !STS_16.isPlaying && buff2 == 1)
        {
            continueButton.GetComponent<Button>().interactable = true;
            buff2 = 2;
            //STS_16.Play();
            // continueButton.gameObject.SetActive(true);
            // buff = 3;

        }
        /*
        if (currentTrial == 4 && !STS_16.isPlaying && buff == 3)
        {
            continueButton.interactable = true;
            buff = 4;
        } */
    }

    public void currentTask(int currentTrial)
    {
        if (currentTrial == 1)
        {
            STS_14.Play();
            left = one_Fairy_Red;
            middle = two_Fairy_Yellow;
            right = three_Flower_Yellow;
            targetDimension1 = "color";
            targetItem = middle;
            SpawnFirst(left, middle);
        }

        if (currentTrial == 2)
        {
            STS_20.Play();
            buff = 2;
            left = two_Flower_Blue;
            middle = three_Hat_Blue;
            right = two_Fairy_Red;
            targetDimension1 = "number";
            targetItem = left;
            SpawnFirst(left, middle);
        }
        if (currentTrial == 3)
        {
            STS_18.Play();
            buff = 4;
            left = one_Flower_Red;
            middle = one_Hat_Yellow;
            right = two_Hat_Blue;
            targetDimension1 = "shape";
            targetItem = middle;
            SpawnFirst(left, middle);
        }
        if (currentTrial == 4)
        {
            STS_16.Play();
            buff2 = 1;
            continueButton.gameObject.SetActive(true);
            continueButton.GetComponent<Button>().interactable = false;
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
            left.gameObject.GetComponent<Button>().transition = Selectable.Transition.None;
            left.gameObject.GetComponent<Button>().interactable = false;
            middle.gameObject.GetComponent<Button>().transition = Selectable.Transition.None;
            middle.gameObject.GetComponent<Button>().interactable = false;


        }
        else

        {
            test++;
            incorrect.SetActive(true);
            StartCoroutine(incorrectDisappear());
        }

        if (cresp == 0 && test == 1)
        {
            WriteInDataSaver(currentTrial, left.name.ToString(), middle.name.ToString(), right.name.ToString(), targetItem.name.ToString(), timer.ElapsedMilliseconds, cresp, targetDimension1, targetDimension2);
        }

        if (cresp == 1 && test == 0)
        {
            test = 0;
            WriteInDataSaver(currentTrial, left.name.ToString(), middle.name.ToString(), right.name.ToString(), targetItem.name.ToString(), timer.ElapsedMilliseconds, cresp, targetDimension1, targetDimension2);
            currentTrial++;
            StartCoroutine(DespawnObject());
        }

        if (cresp == 1 && test >= 1)
        {
            test = 0;
            currentTrial++;
            StartCoroutine(DespawnObject());
        }
        timer.Reset();
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
        timer.Start();
    }

    IEnumerator incorrectDisappear()
    {
        yield return new WaitForSeconds(1f);
        incorrect.SetActive(false);
    }

    void WriteInDataSaver(int currentTrial, string left, string middle, string right, string targetItem, double reaction, int CRESP, string targetDimension1, string targetDimension2)
    {
        CSDataSaver.MeasurePractice(currentTrial, left, middle, right, targetItem, reaction, CRESP, targetDimension1, "0");
        timer.Start();
        timer.Reset();
    }
    public void ExitButton()
    {
        exit++;
        if (exit == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        }
    }

}
