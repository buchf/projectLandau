using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;

using Debug = UnityEngine.Debug;

public class GoNoGo : MonoBehaviour
{
    public GameObject pig;
    public GameObject chicken;
    public GameObject cow;
    public GameObject donkey;

    GameObject current;
    GameObject currentAnimal;



    public static Stopwatch timer = new Stopwatch();

    //counter zum durchiterieren und trialcounter um ab 10 das targettier zu wechseln
    public int counter = 0;
    public static int trial = 1;

    //wird angepasst wenn das targettier geaendert werden soll
    public int sequenz = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        SelectCurrentAnimal(trial);
        Debug.Log("trial: " + trial + "animal: " + currentAnimal.name.ToString());
        current = donkey;
        donkey.SetActive(true);
        StartSequenz();
    }

    private void Update()
    {

        if (counter == 10 && trial != 5)
        {
            Debug.Log("Finish!!!");
            trial++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (counter == 10 && trial == 5)
        {
            Debug.Log("Finish!!!");
            trial++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }


        if (timer.Elapsed.TotalSeconds >= 2.0)
        {
            selectAnimal(counter);
            timer.Reset();
            counter++;
            timer.Start();
        }
    }
    public void StartSequenz()
    {
        timer.Start();
    }

    void SelectCurrentAnimal(int trial)
    {
        if (trial == 1) currentAnimal = donkey;
        if (trial == 2) currentAnimal = cow;
        if (trial == 3) currentAnimal = chicken;
        if (trial == 4) currentAnimal = pig;
    }
    public void compareObject()
    {
        Debug.Log(timer.Elapsed.TotalSeconds.ToString());
    }

    void selectAnimal(int counter)
    {
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
        }
    }

    public void compare()
    {
        if (current == currentAnimal)
        {
            Debug.Log("false");
        }
        else
        {
            Debug.Log("true");
        }
    }
    IEnumerator showDonkey()
    {
        current.SetActive(false);
        current = donkey;
        yield return new WaitForSeconds(1f);
        current.SetActive(true);
    }

    IEnumerator showChicken()
    {
        current.SetActive(false);
        current = chicken;
        yield return new WaitForSeconds(1f);
        current.SetActive(true);
    }

    IEnumerator showCow()
    {
        current.SetActive(false);
        current = cow;
        yield return new WaitForSeconds(1f);
        current.SetActive(true);
    }

    IEnumerator showPig()
    {
        current.SetActive(false);
        current = pig;
        yield return new WaitForSeconds(1f);
        current.SetActive(true);
    }
}