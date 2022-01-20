using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

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
    int counter = 0;
    int trialCounter = 0;

    //wird angepasst wenn das targettier geaendert werden soll
    int sequenz = 0;

    // Start is called before the first frame update
    void Start()
    {

        currentAnimal = normal;
        current = normal;
        normal.SetActive(true);
        StartSequenz();
    }

    private void Update()
    {
        if (timer.Elapsed.TotalSeconds >= 2.0)
        {
            Debug.Log("aaa");
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

    public void compareObject()
    {
        Debug.Log(timer.Elapsed.TotalSeconds.ToString());
    }

    void selectAnimal(int counter)
    {
        if (counter == 4) showNormal();
        if (counter == 1) showRed();
        if (counter == 2) showBlue();
        if (counter == 3) showGreen();
    }

    void showNormal()
    {
        current.SetActive(false);
        current = normal;
        current.SetActive(true);
    }
    void showRed()
    {
        current.SetActive(false);
        current = red;
        current.SetActive(true);
    }
    void showGreen()
    {
        current.SetActive(false);
        current = green;
        current.SetActive(true);
    }
    void showBlue()
    {
        current.SetActive(false);
        current = blue;
        current.SetActive(true);
    }
}
