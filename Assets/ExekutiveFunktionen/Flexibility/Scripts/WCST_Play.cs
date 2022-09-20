using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class WCST_Play : MonoBehaviour
{
    //Basic UI
    public AudioSource MCST_12;
    public AudioSource MCST_11;
    public AudioSource MCST_09;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private List<GameObject> keyUI;
    [SerializeField] private GameObject fixCross;
    [SerializeField] private GameObject wizard;
    public Button button;

    [SerializeField] private GameObject correctStar;
    [SerializeField] private GameObject incorrectStar;


    //Cards and Border
    public List<GameObject> cardList = new List<GameObject>();
    public GameObject cardBorder;


    //var for the testPhase
    public List<int> usedRules = new List<int>();
    public List<int> usedRulesTwo = new List<int>();
    public int position = 0;

    private GameObject current;
    private string currentColor;
    private int currentNum;
    private string currentShape;

    private GameObject clicked;
    private string clickedColor;
    private int clickedNum;
    private string clickedShape;


    bool preservationError;
    public int blockNumber = 1;
    int block2Buff = 0;

    public int sortCategory = 0;
    public int correctChain = 0;

    public List<Card> keys = new List<Card>();
    public List<int> correctResponse = new List<int>();
    public int clickedResponse;
    int trialType = 0;
    int accuracy = 0;
    int buff = 0;

    public static int gesamtpunktzahl = 0;

    public static Stopwatch timer = new Stopwatch();

    void Start()
    {
        gesamtpunktzahl = 0;
        buff = 0;
        blockNumber = 1;
        block2Buff = 0;
        position = 0;
        //spaeter wieder aktivieren nur um intro test dauer zu skippen
        //StartCoroutine(IntroSequenz());
    }

    private void Update()
    {
        if (timer.Elapsed.TotalSeconds >= 8.0)
        {
            timer.Stop();
            clickedResponse = 0;
            accuracy = 0;
            correctChain = 0;

            StartCoroutine(IncorrectAnimation());
            timer.Reset();
        }
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
        if (clickedColor == currentColor)
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
    private void FirstCompareCards()
    {


        //for schleife unten in die if abfrage da erst unten die sort category festgelegt wird
        if (blockNumber == 2)
        {
            bool checkList = false;
            Debug.Log("Block2");
            trialType = 2;

            //sortCat festlegen anhand der rules liste

            if (usedRules.Count == buff)
            {
                if (clickedColor == currentColor) sortCategory = 1;
                if (clickedShape == currentShape) sortCategory = 2;
                if (clickedNum == currentNum) sortCategory = 3;

                for (int i = 0; i < usedRules.Count; i++)
                {
                    if (sortCategory == usedRules[i]) checkList = true;
                }
                for (int i = 0; i < usedRulesTwo.Count; i++)
                {
                    if (sortCategory == usedRules[i]) checkList = true;
                }

                if (checkList == true)
                {
                    accuracy = 2;
                    sortCategory = 0;
                    StartCoroutine(IncorrectAnimation());
                }
                else
                {
                    accuracy = 1;
                    StartCoroutine(CorrectAnimation());
                }

            }
            else
            {
                sortCategory = usedRules[buff];
                buff++;
                if (clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape)
                {

                    if (sortCategory == 1) CompareColor();
                    if (sortCategory == 2) CompareShape();
                    if (sortCategory == 3) CompareNum();

                }
                else
                {
                    StartCoroutine(IncorrectAnimation());
                }
            }




        }
        else
        {
            if (clickedColor == currentColor || clickedNum == currentNum || clickedShape == currentShape)
            {
                if (clickedColor == currentColor) sortCategory = 1;
                if (clickedShape == currentShape) sortCategory = 2;
                if (clickedNum == currentNum) sortCategory = 3;

                Debug.Log("checkIfUsed: " + CheckIfUsed(sortCategory));
                if (preservationError == true)
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


    }
    IEnumerator IntroSequenz()
    {
        button.interactable = false;
        MCST_11.Play();
        yield return new WaitForSeconds(13f);
        button.interactable = true;
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
    IEnumerator WizardAnimation()
    {
        DisableKeys();
        correctChain = 0;
        MCST_09.Play();
        wizard.SetActive(true);
        yield return new WaitForSeconds(6f);
        sortCategory = 0;
        wizard.SetActive(false);
        EnableKeys();
        NextCard();
    }

    IEnumerator CorrectAnimation()
    {
        WriteInDataSaver(blockNumber, trialType, sortCategory, current.name, correctResponse[0], correctResponse[1], correctResponse[2], clickedResponse, timer.ElapsedMilliseconds, accuracy);
        correctStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(0.5f);
        correctStar.SetActive(false);
        current.SetActive(false);
        cardBorder.SetActive(false);
        position++;
        yield return new WaitForSeconds(1f);

        if (correctChain == 6) gesamtpunktzahl++;

        if (blockNumber == 2 && correctChain == 6)
        {

            usedRulesTwo.Add(sortCategory);
            block2Buff++;
            if ((blockNumber == 2 && position == 47) || blockNumber == 2 && block2Buff == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                StartCoroutine(WizardAnimation());
            }
        }

        else
        {
            if ((blockNumber == 2 && position == 48) || blockNumber == 2 && block2Buff == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            if (correctChain == 6 && blockNumber == 1 && position != 24 && usedRules.Count != 3)
            {

                usedRules.Add(sortCategory);
                if (usedRules.Count < 3)
                {
                    StartCoroutine(WizardAnimation());
                }
            }
            else
            {
                NextCard();
                EnableKeys();
            }
        }

        if (position == 24 || (usedRules.Count == 3 && blockNumber == 1))
        {
            StartCoroutine(BlockSwitch());
        }
    }


    IEnumerator IncorrectAnimation()
    {
        WriteInDataSaver(blockNumber, trialType, sortCategory, current.name, correctResponse[0], correctResponse[1], correctResponse[2], clickedResponse, timer.ElapsedMilliseconds, accuracy);
        incorrectStar.SetActive(true);
        DisableKeys();
        yield return new WaitForSeconds(0.5f);
        incorrectStar.SetActive(false);
        current.SetActive(false);
        cardBorder.SetActive(false);
        position++;
        yield return new WaitForSeconds(1f);

        if (blockNumber == 2 && position == 48)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            if (position == 24)
            {
                StartCoroutine(BlockSwitch());
            }
            else
            {
                EnableKeys();
                NextCard();
            }

        }
    }

    IEnumerator BlockSwitch()
    {
        current.SetActive(false);
        cardBorder.SetActive(false);
        timer.Stop();
        timer.Reset();
        blockNumber = 2;
        block2Buff = 0;
        correctChain = 0;
        sortCategory = 0;
        MCST_12.Play();
        DisableKeys();
        DisableKeyUI();
        MCST_12.Play();
        position = 24;
        yield return new WaitForSeconds(3f);
        EnableKeyUI();
        StartCoroutine(Wait());
    }
    private void SetCurrent(GameObject currentObj)
    {
        cardBorder.SetActive(true);
        current = currentObj;
        current.SetActive(true);

        currentColor = current.GetComponent<CardDisplay>().card.color;
        currentNum = current.GetComponent<CardDisplay>().card.number;
        currentShape = current.GetComponent<CardDisplay>().card.shape;
        GetCorrectResponse();
        timer.Reset();
        timer.Start();

    }

    private void NextCard()
    {
        cardBorder.SetActive(true);
        if (position < 48)
        {
            SetCurrent(cardList[position]);
        }
    }

    public void DisableUI()
    {
        text.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
        EnableKeyUI();
        StartCoroutine(Wait());
    }

    private void EnableKeyUI()
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


    }

    private void DisableKeyUI()
    {
        foreach (GameObject obj in keyUI)
        {
            obj.gameObject.SetActive(false);
        }
        fixCross.SetActive(true);
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

        Debug.Log(correctResponse[0] + "," + correctResponse[1] + "," + correctResponse[2]);
    }
    void WriteInDataSaver(int blockNum, int trialType, int sortCat, string WCST, int respOne, int respTwo, int respThree, int CRESP, float timer, int acc)
    {
        //WCST_Data.MeasurePractice(0,1,position+1,trialType, sortCategory,current.name,correctResponse[0], correctResponse[1], correctResponse[2], clickedResponse, 123,trialType);
        WCST_Data.MeasureTest(1, blockNumber + 1, position + 1, trialType, sortCat, WCST, respOne, respTwo, respThree, CRESP, timer, acc);
    }
}
