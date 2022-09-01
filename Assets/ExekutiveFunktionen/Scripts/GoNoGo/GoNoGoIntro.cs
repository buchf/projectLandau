using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNoGoIntro : MonoBehaviour
{
    public AudioSource GoNoGo_03;

    // Update is called once per frame
    void Update()
    {
        if (!GoNoGo_03.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 131);
        }
    }
}
