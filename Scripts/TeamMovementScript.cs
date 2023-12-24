using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeamMovementScript : MonoBehaviour
{
    public int TeamIndex;
    public int Team1Index,Team2Index,Team3Index,Team4Index;
    public GameObject[] Team1Players,Team2Players,Team3Players,Team4Players;
    PlayerMovementScript PlayerMovementComponent;
    PlayerTeamsScript PlayerTeamsComponent;
    public GameObject[] AllPlayers;
    public GameObject TeamText;
    TextMeshProUGUI Tmpro;
    void Start()
    {
        Tmpro = TeamText.GetComponent<TextMeshProUGUI>();
        PlayerTeamsComponent = GetComponent<PlayerTeamsScript>();
        TeamIndex = 1;
        GetTeam1Player();
        CheckTeamMove();
        AllPlayers = FindGameObjectsInLayer(6);
    }
    GameObject[] FindGameObjectsInLayer(int layer)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].layer == layer)
            {
                goList.Add(goArray[i]);
            }
        }
        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }
    public void CheckMove()
    {
        for(int i = 0; i < AllPlayers.Length;i++)
        {
            PlayerMovementScript PlayerMove = AllPlayers[i].GetComponent<PlayerMovementScript>();
            PlayerMove.UnBarrel();
        }
    }
    public void CheckTeamMove()
    {
        switch(TeamIndex)
        {
            case 1:
                SetActiveTeam1();
                break;
            case 2:
                SetActiveTeam2();
                break;
            case 3:
                SetActiveTeam3();
                break;
            case 4:
                SetActiveTeam4();
                break;
        }
    }
    public void TeamTextShow()
    {
        switch (TeamIndex)
        {
            case 1:
                Tmpro.text = "Ходит команда 1";
                break;
            case 2:
                Tmpro.text = "Ходит команда 2";
                break;
            case 3:
                Tmpro.text = "Ходит команда 3";
                break;
            case 4:
                Tmpro.text = "Ходит команда 4";
                break;
        }
    }
    public void BotChangeIndex()
    {
            switch (TeamIndex)
            {
                case 1:
                    Debug.Log("Team1");
                    Team1Index += 1;
                    if (Team1Index > 2)
                    {
                        Team1Index = 0;
                    }
                    break;
                case 2:
                    Team2Index += 1;
                    if (Team2Index > 2)
                    {
                        Team2Index = 0;
                    }
                    break;
                case 3:
                    Team3Index += 1;
                    if (Team3Index > 2)
                    {
                        Team3Index = 0;
                    }
                    break;
                case 4:
                    Team4Index += 1;
                    if (Team4Index > 2)
                    {
                        Team4Index = 0;
                    }
                    break;
            }
        CheckTeamMove();
    }
    public void ChangePlayerIndexMobile()
    {
            Debug.Log("TeamButton");
            switch (TeamIndex)
            {
                case 1:
                    Debug.Log("Team1");
                    Team1Index += 1;
                    if (Team1Index > 2)
                    {
                        Team1Index = 0;
                    }
                    break;
                case 2:
                    Team2Index += 1;
                    if (Team2Index > 2)
                    {
                        Team2Index = 0;
                    }
                    break;
                case 3:
                    Team3Index += 1;
                    if (Team3Index > 2)
                    {
                        Team3Index = 0;
                    }
                    break;
                case 4:
                    Team4Index += 1;
                    if (Team4Index > 2)
                    {
                        Team4Index = 0;
                    }
                    break;
            }
        CheckTeamMove();
    }
    public void ChangePlayerIndex()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab");
            switch(TeamIndex)
            {
                case 1:
                    Debug.Log("Team1");
                    Team1Index += 1;
                if (Team1Index > 2)
                    {
                        Team1Index = 0;
                    }
                break;
                case 2:
                    Team2Index += 1;
                    if (Team2Index > 2)
                    {
                        Team2Index = 0;
                    }
                    break;
                case 3:
                    Team3Index += 1;
                    if (Team3Index > 2)
                    {
                        Team3Index = 0;
                    }
                    break;
                case 4:
                    Team4Index += 1;
                    if (Team4Index > 2)
                    {
                        Team4Index = 0;
                    }
                    break;
            }
        }
        CheckTeamMove();
    }
    public void GetNextTeamIndex()
    {
        CheckMove();
        //Debug.Log("Doing Stuff");
        TeamIndex += 1;
        if (TeamIndex == 2)
        {
            if (PlayerTeamsComponent.Team2InGame == false)
                {
                TeamIndex = 3;
                }
        }
        if (TeamIndex == 3)
        {
            if (PlayerTeamsComponent.Team3InGame == false)
            {
                TeamIndex = 4;
            }
        }
        if (TeamIndex == 4)
        {
            if(PlayerTeamsComponent.Team4InGame == false)
            {
                TeamIndex = 5;
            }
        }
        if (TeamIndex == 5)
        {
            TeamIndex = 1;
        }
        CheckTeamMove();
    }
    public void DisableEveryone()
    {
        for(int i = 0; i < Team1Players.Length; i++)
        {
            PlayerMovementComponent = Team1Players[i].GetComponent<PlayerMovementScript>();
            PlayerMovementComponent.IsActivePlayer = false;
        }
        for (int i = 0; i < Team2Players.Length; i++)
        {
            PlayerMovementComponent = Team2Players[i].GetComponent<PlayerMovementScript>();
            PlayerMovementComponent.IsActivePlayer = false;
        }
        for (int i = 0; i < Team3Players.Length; i++)
        {
            PlayerMovementComponent = Team3Players[i].GetComponent<PlayerMovementScript>();
            PlayerMovementComponent.IsActivePlayer = false;
        }
        for (int i = 0; i < Team4Players.Length; i++)
        {
            PlayerMovementComponent = Team4Players[i].GetComponent<PlayerMovementScript>();
            PlayerMovementComponent.IsActivePlayer = false;
        }
    }
    public void SetActiveTeam1()
    {
        DisableEveryone();
        PlayerMovementComponent = Team1Players[Team1Index].GetComponent<PlayerMovementScript>();
        PlayerMovementComponent.IsActivePlayer = true;
    }
    public void SetActiveTeam2()
    {
        DisableEveryone();
        PlayerMovementComponent = Team2Players[Team2Index].GetComponent<PlayerMovementScript>();
        PlayerMovementComponent.IsActivePlayer = true;
    }
    public void SetActiveTeam3()
    {
        DisableEveryone();
        PlayerMovementComponent = Team3Players[Team3Index].GetComponent<PlayerMovementScript>();
        PlayerMovementComponent.IsActivePlayer = true;
    }
    public void SetActiveTeam4()
    {
        DisableEveryone();
        PlayerMovementComponent = Team4Players[Team4Index].GetComponent<PlayerMovementScript>();
        PlayerMovementComponent.IsActivePlayer = true;
    }
    void GetTeam1Player()
    {
        Team1Players = GameObject.FindGameObjectsWithTag("Team1");
    }
    public void GetTeam2Player()
    {
        Team2Players = GameObject.FindGameObjectsWithTag("Team2");
    }
    public void GetTeam3Player()
    {
        Team3Players = GameObject.FindGameObjectsWithTag("Team3");
    }
    public void GetTeam4Player()
    {
        Team4Players = GameObject.FindGameObjectsWithTag("Team4");
    }
    // Update is called once per frame
    void Update()
    {
        ChangePlayerIndex();
        TeamTextShow();
    }
}
