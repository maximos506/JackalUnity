using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatScript : MonoBehaviour
{
    int ClickAmounts;
    void Start()
    {
        PlayerPrefs.SetInt("Cheat", 0);
        ClickAmounts = 0;
    }

    public void AddClick()
    {
        ClickAmounts += 1;
    }
    void Update()
    {
        if(ClickAmounts > 10)
        {
            PlayerPrefs.SetInt("Cheat", 1);
            Debug.Log("Cheat is on!");
        }
    }
}
