using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundScript : MonoBehaviour
{
    public int MoneytoWin = 37;
    public int Team1Money,Team2Money,Team3Money,Team4Money;
    public GameObject Team1Text,Team2Text,Team3Text,Team4Text;
    TextMeshProUGUI Text1, Text2, Text3, Text4;
    GameObject[] GroundBlocks;
    public GameObject WinScreen;
    public GameObject Team1Win,Team2Win,Team3Win,Team4Win;
    TextMeshProUGUI TextWin1, TextWin2, TextWin3, TextWin4;

    void Start()
    {
        GroundBlocks = GameObject.FindGameObjectsWithTag("Ground");
        CalculateMoney();
        Text1 = Team1Text.GetComponent<TextMeshProUGUI>();
        Text2 = Team2Text.GetComponent<TextMeshProUGUI>();
        Text3 = Team3Text.GetComponent<TextMeshProUGUI>();
        Text4 = Team4Text.GetComponent<TextMeshProUGUI>();
        TextWin1 = Team1Win.GetComponent<TextMeshProUGUI>();
        TextWin2 = Team2Win.GetComponent<TextMeshProUGUI>();
        TextWin3 = Team3Win.GetComponent<TextMeshProUGUI>();
        TextWin4 = Team4Win.GetComponent<TextMeshProUGUI>();
        WinScreen.SetActive(false);
        Team1Money = Team2Money = Team3Money = Team4Money = 0;
    }
    void CalculateMoney()
    {
        MoneytoWin = 0;
        for(int i = 0; i < GroundBlocks.Length; i++)
        {
            BlockScript BlockComponent = GroundBlocks[i].GetComponent<BlockScript>();
            if (BlockComponent.EffectID == 31)
            {
                MoneytoWin += 1;
            }
            else if (BlockComponent.EffectID == 32)
            {
                MoneytoWin += 2;
            }
            else if (BlockComponent.EffectID == 33)
            {
                MoneytoWin += 3;
            }
            else if (BlockComponent.EffectID == 34)
            {
                MoneytoWin += 4;
            }
            else if (BlockComponent.EffectID == 35)
            {
                MoneytoWin += 5;
            }
        }
    }
    public void DecreaseMoney()
    {
        MoneytoWin -= 1;
    }
    public void CheckMoney()
    {
        if (MoneytoWin <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        WinScreen.SetActive(true);
        TextWin1.text = Team1Money.ToString();
        TextWin2.text = Team2Money.ToString();
        TextWin3.text = Team3Money.ToString();
        TextWin4.text = Team4Money.ToString();
    }
    public void ShowMoneyUI()
    {
        Text1.text = Team1Money.ToString();
        Text2.text = Team2Money.ToString();
        Text3.text = Team3Money.ToString();
        Text4.text = Team4Money.ToString();
    }
    void Update()
    {
        CheckMoney();
        ShowMoneyUI();
    }
}
