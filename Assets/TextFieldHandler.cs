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
    public Measurement efmeasurement;
    public InputField vpnField;

    // Start is called before the first frame update
    void Start()
    {
        experiment = FindObjectOfType<Experiment>();
        efmeasurement = FindObjectOfType<Measurement>();

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            vpnField.text = SceneSwitch.inputVPN;
            if (!string.IsNullOrEmpty(vpnField.text))
            {
                efmeasurement.VPN_Num = Int32.Parse(vpnField.text);
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
