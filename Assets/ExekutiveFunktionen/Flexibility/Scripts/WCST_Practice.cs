using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class WCST_Practice : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<Button> button;
    [SerializeField] private List<GameObject> keyUI; 
    [SerializeField] private GameObject fixCross;
    [SerializeField] private GameObject wizard;
    public AudioSource MCST_09mp3;
    public AudioSource MCST_10mp3;


    [SerializeField] private GameObject correctStar;
    [SerializeField] private GameObject incorrectStar;

    public List<GameObject> cardList = new List<GameObject>();
    public GameObject cardBorder;
    //public GameObject MCWST_06;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private List<int> usedRules = new List<int>();

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;

    private int position = 0;

    public int secondTry = 0;
    int buff = 0;
    bool preservationError;

    public int sortCategory = 0;
    public int correctChain = 0;

    public List<Card> keys = new List<Card>();
    public List<int> correctResponse = new List<int>();
    public int clickedResponse;
    int trialType = 0;
    int accuracy = 0;

    public static Stopwatch timer = new Stopwatch();

    // Start is called before the first frame update
    void Start()
    {

        
    }

    public void GetClickedCard(GameObject key)
    {
        clickedResponse = int.Parse((key.ToString().Substring(3, 1)));
        Debug.Log(clickedResponse);

    }
    void GetCorrectResponse()
    {
        correctResponse.Clear();
        if (keys[0].color == currentColor || keys[0].number == currentNum || keys[0].shape == currentShape)
        {
            correctResponse.Add(1);
        }
        if (keys[1].color == currentColor || keys[1].number == currentNum || keys[1].shape == currentShape)
        {
            correctResponse.Add(2);
        }
        if (keys[2].color == currentColor || keys[2].number == currentNum || keys[2].shape == currentShape)
        {
            correctResponse.Add(3);
        }
        if (keys[3].color == currentColor || keys[3].number == currentNum || keys[3].shape == currentShape)
        {
            correctResponse.Add(4);
        }

        Debug.Log(correctResponse[0] +","+ correctResponse[1] +"," + correctResponse[2]);
    }
    // Update is called once per frame
    void Update()
    { 
        /*
        if (!MCST_09mp3.isPlaying && correctChain == 6)
        {
            wizard.SetActive(false);
            EnabelKeyUI();
            //Hier dann next card machen mit 
            // rule switch nicht vergessen. momentaner wert wird in eine liste abgespeichert.
            // Funktion schreiben welche die geklickte variable mit der kompletten liste zu vergleichen damit eine regel nicht zweimal vorkommt -> perservation error.
        }
            
        */
        
        if(!MCST_10mp3.isPlaying && buff == 1)
        {
            buff++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public void DisablePractice()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(false);
            
        }
        current.SetActive(false);   
        fixCross.SetActive(true);
        cardBorder.SetActive(false);
        //StartCoroutine(Wait());
    }
    public void DisableUI()
    {
        text.gameObject.SetActive(false);
        foreach(Button i in button){
            i.gameObject.SetActive(false);
        }
        EnabelKeyUI();
    }

    private void EnabelKeyUI()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(true);
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.None;
                obj.GetComponent<Button>().interactable = false;
            }
        }
        fixCross.SetActive(true);
        StartCoroutine(Wait());
        
    }
    public void BackToIntro()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
    }

    private void SetCurrent(GameObject currentObj)
    {
        cardBorder.SetActive(true);
        current = currentObj;
        current.SetActive(true);
        
        currentColor = current.GetComponent<CardDisplay>().card.color;
        currentNum = current.GetComponent<CardDisplay>().card.number;
        currentShape = current.GetComponent<CardDisplay>().card.shape;
        timer.Reset();
        timer.Start();
        GetCorrectResponse();
    }

    public void CardClick(GameObject clickedObject)
    {
        timer.Stop();
        GetClickedCard(clickedObject);

        clicked = clickedObject;
        clickedColor = clicked.GetComponent<CardDisplay>().card.color;
        clickedNum = clicked.GetComponent<CardDisplay>().card.number;
        clickedShape = clicked.GetComponent<CardDisplay>().card.shape;

        if (correctChain == 0 && sortCategory == 0)
        {
           Debug.Log("first compare");
           FirstCompareCards();
        }
        else
        {
            CompareCards();
        }

        //schwierig, chain = 0 first automatisch ausloest und chain > 0 weitergeht, wenn chain gebreakt wird dann wird automatisch correctchain 0 ausgeloest
        
    }

    private void CompareCards()
    {
        trialType = 1;
        //Sorting category (color = 1, shape = 2, number = 3)
        switch (sortCategory)
        {
            case 1:
                CompareColor();
                break;
            case 2:
                CompareShape();
                break;
            case 3:
                CompareNum();
                break;
        }
    }

    private void CompareColor()
    {  
        if(clickedColor == currentColor)
        {
            accuracy = 1;
            StartCoroutine(CorrectAnimation());
            correctChain++;
        }
        else
        {
            accuracy = 0;
            StartCoroutine(IncorrectAnimation());
            correctChain = 0;
        }
    }

    private void CompareShape()
    { 
        if (clickedShape == currentShape)
        {
            accuracy = 1;
            StartCoroutine(CorrectAnimation());
            correctChain++;
        }
        else
        {
            accuracy = 0;
            StartCoroutine(IncorrectAnimation());
            correctChain = 0;
        }
    }

    private void CompareNum()
    {
        if (clickedNum == currentNum)
        {
            accuracy = 1;
            StartCoroutine(CorrectAnimation());            
            correctChain++;
        }
        else
        {
            accuracy = 0;
            StartCoroutine(IncorrectAnimation());            
            correctChain = 0;
        }
    }

    private void FirstCompareCards()
    {

        //for schleife unten in die if abfrage da erst unten die sort category festgelegt wird        
        if (clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape)
        {
            if (clickedColor == currentColor) sortCategory = 1;
            if (clickedShape == currentShape) sortCategory = 2;
            if (clickedNum == currentNum) sortCategory = 3;
            
            Debug.Log("checkIfUsed: " + CheckIfUsed(sortCategory));
            if(preservationError == true)
            {
                sortCategory = 0;
                accuracy = 2;
                StartCoroutine(IncorrectAnimation());
            }
            else
            {
                trialType = 2;
                if (usedRules.Count == 0) trialType = 0;
                accuracy = 1;
                StartCoroutine(CorrectAnimation());
                correctChain++;
            }
        }
        else
        {
            StartCoroutine(IncorrectAnimation());
        }
    }

    private bool CheckIfUsed(int sortCategory)
    {
        preservationError = false;
        for (int i = 0; i < usedRules.Count; i++)
        {
            Debug.Log("usedRule[i] == " + usedRules[i]);
            if (usedRules[i] == sortCategory)
            {
                Debug.Log("PRESERVATION ERROR");
                preservationError = true;
            }
        }
        return preservationError;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        fixCross.SetActive(false);
        foreach (GameObject obj in keyUI)
        {
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
                obj.GetComponent<Button>().interactable = true;
            }
        }
        SetCurrent(cardList[position]);
    }

    private void NextCard()
    {
        cardBorder.SetActive(true);
        if (position < 12)
        {
            SetCurrent(cardList[position]);
        }
        
    }

    IEnumerator WizardAnimation()
    {
        DisableKeys();
        correctChain = 0;
        MCST_09mp3.Play();
        wizard.SetActive(true);
        usedRules.Add(sortCategory);
        Debug.Log("used rules count: " + usedRules.Count);
        yield return new WaitForSeconds(6f);
        sortCategory = 0;
        wizard.SetActive(false);
        EnableKeys();
        NextCard();
    }

    IEnumerator CorrectAnimation()
    {
        WriteInDataSaver(trialType, sortCategory, current.name, correctResponse[0], correctResponse[1], correctResponse[2], clickedResponse, timer.ElapsedMilliseconds, accuracy);
        correctStar.SetActive(true);
        cardBorder.SetActive(false);
        DisableKeys();
        yield return new WaitForSeconds(0.5f);
        correctStar.SetActive(false);
        current.SetActive(false);
        
        yield return new WaitForSeconds(1f);
        position++;
        secondTry = 0;
        if (correctChain == 6 && position  < 12)
        {
            StartCoroutine(WizardAnimation());
        }
        else
        {
            NextCard();
            EnableKeys();
        }
        if (position == 12)
        {
            DisablePractice();
            DisableKeys();
            MCST_10mp3.Play();
            buff = 1;
        }
    }

    IEnumerator IncorrectAnimation()
    {
        //WCST_Data.MeasurePractice(0, 1, position + 1, trialType, sortCategory, current.name, correctResponse[0], correctResponse[1], correctResponse[2], clickedResponse, 123, trialType);
        WriteInDataSaver(trialType,sortCategory,current.name, correctResponse[0], correctResponse[1], correctResponse[2],clickedResponse, timer.ElapsedMilliseconds, accuracy);
        incorrectStar.SetActive(true);
        cardBorder.SetActive(false);
        DisableKeys();
        yield return new WaitForSeconds(0.5f);
        incorrectStar.SetActive(false);
        current.SetActive(false);
        
        yield return new WaitForSeconds(1f);

        if (position == 12)
        {
            DisablePractice();
            DisableKeys();
            MCST_10mp3.Play();
            buff = 1;
        }
        if (secondTry == 0)
        {
            current.SetActive(true);
            cardBorder.SetActive(true);
            EnableKeys();
            timer.Reset();
            timer.Start();
            secondTry++;
        }
        else if (position < 12 && secondTry != 0)
        {
            secondTry = 0;
            position++;
            EnableKeys();
            NextCard();
        }


    }

    private void EnableKeys()
    {
        foreach (GameObject obj in keyUI)
        {
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.ColorTint;
                obj.GetComponent<Button>().interactable = true;
            }
        }
    }

    private void DisableKeys()
    {
        foreach (GameObject obj in keyUI)
        {
            if (obj.gameObject.GetComponent<Button>())
            {
                obj.GetComponent<Button>().transition = Selectable.Transition.None;
                obj.GetComponent<Button>().interactable = false;
            }
        }
    }

    //trialType,sortCategory,current.name, correctResponse[0], correctResponse[1], correctResponse[2],clickedResponse, 123, trialType
    void WriteInDataSaver(int trialType, int sortCat, string WCST, int respOne, int respTwo, int respThree, int CRESP, float timer, int acc)
    {
        //WCST_Data.MeasurePractice(0,1,position+1,trialType, sortCategory,current.name,correctResponse[0], correctResponse[1], correctResponse[2], clickedResponse, 123,trialType);
        WCST_Data.MeasurePractice(0, 1, position + 1, trialType, sortCat, WCST, respOne, respTwo, respThree, CRESP, timer, acc);
    }
}

