using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{

    /*
     * Easy Scene Switcher index = 0 is the intro, 1 = the play scene, 2 = Outroscene
     * 
     */

    public static string inputVPN;
    public static bool reverse = false;

    public static int repeatGoNoGo;

    private void Start()
    {
        
        
    }

    public void StartGame()
    {
        DataSaver.z0.Clear();
        DataSaver.z1.Clear();
        DataSaver.z2.Clear();
        DataSaver.z3.Clear();
        DataSaver.z4.Clear();
        DataSaver.z5.Clear();
        DataSaver.z6.Clear();
        DataSaver.z7.Clear();
        DataSaver.z8.Clear();
        DataSaver.results.Clear();
        Randomizer.countFalseTask = 0;
        Randomizer.totalTasks = 0;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 126);
    }
    public void GoNoGoBackStart()
    {
        //GoNoGo.counter = 0;
        //GoNoGo.trial = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 131);
    }

    public void WCSTStart()
    {
        WCST_Data.header.Clear();
        WCST_Data.practice.Clear();
        WCST_Data.test.Clear();
        WCST_Data.results.Clear();
        WCST_Data.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 163);
    }

    public void CoverStoryStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 167);
    }

    public void CoverStoryOutroStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 170);
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

        DataGoNoGO.ClearAllData();
        DataGoNoGO.VPN = inputVPN;
        repeatGoNoGo = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 127);
    }
    public void StartCardSorting()
    {
        
        
        CSDataSaver.VPN = inputVPN;

        CSDataSaver.ClearAllData();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 154);
        //Debug.Log(CSDataSaver.fileName.ToString());
    }

    public void BackCardSorting()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 159);
    }

    
}
