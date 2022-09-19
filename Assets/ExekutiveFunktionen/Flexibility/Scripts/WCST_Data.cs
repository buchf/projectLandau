using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;


public class WCST_Data : MonoBehaviour
{
    public static string VPN;
    static string fileName;
    public static string filePath;

    int gesamtpunktzahl = 0;

    public static StringBuilder header = new StringBuilder();
    public static StringBuilder practice = new StringBuilder();
    public static StringBuilder test = new StringBuilder();
    public static List<StringBuilder> results = new List<StringBuilder>();

    private void Start()
    {
        gesamtpunktzahl = WCST_Play.gesamtpunktzahl;
        fileName = "VPN" + VPN + "_WCST.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        header.Append("Experimental Phase,Block Number,Trial Number,Trial Type,Sorting Catergory,Stimulus presented,Correct Response1,Correct Response2,Correct Response3,Subject Response,Reaction Time,Reaction Accuracy\n");
        results.Add(header);
        results.Add(practice);
        test.Append("\n\nNumber of categories completed: " + gesamtpunktzahl);
        results.Add(test);

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
    public string checkFilename(string fileName)
    {
        int i = 1;
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN  + "_WCST" + "(" + i + ")" + ".csv";
            i++;
        }
        return fileName;
    }

    public static void MeasurePractice(int phase, int blockNum, int trialNum, int trialType, int sortingCategory, string stimulus,int corrResOne, int corrResTwo, int CorResThree, int subRes, float timer, int accuracy)
    {
        practice.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}\n", phase, blockNum, trialNum, trialType, sortingCategory, stimulus, corrResOne, corrResTwo, CorResThree, subRes, timer, accuracy);
    }
    public static void MeasureTest(int phase, int blockNum, int trialNum, int trialType, int sortingCategory, string stimulus, int corrResOne, int corrResTwo, int CorResThree, int subRes, float timer, int accuracy)
    {
        test.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}\n", phase, blockNum, trialNum, trialType, sortingCategory, stimulus, corrResOne, corrResTwo, CorResThree, subRes, timer, accuracy);
    }
}
