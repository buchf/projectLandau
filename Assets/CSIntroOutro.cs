using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CSIntroOutro : MonoBehaviour
{
    public AudioSource Corsi_01;

    void Start()
    {
        Corsi_01.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Corsi_01.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -169);
        }
    }
}
