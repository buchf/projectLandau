using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Image image;

       void Start()
    {
        image.sprite = card.artwork;
    }

}
