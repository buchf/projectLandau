using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


public class DataGoNoGO : MonoBehaviour
{
    //VPN nummer soll im gesamten project den Input vom Textfeld VPN bekommen sodass die datei auf diejenige Versuchsperson sich bezieht
    public static string VPN;
    static string fileName;
    public static string filePath;


    public static StringBuilder overall = new StringBuilder();


    public static List<StringBuilder> results = new List<StringBuilder>();


    void Start()
    {
        fileName = "VPN" + VPN + "_goNoGo.csv";
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        overall.Append("Go-Nogo Task,Gesamtpunktzahl," + "12\n" + "\n");

        results.Add(overall);
        File.WriteAllText(filePath, ListToString(results));
    }

    private string ListToString(List<StringBuilder> results)
    {
        string x = "";
        foreach (var element in results)
        {
            x = x + element.ToString();
        }

        return x;
    }
}
