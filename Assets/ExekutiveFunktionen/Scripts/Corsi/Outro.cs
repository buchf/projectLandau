using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Outro : MonoBehaviour
{
    public AudioSource Corsi_03;

    private void Update()
    {
        if (!Corsi_03.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 126);
        }
    }
}
