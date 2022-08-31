using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class CSPlay : MonoBehaviour
{

    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();

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

    public static int currentTrial = 1;
    public static int blockNummer = 3;

    public TextMesh practiceText;
    public Button button;

    public static int correctResponse = 0;
    public static Stopwatch timer = new Stopwatch();

    private int buff = 0;

    // Start is called before the first frame update
    void Start()
    {
        buff = 0;
        
        currentTask(currentTrial);
    }

    private void Update()
    {
        if (currentTrial < 19 && blockNummer == 3)
        {
            if (!audioFiles[currentTrial].isPlaying && buff == 0)
            {
                SpawnRight(right);
                buff++;
            }
        }
        
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
        if (currentTrial == 19 && blockNummer == 3)
        {
            audioFiles[currentTrial].Play();
            practiceText.gameObject.SetActive(true);
            button.gameObject.SetActive(true);

           // SpawnFunction(three_Flower_Yellow, one_Flower_Red, two_Fairy_Red);
            //targetItem = one_Flower_Red;
        }
        
        if (currentTrial == 19 && blockNummer == 4)
        {
            SpawnFunctionTwo(two_Fairy_Yellow, one_Fairy_Red, two_Hat_Blue);
            targetItem = two_Fairy_Yellow;
        }
        if (currentTrial == 20)
        {

            SpawnFunctionTwo(two_Hat_Yellow, three_Fairy_Yellow, one_Fairy_Red);
            targetItem = three_Fairy_Yellow;
        }
        if (currentTrial == 21)
        {
            SpawnFunctionTwo(three_Hat_Red, one_Hat_Blue, three_Fairy_Yellow);
            targetItem = three_Hat_Red;
        }
        if (currentTrial == 22)
        {
            SpawnFunctionTwo(two_Fairy_Blue, two_Flower_Red, one_Hat_Blue);
            targetItem = two_Fairy_Blue;
        }
        if (currentTrial == 23)
        {
            SpawnFunctionTwo(two_Flower_Yellow, two_Fairy_Red, one_Hat_Yellow);
            targetItem = two_Flower_Yellow;
        }
        if (currentTrial == 24)
        {
            SpawnFunctionTwo(one_Flower_Red, two_Flower_Yellow, one_Fairy_Blue);
            targetItem = one_Flower_Red;
        }
        if (currentTrial == 25)
        {
            SpawnFunctionTwo(one_Fairy_Red, one_Flower_Yellow, two_Hat_Yellow);
            targetItem = one_Flower_Yellow;
        }
        if (currentTrial == 26)
        {
            SpawnFunctionTwo(two_Hat_Blue, one_Flower_Blue, three_Hat_Yellow);
            targetItem = one_Flower_Blue;
        }
        if (currentTrial == 27)
        {
            SpawnFunctionTwo(three_Flower_Red, two_Hat_Red, one_Hat_Yellow);
            targetItem = two_Hat_Red;
        }
        if(currentTrial == 28)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
    void SpawnFunction(GameObject leftCard, GameObject middleCard, GameObject rightCard)
    {
        audioFiles[currentTrial].Play();
        left = leftCard;
        middle = middleCard;
        right = rightCard;
        SpawnLeft(left);
        SpawnMiddle(middle);
        DisableField();
        //StartCoroutine(Wait(right));
    }

    void SpawnFunctionTwo(GameObject leftCard, GameObject middleCard, GameObject rightCard)
    {
        left = leftCard;
        middle = middleCard;
        right = rightCard;
        SpawnLeft(left);
        SpawnMiddle(middle);
        SpawnRightTwo(right);
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
        EnableField();
        Debug.Log("timer Start");
        timer.Start();
    }
    void SpawnRightTwo(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(200, 0, 0);
        item.SetActive(true);
    }
    IEnumerator Wait(GameObject right)
    {
        yield return new WaitForSecondsRealtime(1f);
        SpawnRight(right);
                
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
            correctResponse++;
        }
        else
        {
            cresp = 0;
        }
        WriteInDataSaver(currentTrial, left.name.ToString(), middle.name.ToString(), right.name.ToString(), targetItem.name.ToString(), timer.ElapsedMilliseconds, cresp);
        
        activateObject(right);
        currentTrial++;
        DespawnObject();
        
    }

    void DespawnObject()
    { 
        right.SetActive(false);
        middle.SetActive(false);
        left.SetActive(false);
        buff = 0;
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
        if (blockNummer == 3) CSDataSaver.MeasureTest(currentTrial, left, middle, right, targetItem, reaction, CRESP);
        if (blockNummer == 4) CSDataSaver.MeasureTestTwo(currentTrial, left, middle, right, targetItem, reaction, CRESP);
        timer.Reset();
    }

    public void PracticePhaseTwo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
