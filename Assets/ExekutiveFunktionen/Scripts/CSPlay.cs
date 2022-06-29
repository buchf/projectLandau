using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

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

    public static Stopwatch timer = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {
        currentTrial = 1;
        currentTask(currentTrial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void currentTask(int currentTrial)
    {
        if (currentTrial == 1)
        {
            SpawnFunction(two_Flower_Red, three_Hat_Red, one_Hat_Blue);
            targetItem = three_Hat_Red;
        }
        if (currentTrial == 2)
        {
            SpawnFunction(two_Fairy_Yellow, two_Hat_Blue, three_Flower_Yellow);
            targetItem = two_Fairy_Yellow;
        }
        if (currentTrial == 3)
        {
            SpawnFunction(one_Fairy_Yellow, two_Flower_Yellow, three_Fairy_Blue);
            targetItem = one_Fairy_Yellow;
        }
        if (currentTrial == 4)
        {
            SpawnFunction(two_Fairy_Yellow, three_Flower_Yellow, one_Flower_Red);
            targetItem = three_Flower_Yellow;
        }
        if (currentTrial == 5)
        {
            SpawnFunction(one_Fairy_Yellow, two_Fairy_Blue, two_Flower_Red);
            targetItem = two_Fairy_Blue;
        }
        if (currentTrial == 6)
        {
            SpawnFunction(three_Flower_Blue, one_Flower_Yellow, three_Fairy_Red);
            targetItem = three_Flower_Blue;
        }
        if (currentTrial == 7)
        {
            SpawnFunction(two_Fairy_Blue, three_Flower_Blue, one_Flower_Yellow);
            targetItem = three_Flower_Blue;
        }
        if (currentTrial == 8)
        {
            SpawnFunction(two_Hat_Red, three_Hat_Yellow, two_Flower_Blue);
            targetItem = two_Hat_Red;
        }
        if (currentTrial == 9)
        {
            SpawnFunction(one_Fairy_Blue, two_Flower_Blue, three_Fairy_Red);
            targetItem = one_Fairy_Blue;
        }
        if (currentTrial == 10)
        {
            SpawnFunction(one_Fairy_Blue, one_Hat_Red, three_Flower_Red);
            targetItem = one_Hat_Red;
        }
        if (currentTrial == 11)
        {
            SpawnFunction(one_Flower_Blue, three_Flower_Yellow, one_Hat_Red);
            targetItem = one_Flower_Blue;
        }
        if (currentTrial == 12)
        {
            SpawnFunction(two_Flower_Blue, two_Hat_Red, three_Fairy_Blue);
            targetItem = two_Flower_Blue;
        }
        if (currentTrial == 13)
        {
            SpawnFunction(three_Hat_Red, three_Fairy_Yellow, one_Flower_Red);
            targetItem = three_Hat_Red;
        }
        if (currentTrial == 14)
        {
            SpawnFunction(two_Fairy_Red, three_Fairy_Blue, two_Hat_Yellow);
            targetItem = two_Fairy_Red;
        }
        if (currentTrial == 15)
        {
            SpawnFunction(three_Fairy_Red, three_Hat_Blue, one_Flower_Blue);
            targetItem = three_Hat_Blue;
        }
        if (currentTrial == 16)
        {
            SpawnFunction(one_Hat_Red, two_Fairy_Red, three_Hat_Blue);
            targetItem = one_Hat_Red;
        }
        if (currentTrial == 17)
        {
            SpawnFunction(three_Hat_Blue, one_Hat_Yellow, three_Flower_Red);
            targetItem = three_Hat_Blue;
        }
        if (currentTrial == 18)
        {
            SpawnFunction(three_Flower_Blue, three_Hat_Yellow, one_Fairy_Yellow);
            targetItem = three_Hat_Yellow;
        }
        if (currentTrial == 19)
        {
            SpawnFunction(three_Flower_Yellow, one_Flower_Red, two_Fairy_Red);
            targetItem = one_Flower_Red;
        }
        if (currentTrial == 20)
        {
            SpawnFunction(two_Hat_Yellow, two_Flower_Blue, one_Hat_Red);
            targetItem = two_Hat_Yellow;
        }
        if (currentTrial == 21)
        {
            SpawnFunction(three_Fairy_Blue, two_Flower_Yellow, three_Hat_Yellow);
            targetItem = three_Fairy_Blue;
        }
        if (currentTrial == 22)
        {
            SpawnFunction(two_Fairy_Yellow, one_Fairy_Red, two_Hat_Blue);
            targetItem = two_Fairy_Yellow;
        }
        if (currentTrial == 23)
        {
            SpawnFunction(two_Hat_Yellow, three_Fairy_Yellow, one_Fairy_Red);
            targetItem = three_Fairy_Yellow;
        }
        if (currentTrial == 24)
        {
            SpawnFunction(three_Hat_Red, one_Hat_Red, three_Fairy_Yellow);
            targetItem = three_Hat_Red;
        }
        if (currentTrial == 25)
        {
            SpawnFunction(two_Fairy_Blue, two_Flower_Red, one_Hat_Blue);
            targetItem = two_Fairy_Blue;
        }
        if (currentTrial == 26)
        {
            SpawnFunction(two_Flower_Yellow, two_Fairy_Red, one_Hat_Yellow);
            targetItem = two_Flower_Yellow;
        }
        if (currentTrial == 27)
        {
            SpawnFunction(one_Flower_Red, two_Flower_Yellow, one_Fairy_Blue);
            targetItem = one_Flower_Red;
        }
        if (currentTrial == 28)
        {
            SpawnFunction(one_Fairy_Red, one_Flower_Yellow, two_Hat_Yellow);
            targetItem = one_Flower_Yellow;
        }
        if (currentTrial == 29)
        {
            SpawnFunction(two_Hat_Blue, one_Flower_Blue, three_Hat_Yellow);
            targetItem = two_Hat_Blue;
        }
        if (currentTrial == 30)
        {
            SpawnFunction(three_Flower_Red, two_Hat_Red, one_Hat_Yellow);
            targetItem = two_Hat_Red;
        }
        if(currentTrial == 31)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    void SpawnFunction(GameObject leftCard, GameObject middleCard, GameObject rightCard)
    {
        left = leftCard;
        middle = middleCard;
        right = rightCard;
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
        Debug.Log("timer Start");
        timer.Start();
        
    }

    void activateObject(GameObject item)
    {
        item.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
        item.GetComponent<Button>().interactable = true;

    }
    public void Compare(GameObject clicked)
    {
        int cresp = 0;
        timer.Stop();
        Debug.Log(timer.ElapsedMilliseconds.ToString());
      //  Debug.Log(targetItem.name);
       // Debug.Log(clicked.name);

        if (targetItem == clicked)
        {
            cresp = 1;
        }
        else
        {
            cresp = 0;
        }
        WriteInDataSaver(currentTrial, left.name.ToString(), middle.name.ToString(), right.name.ToString(), targetItem.name.ToString(), timer.ElapsedMilliseconds, cresp);
        
        activateObject(right);
        currentTrial++;
        StartCoroutine(DespawnObject());
    }

    IEnumerator DespawnObject()
    {
        
        right.SetActive(false);
        middle.SetActive(false);
        left.SetActive(false);
        yield return new WaitForSeconds(1f);
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

    void WriteInDataSaver(int currentTrial, string left, string middle, string right, string targetItem, double reaction, int CRESP )
    {
        CSDataSaver.MeasureTest(currentTrial, left, middle, right, targetItem, reaction, CRESP);
        timer.Reset();
    }
}
