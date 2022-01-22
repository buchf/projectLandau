using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.SceneManagement;

using Debug = UnityEngine.Debug;

public class GoNoGo : MonoBehaviour
{
    public GameObject blue;
    public GameObject red;
    public GameObject green;
    public GameObject normal;

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
        Debug.Log("trial: " + trial);
        SelectCurrentAnimal(trial);
        current = normal;
        normal.SetActive(true);
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

        if (timer.Elapsed.TotalSeconds >= 2.0)
        {
            selectAnimal(counter);
            Debug.Log("aaa");
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
        if (trial == 1) currentAnimal = normal;
        if (trial == 2) currentAnimal = green;
        if (trial == 3) currentAnimal = red;
        if (trial == 4) currentAnimal = blue;
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
                StartCoroutine(showBlue());
                break;
            case int n when ((counter % 3) == 0):
                StartCoroutine(showGreen());
                break;
            case int n when ((counter % 2) == 0):
                StartCoroutine(showRed());
                break;
            case int n when ((counter % 1) == 0):
                StartCoroutine(showNormal());
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
    IEnumerator showNormal()
    {
        current.SetActive(false);
        current = normal;
        yield return new WaitForSeconds(0.5f);
        current.SetActive(true);
    }

    IEnumerator showRed()
    {
        current.SetActive(false);
        current = red;
        yield return new WaitForSeconds(0.5f);
        current.SetActive(true);
    }

    IEnumerator showGreen()
    {
        current.SetActive(false);
        current = green;
        yield return new WaitForSeconds(0.5f);
        current.SetActive(true);
    }

    IEnumerator showBlue()
    {
        current.SetActive(false);
        current = blue;
        yield return new WaitForSeconds(0.5f);
        current.SetActive(true);
    }
}