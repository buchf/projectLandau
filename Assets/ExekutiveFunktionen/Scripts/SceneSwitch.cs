using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    /*
     * Easy Scene Switcher index = 0 is the intro, 1 = the play scene, 2 = Outroscene
     * 
     */

    private string inputVPN = "";
    private bool reverse = false;
    public void StartGame()
    {
        DataSaver.VPN = inputVPN;
        Randomizer.reverse = reverse;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 123);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 125);
    }


    public void ReadInput(string s)
    {
        inputVPN = s;
    }

    public void SetReverse()
    {
        reverse = true;
    }
}
