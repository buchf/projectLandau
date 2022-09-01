using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corsiTextSelect : MonoBehaviour
{
    public TextMesh corsi;
    public TextMesh corsiReverse;

    public static bool checkReverse;
    // Start is called before the first frame update
    void Start()
    {
        if (Randomizer.reverse)
        {
            corsiReverse.gameObject.SetActive(true);
            corsi.gameObject.SetActive(false);
            checkReverse = true;
        }
        else
        {
            corsiReverse.gameObject.SetActive(false);
            corsi.gameObject.SetActive(true);
            checkReverse = false;
        }
    }
}
