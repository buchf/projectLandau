using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeRunner : MonoBehaviour
{
    public Text txtDatum;
    public Text txtUhrzeit;
    public string Datum;
    public string Uhrzeit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        Datum = System.DateTime.Now.ToString("dd/MM/yyyy");
        txtDatum.text = Datum;
        Uhrzeit = System.DateTime.Now.ToString("HH:mm:ss");
        txtUhrzeit.text = Uhrzeit;
    }
}
