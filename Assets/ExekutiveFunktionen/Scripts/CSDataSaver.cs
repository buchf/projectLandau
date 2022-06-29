using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;

public class CSDataSaver : MonoBehaviour
{
    public static string VPN;
    public static string fileName;
    public static string filePath;

    int i = 1;

    public static StringBuilder header = new StringBuilder();
    public static StringBuilder overall = new StringBuilder();

    public static List<StringBuilder> results = new List<StringBuilder>();

    public static StringBuilder practice = new StringBuilder();
    public static StringBuilder test = new StringBuilder();

    void Start()
    {
        fileName = "VPN" + VPN + "_CardSorting.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        header.Append("Experimental Phase,Block number,Trial Type,Trial #,Item left,Item middle,Item right,Target Item,RT (in ms),Correct Response\n");

        
        results.Add(header);
        results.Add(practice);
        results.Add(test);

        File.WriteAllText(filePath, ListToString(results));

    }

    public string checkFilename(string fileName)
    {
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "(" + i + ")" + "_CardSorting.csv";
            i++;
        }
        return fileName;
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

    public static void MeasureTest(int trial, string itemLeft, string itemMid, string itemRight, string targetItem, double reaction, int CRESP)
    {
        test.AppendFormat("Test,2,1,{0},{1},{2},{3},{4},{5},{6}\n", trial, itemLeft,itemMid, itemRight, targetItem, reaction, CRESP);
    }
}
