using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class CSPracticeTwo : MonoBehaviour
{
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


    void Start()
    {
        currentTrial = 4;
        currentTask(currentTrial);
    }

    public void currentTask(int currentTrial)
    {
        if (currentTrial == 4)
        {
            left = three_Flower_Yellow;
            middle = one_Flower_Red;
            right = two_Fairy_Red;
            targetItem = middle;
            SpawnFunction(left, middle, right);
        }

        if (currentTrial == 5)
        {
            left = two_Hat_Yellow;
            middle = two_Flower_Blue;
            right = one_Hat_Red;
            targetItem = left;
            SpawnFunction(left, middle, right);
        }
        if (currentTrial == 6)
        {
            left = three_Fairy_Blue;
            middle = two_Flower_Yellow;
            right = three_Hat_Yellow;
            targetItem = left;
            SpawnFunction(left, middle, right);
        }

        if (currentTrial == 7)
        {
            //SceneSwitch auf alte scene mit task nummer 19
            CSPlay.currentTrial = 19;
            CSPlay.blockNummer = 4;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
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
        item.GetComponent<Button>().transition = Selectable.Transition.None;
        item.GetComponent<Button>().interactable = false;
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
