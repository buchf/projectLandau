using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSpawning : MonoBehaviour
{
    public float SekundenBisErscheinen;
    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= SekundenBisErscheinen)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
