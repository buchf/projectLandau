using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Debug = UnityEngine.Debug;

public class GoNoGo : MonoBehaviour
{
    public GameObject pig;
    public GameObject chicken;
    public GameObject cow;
    public GameObject donkey;

    [SerializeField] Button button;

    GameObject shownAnimal;
    GameObject currentAnimal;


    public static Stopwatch timer = new Stopwatch();

    //counter zum durchiterieren und trialcounter um ab 10 das targettier zu wechseln
    public int counter = 0;
    public static int trial = 1;
    public static double presentationTime = 500;
    public static double responseRegistration = 1000;
    public static float interStim = 1000;
    public string trialType = "";

    public static int correctClick = 0;
    public static int incorrectClick = 0;
    public static int correctNoClick = 0;
    public static int incorrectNoClick = 0;
    public static int trialNo = 1; // wievieltes Item (ohne Uebungsphase)
    public static bool isFirst = false;
    //wird angepasst wenn das targettier geaendert werden soll
    public int sequenz = 0;

    public int checkAnimal;

    // Start is called before the first frame update
    void Start()
    {
        timer.Reset();
        //counter = 0;
        SelectCurrentAnimal(trial);
        Debug.Log("trial: " + trial + "animal: " + currentAnimal.name.ToString());
        shownAnimal = donkey;
        // donkey.SetActive(true);
        //timer.Start();
        //button.enabled = true;
        StartSequenz();
    }

    private void Update()
    {

        if (timer.Elapsed.TotalMilliseconds >= presentationTime)
        {
            shownAnimal.SetActive(false); //
        }

        if (timer.Elapsed.TotalMilliseconds >= responseRegistration)
        {
                
            if (shownAnimal == currentAnimal)
            {
                trialType = "NoGo";
                checkAnimal = 1;
                correctNoClick++;
            }
            else
            {
                trialType = "Go";
                checkAnimal = 0;
                incorrectNoClick++;
            }
            WriteInDatasaver(currentAnimal.name, shownAnimal.name, 0, checkAnimal, timer.Elapsed.TotalMilliseconds, trialNo, trialType);
            SelectNextAnimal(isFirst);
        }

        if (counter == 21 && trial < 5)
        {
            trial++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (counter == 21 && trial >= 5)
        {
            Debug.Log("Finish!!!");
            trial++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            counter = 1;
            trial = 1;
        }
        
    }

    //wird benoetigt zur automatischen abfolge oder beim klicken des buttons
    private void SelectNextAnimal(bool firstItem)
    {
        if(!firstItem)
            trialNo++;
        isFirst = false;
        counter++;
        selectAnimal(counter);
        button.enabled = false;
        
    }

    public void StartSequenz()
    {
        //timer.Start();
        isFirst = true;
        SelectNextAnimal(isFirst);
    }

    void SelectCurrentAnimal(int trial) //falls sich das NoGo-Tier aendert
    {
        if (trial == 1) currentAnimal = cow;
        if (trial == 2) currentAnimal = cow;
        if (trial == 3) currentAnimal = cow;
        if (trial == 4) currentAnimal = cow;
    }


    void selectAnimal(int counter)
    {
       // if (counter == 0) StartCoroutine(showPig());
        if (counter == 1) StartCoroutine(showDonkey());
        if (counter == 2) StartCoroutine(showChicken());
        if (counter == 3) StartCoroutine(showPig());
        if (counter == 4) StartCoroutine(showChicken());
        if (counter == 5) StartCoroutine(showCow());
        if (counter == 6) StartCoroutine(showPig());
        if (counter == 7) StartCoroutine(showChicken());
        if (counter == 8) StartCoroutine(showCow());
        if (counter == 9) StartCoroutine(showPig());
        if (counter == 10) StartCoroutine(showDonkey());
        if (counter == 11) StartCoroutine(showChicken());
        if (counter == 12) StartCoroutine(showCow());
        if (counter == 13) StartCoroutine(showPig());
        if (counter == 14) StartCoroutine(showCow());
        if (counter == 15) StartCoroutine(showPig());
        if (counter == 16) StartCoroutine(showDonkey());
        if (counter == 17) StartCoroutine(showChicken());
        if (counter == 18) StartCoroutine(showDonkey());
        if (counter == 19) StartCoroutine(showCow());
        if (counter == 20) StartCoroutine(showDonkey());

        /*
        switch (counter)
        {
            case int n when ((counter % 4) == 0):
                StartCoroutine(showPig());
                break;
            case int n when ((counter % 3) == 0):
                StartCoroutine(showCow());
                break;
            case int n when ((counter % 2) == 0):
                StartCoroutine(showChicken());
                break;
            case int n when ((counter % 1) == 0):
                StartCoroutine(showDonkey());
                break;
        } */
    }

    //wird aufgerufen wenn der Button betaetigt wird
    public void compare()
    {
        if (shownAnimal == currentAnimal)
        {
            trialType = "NoGo";
            checkAnimal = 0;
            incorrectClick++;
        }
        if(shownAnimal != currentAnimal)
        {
            trialType = "Go";
            checkAnimal = 1;
            correctClick++;
        }
        WriteInDatasaver(currentAnimal.name, shownAnimal.name, 1, checkAnimal, timer.Elapsed.TotalMilliseconds, trialNo, trialType);
        //aufrufen um nach betaetigen des buttons direkt zum naechsten tier zu gelangen
        SelectNextAnimal(isFirst);
    }

    private void WriteInDatasaver(string current, string shown, int click, int CRESP, double reaction, int item, string trialtype)
    {
        DataGoNoGO.MeasureSequenz(current,shown,click,CRESP,reaction,item,trialtype);
        timer.Reset();
    }


    IEnumerator showDonkey()
    {
        shownAnimal.SetActive(false);
        shownAnimal = donkey;
        yield return new WaitForSeconds(interStim / 1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }

    IEnumerator showChicken()
    {
        shownAnimal.SetActive(false);
        shownAnimal = chicken;
        yield return new WaitForSeconds(interStim/1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }

    IEnumerator showCow()
    {
        shownAnimal.SetActive(false);
        shownAnimal = cow;
        yield return new WaitForSeconds(interStim / 1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }

    IEnumerator showPig()
    {
        shownAnimal.SetActive(false);
        shownAnimal = pig;
        yield return new WaitForSeconds(interStim / 1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }
}