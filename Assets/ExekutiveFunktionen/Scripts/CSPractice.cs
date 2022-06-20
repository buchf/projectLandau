using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CSPractice : MonoBehaviour
{

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

    int currentTrial = 0;

    void Start()
    {
        currentTrial = 0;
        currentTask(currentTrial);
        
        
    }

    void Update()
    {
        
    }

    void currentTask(int currentTrial)
    {
        if(currentTrial == 0)
        {
            left = one_Fairy_Red;
            middle = two_Fairy_Yellow;
            right = three_Flower_Yellow;
            targetItem = middle;
            SpawnFunction(left, middle, right);
        }

        if (currentTrial == 1)
        {
            left = two_Flower_Blue;
            middle = three_Hat_Blue;
            right = two_Fairy_Red;
            targetItem = left;
            SpawnFunction(left, middle, right);
        }
        if (currentTrial == 2)
        {
            left = one_Flower_Red;
            middle = one_Hat_Yellow;
            right = two_Hat_Blue;
            targetItem = middle;
            SpawnFunction(left, middle, right);
        }

        if(currentTrial == 3)
        {
            continueButton.gameObject.SetActive(true);
            continueText.gameObject.SetActive(true);
            redoButton.gameObject.SetActive(true);
        }
    }
    void SpawnFunction(GameObject left, GameObject middle, GameObject right)
    {
        SpawnLeft(left);
        SpawnMiddle(middle);
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
    }

    public void Compare(GameObject clicked)
    {
        Debug.Log(targetItem.name);
        Debug.Log(clicked.name);

        if(targetItem == clicked)
        {
            Debug.Log("true");
            correct.SetActive(true);
        }
        else
        {
            incorrect.SetActive(true);
        }
        currentTrial++;
        StartCoroutine(DespawnObject()); 
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
        redoButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        continueText.gameObject.SetActive(false);
        currentTrial = 0;
        currentTask(currentTrial);
    }
}
