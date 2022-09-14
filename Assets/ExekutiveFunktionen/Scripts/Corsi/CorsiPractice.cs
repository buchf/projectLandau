using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CorsiPractice : MonoBehaviour
{
    
    public GameObject fairy;
    public int count1, count2 = 0;
    public TextMesh increaseText;
    float speed = 1f;

    private AudioSource introAudio;
    public AudioSource corsi_02;
    public AudioSource corsi_02_back;
    public AudioSource corsiIncrease;
    private int buff = 0;

    //UI Variable
    public TextMesh introText;
    public TextMesh introTextReverse;

    public GameObject lessaImage;
    public Button continueButton;
    public Button redoButton;
    public TextMesh countinueText;
    [SerializeField] List<Transform> blocks = new List<Transform>();
    [SerializeField] Button button;
    [SerializeField] Button button2;

    public static int clickedBlocks = 0;
    int sequenzBlocks = 1;

    public GameObject correcStar;
    public GameObject incorrectStar;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        buff = 0;
        player = FindObjectOfType<Player>();
        if (Randomizer.reverse == true)
        {
            introAudio = corsi_02_back;
        }
        if (Randomizer.reverse == false)
        {
            introAudio = corsi_02;
        }
        introAudio.Play();

    }

    // Update is called once per frame
    void Update()
    {

        if(!introAudio.isPlaying && buff == 0)
        {
            button.interactable = true;
            buff = 1;
        }
        if(!corsiIncrease.isPlaying && buff == 2)
        {
            button2.interactable = true;
            buff = 3;
        }
        if(!introAudio.isPlaying && buff == 4)
        {
            continueButton.interactable = true;
            buff = 5;
        }

        //wenn clickedblocks length = sequenztlengt -> startsequenz
       if(clickedBlocks == sequenzBlocks)
       {
            
            player.CleanListsPractice();
            clickedBlocks = 0;
            if (player.listCompareVar == 1)
            {
               StartCoroutine(CorrectSequence());
            }
            else
            {
                StartCoroutine(IncorrectSequence());
            }
            
        }
    }

    public void StartFirstSequenz()
    {
        fairy.transform.position = new Vector3(-6f, 3f, -1);
        showField();
        StartCoroutine(SequenzZero(3));
        count1++;
    }

    public void StartSequenz()
    {
        
        //Debug.Log(DataSaver.filePath.ToString());
        fairy.SetActive(true);
        fairy.transform.position = new Vector3(-6f, 3f, -1);

        if (count1 == 3 && count2 != 2)
        {
            count1 = 0;
            sequenzBlocks = 2;
            count2++;
        }

        
        if (count1 == 2 && count2 == 1)
        {
            HideField();
            button2.gameObject.SetActive(false);
            fairy.gameObject.SetActive(false);
            //countinueText.gameObject.SetActive(true);
            continueButton.interactable = false;
            continueButton.gameObject.SetActive(true);

            //redoButton.gameObject.SetActive(true);
            introAudio.Play();
            buff = 4;
        }

        //Zahlen fuer die verschiedenen Trials wurden mithilfe der GetRandom Funktion erstellt

        //Trial 0
        if (count1 == 1 && count2 == 0) StartCoroutine(SequenzZero(6));
        if (count1 == 2 && count2 == 0) increaseWarning();

        //Trial 1 
        if (count1 == 0 && count2 == 1)
        {
            showField();
            StartCoroutine(SequenzOne(5, 1));
        }
        if (count1 == 1 && count2 == 1) StartCoroutine(SequenzOne(8, 1));
       // if (count1 == 2 && count2 == 1) increaseWarning();

        count1++;

    }
    void increaseWarning()
    {
        HideField();
        corsiIncrease.Play();
        buff = 2;
        increaseText.gameObject.SetActive(true);
    }

    void HideField()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].gameObject.SetActive(false);
        }
        //button.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);
        button2.interactable = false;
    }


    public void showField()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].gameObject.SetActive(true);
        }
        fairy.gameObject.SetActive(true);
        introText.gameObject.SetActive(false);
        introTextReverse.gameObject.SetActive(false);
        lessaImage.SetActive(false);
        button.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        increaseText.gameObject.SetActive(false);

    }

    public void RepeatPractice()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    void SpawnFairyInBlock(int blockNumber)
    {
        switch (blockNumber)
        {
            case 1:
                fairy.transform.position = new Vector3(blocks[0].transform.position.x, blocks[0].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[0].transform.gameObject);
                break;
            case 2:
                fairy.transform.position = new Vector3(blocks[1].transform.position.x, blocks[1].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[1].transform.gameObject);
                break;
            case 3:
                fairy.transform.position = new Vector3(blocks[2].transform.position.x, blocks[2].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[2].transform.gameObject);
                break;
            case 4:
                fairy.transform.position = new Vector3(blocks[3].transform.position.x, blocks[3].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[3].transform.gameObject);
                break;
            case 5:
                fairy.transform.position = new Vector3(blocks[4].transform.position.x, blocks[4].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[4].transform.gameObject);
                break;
            case 6:
                fairy.transform.position = new Vector3(blocks[5].transform.position.x, blocks[5].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[5].transform.gameObject);
                break;
            case 7:
                fairy.transform.position = new Vector3(blocks[6].transform.position.x, blocks[6].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[6].transform.gameObject);
                break;
            case 8:
                fairy.transform.position = new Vector3(blocks[7].transform.position.x, blocks[7].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[7].transform.gameObject);
                break;
            case 9:
                fairy.transform.position = new Vector3(blocks[8].transform.position.x, blocks[8].transform.position.y, -1);
                player.sequenzBlocks.Add(blocks[8].transform.gameObject);
                break;
        }
    }
    void enableField()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            blocks[i].GetComponent<Collider2D>().enabled = true;
        }
        button2.interactable = true;
    }
    public void disableField()
    {

        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].GetComponent<SpriteRenderer>().color = Color.grey;
            blocks[i].GetComponent<Collider2D>().enabled = false;
        }
        button2.interactable = false;
    }

    IEnumerator SequenzZero(int a)
    {
        disableField();
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(a);
        yield return new WaitForSeconds(speed);
        fairy.SetActive(false);
        enableField();
    }
    IEnumerator SequenzOne(int a, int b)
    {
        disableField();
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(a);
        yield return new WaitForSeconds(speed);
        SpawnFairyInBlock(b);
        yield return new WaitForSeconds(speed);
        fairy.SetActive(false);
        enableField();
    }

    IEnumerator CorrectSequence()
    {
        HideFieldForCheck();
        correcStar.SetActive(true);
        yield return new WaitForSeconds(1f);
        correcStar.SetActive(false);
        showField();
        StartSequenz();
    }

    IEnumerator IncorrectSequence()
    {
        HideFieldForCheck();
        incorrectStar.SetActive(true);
        yield return new WaitForSeconds(1f);
        incorrectStar.SetActive(false);
        showField();
        StartSequenz();
    }

    public void HideFieldForCheck()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].gameObject.SetActive(false);
        }
    }
}
