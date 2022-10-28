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

    int i = 1;

    public static StringBuilder overall = new StringBuilder();
    public static StringBuilder header = new StringBuilder();
    public static StringBuilder timePointnogo = new StringBuilder(); //

    public static List<StringBuilder> results = new List<StringBuilder>();
    
    public static StringBuilder z1 = new StringBuilder();


    int gesamtPunktzahl;

    void Start()
    {

        gesamtPunktzahl = GoNoGo.correctNoClick + GoNoGo.correctClick;
        fileName = "VPN" + VPN + "_goNoGo.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);
        timePointnogo.Append(VPN + ",Total score:,"+ gesamtPunktzahl + ",Date:," + System.DateTime.Now.ToString("dd/MM/yyyy") + ",Time:," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n"); //

        overall.Append("Task:,Go-NoGo, \nHits:," + GoNoGo.correctClick + "\n");
        overall.Append("Misses:," + GoNoGo.incorrectNoClick + "\n");
        overall.Append("Correct rejections:," + GoNoGo.correctNoClick + "\n");
        overall.Append("False alarms:," + GoNoGo.incorrectClick + "\n\n");
        header.Append("VP_ID,Correct response,RT (in ms),Block,Trial,NoGo-animal,Presented animal,Click\n");

        results.Add(timePointnogo); //
        results.Add(overall);
        results.Add(header);
        results.Add(z1);
        File.WriteAllText(filePath, ListToString(results));
    }

    public string checkFilename(string fileName)
    {    
        while(File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "_goNoGo" + "(" + i + ")" + ".csv" ;
            i++;
        }
        return fileName;
    }
    public static void MeasureSequenz(string currentAnimal, string actualAnimal, int clicked, int CRESP, double reaction, int item)
    {
        z1.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}\n", VPN, CRESP, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), GoNoGo.trial, item, currentAnimal, actualAnimal, clicked); //
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

    public static void ClearAllData()
    {
        GoNoGo.correctClick = 0;
        GoNoGo.correctNoClick = 0;
        GoNoGo.incorrectClick = 0;
        GoNoGo.incorrectNoClick = 0;
        DataGoNoGO.overall.Clear();
        DataGoNoGO.results.Clear();
        DataGoNoGO.header.Clear();
        DataGoNoGO.z1.Clear();
        timePointnogo.Clear(); //
        GoNoGo.trialNo = 1; //
        GoNoGo.isFirst = false;

    }
}
