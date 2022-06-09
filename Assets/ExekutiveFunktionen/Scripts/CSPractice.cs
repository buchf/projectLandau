using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSPractice : MonoBehaviour
{
    //Practice Trial 1
    public GameObject one_Fairy_Red;
    public GameObject two_Fairy_Yellow;
    public GameObject three_Flower_Yellow;

    //Practice Trial 2
    public GameObject two_Flower_Blue;
    public GameObject three_Hat_Blue;
    public GameObject two_Fairy_Red;

    //Practice Trial 3
    public GameObject one_Flower_Red;
    public GameObject one_Hat_Yellow;
    public GameObject two_Hat_Blue;


    void Start()
    {
        SpawnLeft(one_Fairy_Red);
        SpawnMiddle(two_Fairy_Yellow);
        SpawnRight(three_Flower_Yellow);
    }

    void Update()
    {
        
    }

    void SpawnLeft(GameObject item)
    {
        // item.transform.SetParent(GameObject.FindGameObjectWithTag("ContentFactory").transform);
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-200, 0, 0);
    }

    void SpawnMiddle(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
    }

    void SpawnRight(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(200, 0, 0);
    }
}
