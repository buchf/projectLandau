using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalSelector : MonoBehaviour
{
    public TextMesh cow;
    public TextMesh chicken;
    public TextMesh pig;
    public TextMesh Outro;

    
    void Start()
    {
        //GoNoGo.trial++;
        SelectText(GoNoGo.trial);
    }
  
    public void NextTrial()
    {
        if(GoNoGo.trial == 5) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 128);
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SelectText(int trial)
    {
        switch (trial)
        {
            case 2:
                cow.gameObject.SetActive(true);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(false);
                Outro.gameObject.SetActive(false);
                break;
            case 3:
                cow.gameObject.SetActive(false);
                chicken.gameObject.SetActive(true);
                pig.gameObject.SetActive(false);
                Outro.gameObject.SetActive(false);
                break;
            case 4:
                cow.gameObject.SetActive(false);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(true);
                Outro.gameObject.SetActive(false);
                break;
            case 5:
                cow.gameObject.SetActive(false);
                chicken.gameObject.SetActive(false);
                pig.gameObject.SetActive(false);
                Outro.gameObject.SetActive(true);
                break;
        }
    }
}
