using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class TextFieldHandler : MonoBehaviour
{
   // public static string inputVPN;
    public Experiment experiment;
    public Measurement measurement;
    public InputField vpnField;

    // Start is called before the first frame update
    void Start()
    {
        experiment = FindObjectOfType<Experiment>();
        measurement = FindObjectOfType<Measurement>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            vpnField.text = SceneSwitch.inputVPN;
            if (!string.IsNullOrEmpty(vpnField.text))
            {
                measurement.VPN_Num = Int32.Parse(vpnField.text);
                //experiment.OnVPNChanged(inputVPN);
                EnableMenu();
            }
            
        }
    }


    public void EnableMenu()
    {
        experiment.SetUIStatus(true);
    }
}
