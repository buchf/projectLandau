using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CSOutro : MonoBehaviour
{
    public AudioSource STS30;

    private void Start()
    {
        STS30.Play();
    }

    private void Update()
    {
        if (!STS30.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 159);
        }
    }
}
