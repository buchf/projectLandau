using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CSIntro : MonoBehaviour
{

    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();
    [SerializeField] List<GameObject> backgrounds = new List<GameObject>();

    int current = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioFiles[current].Play();
        backgrounds[current].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioFiles[current].isPlaying)
        {
            current++;
            if (current == 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {

                audioFiles[current].Play();
                backgrounds[current - 1].SetActive(false);
                backgrounds[current].SetActive(true);

            }
        }
    }
}
