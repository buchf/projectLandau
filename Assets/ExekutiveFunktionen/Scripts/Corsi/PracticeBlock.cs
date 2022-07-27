using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeBlock : MonoBehaviour
{

    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnMouseDown()
    {

        player.increaseClick();
        if (gameObject.CompareTag("Block"))
        {
            player.clickedBlocks.Add(gameObject);
            StartCoroutine(ClickTimeAnimation());
        }
    }

    IEnumerator ClickTimeAnimation()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        yield return new WaitForSeconds(.2f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        CorsiPractice.clickedBlocks++;
    }
}
