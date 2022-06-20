using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CSPlay : MonoBehaviour
{

    public GameObject one_Fairy_Blue;
    public GameObject one_Fairy_Red;
    public GameObject one_Fairy_White;
    public GameObject one_Fairy_Yellow;

    public GameObject two_Fairy_Blue;
    public GameObject two_Fairy_Red;
    public GameObject two_Fairy_Yellow;

    public GameObject three_Fairy_Blue;
    public GameObject three_Fairy_Red;
    public GameObject three_Fairy_Yellow;

    public GameObject one_Flower_Blue;
    public GameObject one_Flower_Red;
    public GameObject one_Flower_White;
    public GameObject one_Flower_Yellow;

    public GameObject two_Flower_Blue;
    public GameObject two_Flower_Red;
    public GameObject two_Flower_White;
    public GameObject two_Flower_Yellow;

    public GameObject three_Flower_Blue;
    public GameObject three_Flower_Red;
    public GameObject three_Flower_White;
    public GameObject three_Flower_Yellow;

    public GameObject one_Hat_Blue;
    public GameObject one_Hat_Red;
    public GameObject one_Hat_White;
    public GameObject one_Hat_Yellow;

    public GameObject two_Hat_Blue;
    public GameObject two_Hat_Red;
    public GameObject two_Hat_Yellow;

    public GameObject three_Hat_Blue;
    public GameObject three_Hat_Red;
    public GameObject three_Hat_Yellow;

    private GameObject left;
    private GameObject right;
    private GameObject middle;

    private GameObject targetItem;
    private GameObject clickedItem;

    int currentTrial = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentTrial = 0;
        currentTask(currentTrial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void currentTask(int currentTrial)
    {
        if (currentTrial == 0)
        {
            left = two_Flower_Red;
            middle = three_Hat_Red;
            right = one_Hat_Blue;
            targetItem = middle;
            SpawnFunction(left, middle, right);
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

        if (targetItem == clicked)
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
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
        currentTask(currentTrial);
    }
}
