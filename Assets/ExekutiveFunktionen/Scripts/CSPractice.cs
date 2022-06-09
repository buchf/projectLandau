using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        StartCoroutine(Wait(three_Flower_Yellow));
        
    }

    void Update()
    {
        
    }

    void SpawnLeft(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-200, 0, 0);
        item.SetActive(true);
    }

    void SpawnMiddle(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        item.SetActive(true);
    }

    void SpawnRight(GameObject item)
    {
        item.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(200, 0, 0);
        item.SetActive(true);
        item.GetComponent<Button>().transition = Selectable.Transition.None;
        item.GetComponent<Button>().interactable = false;
        
    }

    IEnumerator Wait(GameObject right)
    {
        yield return new WaitForSecondsRealtime(1f);
        SpawnRight(right);
    }
}
