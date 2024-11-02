using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pumpcoins : MonoBehaviour
{
    public int Coins = 0;
    public Text count;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Coins += 1;
            count.text = Coins.ToString();
        }
    }
}
