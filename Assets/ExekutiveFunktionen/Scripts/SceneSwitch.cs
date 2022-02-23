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
    public static bool reverse = false;
    public void StartGame()
    {
        DataSaver.z1.Clear();
        DataSaver.z2.Clear();
        DataSaver.z3.Clear();
        DataSaver.z4.Clear();
        DataSaver.results.Clear();

        DataSaver.VPN = inputVPN;
        Randomizer.reverse = reverse;
        if (reverse)
        {

            DataSaver.count = 8;
        }
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
    public void GoNoGoBackStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 129);
    }

    public void ReadInput(string s)
    {
        inputVPN = s;
    }

    public void SetReverse()
    {
        reverse = true;
    }

    public void StartGoNoGO()
    {
        DataGoNoGO.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 126);
    }
}
