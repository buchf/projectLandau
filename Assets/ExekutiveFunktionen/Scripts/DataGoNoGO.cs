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

    public static int count = 1;

    public static StringBuilder overall = new StringBuilder();
    public static StringBuilder header = new StringBuilder();

    public static List<StringBuilder> results = new List<StringBuilder>();
    
    public static StringBuilder z1 = new StringBuilder();

    void Start()
    {
        fileName = "VPN" + VPN + "_goNoGo.csv";
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        overall.Append("Go-Nogo Task,Gesamtpunktzahl," + "12\n" + "\n\n\n");
        header.Append(",aktuelles NoGo-Tier,praesentiertes Tier, Click(Button), CRESP, RT (in ms)\n");

        results.Add(overall);
        results.Add(header);
        File.WriteAllText(filePath, ListToString(results));
    }

    public static void MeasureSequenz(string currentAnimal, string actualAnimal, int clicked, bool CRESP, double reaction)
    {
        z1.AppendFormat(",{0},{1},{2},{3},{4}ms\n", currentAnimal, actualAnimal, clicked, CRESP, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
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
