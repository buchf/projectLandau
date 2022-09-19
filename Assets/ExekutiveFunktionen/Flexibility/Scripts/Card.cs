using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards")]
public class Card : ScriptableObject
{
    public new string name;
    public string color;
    public int number;
    public string shape;
    public Sprite artwork;
    

    public void print()
    {
       // Debug.Log(name + ": " + color + ", " + number + ", " + shape);
    }
}
