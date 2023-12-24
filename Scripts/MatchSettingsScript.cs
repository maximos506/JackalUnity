using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchSettingsScript : MonoBehaviour
{
    public Toggle Team2, Team3, Team4;
    public Toggle Bot1, Bot2, Bot3, Bot4;
    public bool Team2ON,Team3ON,Team4ON;
    public bool Bot1ON,Bot2ON,Bot3ON,Bot4ON;
    void Start()
    {
        PlayerPrefs.SetInt("Team2", 0);
        PlayerPrefs.SetInt("Team3", 0);
        PlayerPrefs.SetInt("Team4", 0);
        PlayerPrefs.SetInt("Bot1", 0);
        PlayerPrefs.SetInt("Bot2", 0);
        PlayerPrefs.SetInt("Bot3", 0);
        PlayerPrefs.SetInt("Bot4", 0);
    }

    public void TeamSettings()
    {
        if (Team2.isOn)
        {
            PlayerPrefs.SetInt("Team2", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Team2", 0);
        }
        if (Team3.isOn)
        {
            PlayerPrefs.SetInt("Team3", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Team3", 0);
        }
        if (Team4.isOn)
        {
            PlayerPrefs.SetInt("Team4", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Team4", 0);
        }
        if (Bot1.isOn)
        {
            PlayerPrefs.SetInt("Bot1", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Bot1", 0);
        }
        if (Bot2.isOn)
        {
            PlayerPrefs.SetInt("Bot2", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Bot2", 0);
        }
        if (Bot3.isOn)
        {
            PlayerPrefs.SetInt("Bot3", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Bot3", 0);
        }
        if (Bot4.isOn)
        {
            PlayerPrefs.SetInt("Bot4", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Bot4", 0);
        }
    }

    void Update()
    {
        TeamSettings();
    }
}
