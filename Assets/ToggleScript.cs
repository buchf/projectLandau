using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleScript : MonoBehaviour
{
    public Toggle corsiTog;

    private void Update()
    {
        ToggleCorsi();
    }

    public void ToggleCorsi()
    {
        if (corsiTog.isOn)
        {
            SceneSwitch.reverse = true;
        }
        else
        {
            SceneSwitch.reverse = false;
        }
    }
}
