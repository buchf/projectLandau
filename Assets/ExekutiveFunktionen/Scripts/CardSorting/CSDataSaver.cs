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

    public static StringBuilder timePointsts = new StringBuilder(); //

    public static StringBuilder header = new StringBuilder();
    public static StringBuilder overall = new StringBuilder();

    public static List<StringBuilder> results = new List<StringBuilder>();

    public static StringBuilder practice = new StringBuilder();
    public static StringBuilder practiceTwo = new StringBuilder();
    public static StringBuilder test = new StringBuilder();
    public static StringBuilder testTwo = new StringBuilder();
    public static StringBuilder score = new StringBuilder();

    void Start()
    {
        fileName = "VPN" + VPN + "_CardSorting.csv";
        fileName = checkFilename(fileName);
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        timePointsts.Append(VPN + ",Total score:," + CSPlay.correctResponse.ToString() + ",Date:," + System.DateTime.Now.ToString("dd/MM/yyyy") + ",Time:," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n"); //

        header.Append("Task:,Something's the same\n" + "Score phase 1:," + CSPlay.scorePhaseOne.ToString() + "\n" + "Score phase 2:," + CSPlay.scorePhaseTwo.ToString() + "\n\n\n\n" + "VP_ID,Correct response,RT (in ms),Block,Trial,Experimental condition,Temporal block,Item left,Item middle,Item right,Chosen item\n");
        // score.Append("\nGesamtscore," + CSPlay.correctResponse.ToString());

        results.Add(timePointsts); //
        results.Add(header);
        results.Add(practice);
        results.Add(test);
        results.Add(practiceTwo);
        results.Add(testTwo);
        results.Add(score);


        File.WriteAllText(filePath, ListToString(results));

    }

    public string checkFilename(string fileName)
    {
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "_CardSorting" + "(" + i + ")" + ".csv";
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


    public static void MeasurePractice(int trial, string itemLeft, string itemMid, string itemRight, string targetItem, double reaction, int CRESP)
    {
        practice.AppendFormat(VPN + ",{6},{5},1,U{0},Practice,1,{1},{2},{3},{4}\n", trial, itemLeft, itemMid, itemRight, targetItem, reaction, CRESP);
    }
    public static void MeasurePracticeTwo(int trial, string itemLeft, string itemMid, string itemRight, string targetItem, double reaction, int CRESP)
    {
        practiceTwo.AppendFormat(VPN + ",{6},{5},2,U{0},Practice,3,{1},{2},{3},{4}\n", trial, itemLeft, itemMid, itemRight, targetItem, reaction, CRESP);
    }
    public static void MeasureTest(int trial, string itemLeft, string itemMid, string itemRight, string targetItem, double reaction, int CRESP)
    {
        test.AppendFormat(VPN + ",{6},{5},1,{0},Test,2,{1},{2},{3},{4}\n", trial, itemLeft,itemMid, itemRight, targetItem, reaction, CRESP);
    }
    public static void MeasureTestTwo(int trial, string itemLeft, string itemMid, string itemRight, string targetItem, double reaction, int CRESP)
    {
        testTwo.AppendFormat(VPN + ",{6},{5},2,{0},Test,4,{1},{2},{3},{4}\n", trial, itemLeft, itemMid, itemRight, targetItem, reaction, CRESP);
    }

    public static void ClearAllData()
    {
        CSPlay.currentTrial = 1;
        CSPlay.blockNummer = 3;
        CSPlay.correctResponse = 0;
        header.Clear();
        overall.Clear();
        results.Clear();
        test.Clear();
        practice.Clear();
        practiceTwo.Clear();
        testTwo.Clear();
        score.Clear();
        timePointsts.Clear(); //
    }

}
