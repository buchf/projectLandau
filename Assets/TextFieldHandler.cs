using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class TextFieldHandler : MonoBehaviour
{
    public static string inputVPN;
    public Experiment experiment;
    public InputField vpnField;

    // Start is called before the first frame update
    void Start()
    {
        experiment = FindObjectOfType<Experiment>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            vpnField.text = SceneSwitch.inputVPN;
            if (!string.IsNullOrEmpty(vpnField.text))
            {
                EnableMenu();
            }
            
        }
    }


    public void EnableMenu()
    {
        experiment.SetUIStatus(true);
    }
}
