using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GoNoGo : MonoBehaviour
{
    //Tiere mue
    public GameObject blue;
    public GameObject red;
    public GameObject green;
    public GameObject normal;


    public static Stopwatch timer = new Stopwatch();


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(testAnimation());

    }

    public void showNormal()
    {
        normal.SetActive(true);
    }

    public void showRed()
    {
        red.SetActive(true);
    }

    public void showGreen()
    {
        green.SetActive(true);
    }

    public void showBlue()
    {
        blue.SetActive(true);
    }

    IEnumerator animateRed()
    {
        normal.SetActive(true);
        yield return new WaitForSeconds(2f);
        normal.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        showRed();
    }
    IEnumerator animateBlue()
    {
        normal.SetActive(true);
        yield return new WaitForSeconds(2f);
        normal.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        showBlue();
    }
    IEnumerator animateGreen()
    {
        normal.SetActive(true);
        yield return new WaitForSeconds(2f);
        normal.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        showGreen();
    }

    IEnumerator testAnimation()
    {
        normal.SetActive(true);
        yield return new WaitForSeconds(2f);
        normal.SetActive(false);
        green.SetActive(true);
        yield return new WaitForSeconds(2f);
        green.SetActive(false);
        showBlue();
        yield return new WaitForSeconds(2f);
        blue.SetActive(false);
        showRed();
    }
}
