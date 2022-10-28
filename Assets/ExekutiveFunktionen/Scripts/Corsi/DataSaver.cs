using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System.Linq;





public class DataSaver : MonoBehaviour
{


    public static string rightTask, accuracy;
    public static double totalTime;
    public float accuracyPercentage = 0.0f;

    //Number for full programm
    


    //VPN nummer soll im gesamten project den Input vom Textfeld VPN bekommen sodass die datei auf diejenige Versuchsperson sich bezieht
    public static string VPN;
    static string fileName;

    public static string filePath;
   
    public static List<StringBuilder> results = new List<StringBuilder>();

    //z2 sind die strings fuer die sequenzen mit 2 erwarteten inputs, z3 mit 3 inputs, z4 mit 4inputs 
    public static StringBuilder z1 = new StringBuilder();
    public static StringBuilder z0 = new StringBuilder();
    public static StringBuilder z2 = new StringBuilder();
    public static StringBuilder z3 = new StringBuilder();
    public static StringBuilder z4 = new StringBuilder();
    public static StringBuilder z5 = new StringBuilder();
    public static StringBuilder z6 = new StringBuilder();
    public static StringBuilder z7 = new StringBuilder();
    public static StringBuilder z8 = new StringBuilder();

    public static StringBuilder timePointcorsi = new StringBuilder(); //

    public static int count = 1;
    int i = 1;
   


    private void Start()
    {
        timePointcorsi.Clear();

        if (SceneSwitch.reverse == true)
        {
            fileName = "VPN" + VPN + "_corsi_reverse.csv";
            fileName = checkFilenameReverse(fileName);
        }
        else
        {
            fileName = "VPN" + VPN + "_corsi.csv";
            fileName = checkFilename(fileName);
        }
        
        filePath = Path.Combine(Application.persistentDataPath, fileName);

        accuracyPercentage = float.Parse(accuracy) / Randomizer.totlalAccuracyClicks * 100;

        /*
         * z1 ist die Struktur fuer die "overall" - Results
         * z1 ist zustaendig fuer die gesamten richtigen Sequenzen, die Genauigkeit 
         * der erzielten Klicks, die Gesamte benoetigte Zeit fuer die Sequenz in ms
         *
         * anschliessend wird z2 angehaengt, welche jeden input ueber die drei MeasuereSequenz Funktionen 
         * bekommt (siehe unten)
         * 
         * 
         */
        timePointcorsi.Append(VPN + ",Total score:," + rightTask + ",Date:," + System.DateTime.Now.ToString("dd/MM/yyyy") + ",Time:," + System.DateTime.Now.ToString("HH:mm:ss") + "\n\n"); //

        z1.Append("Task:,Corsi\n" + "Correct sequences:," + rightTask + "\nPresented sequences:," + Randomizer.totalTasks + "\n");
        z1.Append("Clicks accuracy:," + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%\n" + "Total time (in ms): ," + totalTime.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +"\n");
        z1.Append("\nVP_ID,Correct response,RT (in ms),Block (i.e. sequence length),Trial,First click,Second click,Third click,Fourth click,Fifth click,Sixth click,Seventh click,Eighth click\n");
        results.Add(timePointcorsi);
        results.Add(z1);
        results.Add(z0);
        results.Add(z2);
        results.Add(z3);
        results.Add(z4);
        results.Add(z5);
        results.Add(z6);
        results.Add(z7);
        results.Add(z8);
        File.WriteAllText(filePath, ListToString(results));

    }

    public string checkFilename(string fileName)
    {
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "_corsi" + "(" + i + ")" + ".csv";
            i++;
        }
        return fileName;
    }
    public string checkFilenameReverse(string fileName)
    {
        while (File.Exists(Path.Combine(Application.persistentDataPath, fileName)))
        {
            fileName = "VPN" + VPN + "_corsi_reverse" + "(" + i + ")" + ".csv";
            i++;
        }
        return fileName;
    }


    /*
     * Notwendige funktion um die Liste results in einen String umzuwandeln,
     * da die Funktion File.WriteAllText() einen String benoetigt
     */
    private string ListToString(List<StringBuilder> results)
    {
        string x = "";
        foreach (var element in results)
        {
            x = x + element.ToString();
        }
        
        return x;
    }


    /* 
     * measure writing functions and adding to the List results 
     * 
     * Acht verschiedene, da es acht verschieden lange Sequenzen gibt 
     * die Funktionen werden in der Klasse Player aufgerufen mit Hilfe
     * der WriteInDatasaver() Funktion
     * 
     * Die Daten weden im Stringbuilder z2 abgespeichert und anschliessend
     * in der obigen Start() Funktion in die Liste results hinzugefuegt
     */

    public static void MeasureSequenzZero(int fullSequenz, double reaction, int click1)
    {
        z0.AppendFormat(VPN + ",{1},{2},1,{0},{3}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1);
        CSVCounter();
    }
    public static void MeasureSequenzOne(int fullSequenz, double reaction, int click1, int click2)
    {
        z2.AppendFormat(VPN + ",{1},{2},2,{0},{3},{4}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1 ,click2 );
        CSVCounter();
    }
    public static void MeasureSequenzTwo(int fullSequenz, double reaction, int click1, int click2, int click3)
    {
        z3.AppendFormat(VPN + ",{1},{2},3,{0},{3},{4},{5}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3);
        CSVCounter();
    }
    public static void MeasureSequenzThree(int fullSequenz, double reaction, int click1, int click2, int click3, int click4)
    {
        z4.AppendFormat(VPN + ",{1},{2},4,{0},{3},{4},{5},{6}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4);
        CSVCounter();
    }

    public static void MeasureSequenzFour(int fullSequenz, double reaction, int click1, int click2, int click3, int click4, int click5)
    {
        z5.AppendFormat(VPN + ",{1},{2},5,{0},{3},{4},{5},{6},{7}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4, click5);
        CSVCounter();
    }
    public static void MeasureSequenzFive(int fullSequenz, double reaction, int click1, int click2, int click3, int click4, int click5, int click6)
    {
        z6.AppendFormat(VPN + ",{1},{2},6,{0},{3},{4},{5},{6},{7},{8}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4, click5, click6);
        CSVCounter();
    }
    //
    public static void MeasureSequenzSix(int fullSequenz, double reaction, int click1, int click2, int click3, int click4, int click5, int click6, int click7)
    {
        z7.AppendFormat(VPN + ",{1},{2},7,{0},{3},{4},{5},{6},{7},{8},{9}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4, click5, click6, click7);
        CSVCounter();
    }
    public static void MeasureSequenzSeven(int fullSequenz, double reaction, int click1, int click2, int click3, int click4, int click5, int click6, int click7, int click8)
    {
        z8.AppendFormat(VPN + ",{1},{2},8,{0},{3},{4},{5},{6},{7},{8},{9},{10}\n", count, fullSequenz, reaction.ToString("0", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4, click5, click6, click7, click8);
        CSVCounter();
    }
    //
    public static void CSVCounter() // Anzahl insgesamt absolvierter Trials
    {
            count++;
    }
}
