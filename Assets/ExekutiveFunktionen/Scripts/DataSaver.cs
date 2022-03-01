using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    //Number for full programm for e.g.  (2 + 3 + 4) * 8 Trials = 72
    int amountOfFullCorsiTaskClicks =  72;


    //VPN nummer soll im gesamten project den Input vom Textfeld VPN bekommen sodass die datei auf diejenige Versuchsperson sich bezieht
    public static string VPN;
    static string fileName;

    public static string filePath;
   
    public static List<StringBuilder> results = new List<StringBuilder>();

    //z2 sind die strings fuer die sequenzen mit 2 erwarteten inputs, z3 mit 3 inputs, z4 mit 4inputs 
    public static StringBuilder z1 = new StringBuilder();
    public static StringBuilder z2 = new StringBuilder();
    public static StringBuilder z3 = new StringBuilder();
    public static StringBuilder z4 = new StringBuilder();
    public static StringBuilder z5 = new StringBuilder();


    public static int count = 1;

   


    private void Start()
    {
        
        if(SceneSwitch.reverse == true)
        {
            fileName = "VPN" + VPN + "_corsi_reverse.csv";
        }
        else
        {
            fileName = "VPN" + VPN + "_corsi.csv";
        }
        
        filePath = Path.Combine(Application.persistentDataPath, fileName);



        accuracyPercentage = float.Parse(accuracy) / amountOfFullCorsiTaskClicks * 100;
       
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

        z1.Append("Corsi\n" + ",Sequenzes correct:," + rightTask + " of " + Player.currentSequenzCounter + "\n");
        z1.Append(",Clicks Accuracy:," + accuracyPercentage.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) + "%\n" + ",total Time: ," + totalTime.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture) +"ms\n");
        z1.Append("\n,Trial no., Full Sequenz correct,Reaction Time,First click,Second click,Third click,Fourth click,Fifth click\n");
        results.Add(z1);
        results.Add(z2);
        results.Add(z3);
        results.Add(z4);
        results.Add(z5);
        File.WriteAllText(filePath, ListToString(results));

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
     * measuere writing functions and adding to the List results 
     * 
     * Drei verschieden, da es drei verschieden lange Sequenzen gibt 
     * die Funktionen werden in der Klasse Player aufgerufen mit Hilfe
     * der WriteInDatasaver() Funktion
     * 
     * Die Daten weden im Stringbuilder z2 abgespeichert und anschliessend
     * in der obigen Start() Funktion in die Liste results hinzugefuegt
     */
    public static void MeasureSequenzOne(bool fullSequenz, double reaction, int click1, int click2)
    {
        z2.AppendFormat(",sequenz{0}_2,{1},{2},{3},{4}\n", count, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1 ,click2 );
        CSVCounter();
    }
    public static void MeasureSequenzTwo(bool fullSequenz, double reaction, int click1, int click2, int click3)
    {
        z3.AppendFormat(",sequenz{0}_3,{1},{2},{3},{4},{5}\n", count, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3);
        CSVCounter();
    }
    public static void MeasureSequenzThree(bool fullSequenz, double reaction, int click1, int click2, int click3, int click4)
    {
        z4.AppendFormat(",sequenz{0}_4,{1},{2},{3},{4},{5},{6}\n", count, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4);
        CSVCounter();
    }

    public static void MeasureSequenzFour(bool fullSequenz, double reaction, int click1, int click2, int click3, int click4, int click5)
    {
        z5.AppendFormat(",sequenz{0}_5,{1},{2},{3},{4},{5},{6},{7}\n", count, fullSequenz, reaction.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture), click1, click2, click3, click4, click5);
        CSVCounter();
    }

    public static void CSVCounter()
    {
        if (Randomizer.reverse)
        {
            if (count == 1) count = 9;
            count--;
        }
        else
        {
            if (count == 8) count = 0;
            count++;
        }
    }
}
