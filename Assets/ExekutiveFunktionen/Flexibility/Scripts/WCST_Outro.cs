using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WCST_Outro : MonoBehaviour
{
    public AudioSource MCST_13;

    void Start()
    {
        MCST_13.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MCST_13.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -166);
        }
        
    }
}
