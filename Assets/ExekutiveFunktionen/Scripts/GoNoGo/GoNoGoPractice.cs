using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoNoGoPractice : MonoBehaviour
{

    public AudioSource GoNoGo_02;
    public AudioSource audiobuff;
    public int buff = 0;
    public int buff2 = 0;
    public GameObject pig;
    public GameObject chicken;
    public GameObject cow;
    public GameObject donkey;
    [SerializeField] Button button;
    GameObject shownAnimal;
    GameObject currentAnimal;

    public TextMesh introText;
    public TextMesh introText2;
    public GameObject introAnimal;
    public GameObject introAnimal2;
    public Button introButton;

    public Button continueButton;
    //public Button redoButton;
    public TextMesh continueText;

    public static Stopwatch timer = new Stopwatch();
    public int counter;
    public int trial;
    public int practiceerrors = 0;
    public int practicehits = 0;


    // Start is called before the first frame update
    void Start()
    {
        timer.Reset();
        timer.Stop();
        introButton.interactable = false;
        GoNoGo_02.Play();
        practiceerrors = 0;
        practicehits = 0;
        counter = 0;
        shownAnimal = cow;
        buff = 0;
        buff2 = 0;
        trial = 0;
    }

    private void Update()
    {

        if (!audiobuff.isPlaying && buff2 == 1)
        {
            continueButton.interactable = true;
            buff2++;
        }

        if (counter == 11)
        {
            chicken.SetActive(false);
        }
        if (!GoNoGo_02.isPlaying && buff == 0)
        {
            buff++;
            introButton.interactable = true;
        }
        if (!GoNoGo_02.isPlaying && buff == 2)
        {
            buff++;
            introButton.interactable = true;
        }


        if (counter == 11 && trial == 2 && buff2 == 0)
        {

            if (practiceerrors >= 2 || practicehits < 5)
            {
                timer.Reset();
                if (SceneSwitch.repeatGoNoGo == 1)
                {
                    audiobuff.Play();
                    buff2 = 1;
                    timer.Stop();
                    shownAnimal.gameObject.SetActive(false);
                    chicken.gameObject.SetActive(false);
                    button.gameObject.SetActive(false);
                    continueText.gameObject.SetActive(true);
                    continueButton.gameObject.SetActive(true);
                    continueButton.interactable = false;
                }
                else
                {
                    RepeatPractice();
                }

            }
            else
            {

                audiobuff.Play();
                buff2 = 1;
                timer.Stop();
                shownAnimal.gameObject.SetActive(false);
                chicken.gameObject.SetActive(false);
                button.gameObject.SetActive(false);
                continueText.gameObject.SetActive(true);
                continueButton.gameObject.SetActive(true);
                continueButton.interactable = false;
            }
        }

        if (counter == 11 && trial != 2 && !GoNoGo_02.isPlaying && buff == 1)
        {
            counter = 1;
            trial++;
        }


        if (timer.Elapsed.TotalMilliseconds >= GoNoGo.presentationTime)
        {
            shownAnimal.SetActive(false);
        }

        if (timer.Elapsed.TotalMilliseconds >= GoNoGo.responseRegistration && counter != 11) 
        { 
            timer.Reset();
            SelectNextAnimal();
        }
    }
    void enableIntro()
    {
        timer.Stop();
        timer.Reset();
        GoNoGo_02.Play();
        introAnimal2.SetActive(true);
        introText2.gameObject.SetActive(true);
        introButton.gameObject.SetActive(true);
        introButton.interactable = false;
        shownAnimal.gameObject.SetActive(false);
        button.gameObject.SetActive(false);

    }

    void disableIntro()
    {
        trial++;
        introAnimal.SetActive(false);
        introText.gameObject.SetActive(false);
        introAnimal2.SetActive(false);
        introText2.gameObject.SetActive(false);
        introButton.gameObject.SetActive(false);
        button.gameObject.SetActive(true);
    }




    public void startSequenz()
    {
        counter = 1;
        disableIntro();
        shownAnimal = donkey;
        donkey.SetActive(true);
        button.interactable = true;
        button.transition = Selectable.Transition.ColorTint;
        //selectAnimal(counter);

        timer.Start();
    }


    public void StartGoNoGo()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RepeatPractice()
    {
        SceneSwitch.repeatGoNoGo = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
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

    public void clickButton()
    {
        if (shownAnimal == cow)
            practiceerrors++;
        else
            practicehits++;
        timer.Reset();
        SelectNextAnimal();

    }

    private void SelectNextAnimal()
    {
        selectAnimal(counter);
        button.enabled = false;
        counter++;
    }

    IEnumerator showDonkey()
    {
        shownAnimal.SetActive(false);
        shownAnimal = donkey;
        yield return new WaitForSeconds(GoNoGo.interStim/1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }

    IEnumerator showChicken()
    {
        shownAnimal.SetActive(false);
        shownAnimal = chicken;
        yield return new WaitForSeconds(GoNoGo.interStim / 1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }

    IEnumerator showCow()
    {
        shownAnimal.SetActive(false);
        shownAnimal = cow;
        yield return new WaitForSeconds(GoNoGo.interStim / 1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }

    IEnumerator showPig()
    {
        shownAnimal.SetActive(false);
        shownAnimal = pig;
        yield return new WaitForSeconds(GoNoGo.interStim / 1000);
        shownAnimal.SetActive(true);
        button.enabled = true;
        timer.Start();
    }
}