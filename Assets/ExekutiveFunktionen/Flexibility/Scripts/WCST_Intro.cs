using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WCST_Intro : MonoBehaviour
{



    [SerializeField] List<AudioSource> audioFiles = new List<AudioSource>();
    [SerializeField] List<GameObject> backgrounds = new List<GameObject>();

    int current = 0;

    void Start()
    {
        audioFiles[current].Play();
        backgrounds[current].SetActive(true);
    }
    void Update()
    {
        
        if (!audioFiles[current].isPlaying)
        {
            current++;
            if (current == 8)
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
