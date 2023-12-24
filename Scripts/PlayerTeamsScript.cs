using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeamsScript : MonoBehaviour
{
    public int PlayerTeamsAmount;
    public GameObject Team1, Team2, Team3, Team4;
    public GameObject Team1Ship, Team2Ship, Team3Ship, Team4Ship;
    public GameObject[] Team1Players, Team2Players, Team3Players, Team4Players;
    public bool Team1AI,Team2AI,Team3AI,Team4AI;
    public bool Team1InGame,Team2InGame,Team3InGame,Team4InGame;
    public GameObject PlayerObject,TeamShip;
    PlayerMovementScript PlayerMovementComponent;
    public Sprite Team1Sprite,Team2Sprite,Team3Sprite,Team4Sprite;
    public SpriteRenderer SpriteComponent;
    public GameObject SpriteObject;
    TeamMovementScript TeamMovementComponent;
    ChangeMaterialScript MaterialComponent;
    public bool DoLoadData;
    void Start()
    {
        PlayerObject = GameObject.Find("Player_1");
        TeamShip = GameObject.Find("Team1_Ship");
        TeamMovementComponent = GetComponent<TeamMovementScript>();
        if (DoLoadData)
        {
            LoadTeamData();
        }
        CheckTeams();
    }

    void Update()
    {
        
    }

    public void LoadTeamData()
    {
        if(PlayerPrefs.GetInt("Team2") == 1)
        {
            Team2InGame = true;
        }
        if (PlayerPrefs.GetInt("Team3") == 1)
        {
            Team3InGame = true;
        }
        if (PlayerPrefs.GetInt("Team4") == 1)
        {
            Team4InGame = true;
        }
        if (PlayerPrefs.GetInt("Bot1") == 1)
        {
            Team1AI = true;
        }
        if (PlayerPrefs.GetInt("Bot2") == 1)
        {
            Team2AI = true;
        }
        if (PlayerPrefs.GetInt("Bot3") == 1)
        {
            Team3AI = true;
        }
        if (PlayerPrefs.GetInt("Bot4") == 1)
        {
            Team4AI = true;
        }
    }
    void CheckTeams()
    {
        if (Team2InGame)
        {
            Team2 = new GameObject("Team2");
            GameObject CreatedShip2 = Instantiate(TeamShip);
            CreatedShip2.transform.parent = Team2.transform;
            CreatedShip2.name = ("Team2_Ship");
            CreatedShip2.tag = "Ship2";
            CreatedShip2.transform.position = new Vector3((-5.099f), (0.673f), (13.44f));
            CreatedShip2.transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            for (int i = 0; i < 3; i++)
            {
                GameObject CreatedPlayer = Instantiate(PlayerObject);
                switch(i)
                {
                    case 0:
                        CreatedPlayer.name = ("Player_1");
                        break;
                    case 1:
                        CreatedPlayer.name = ("Player_2");
                        break;
                    case 2:
                        CreatedPlayer.name = ("Player_3");
                        break;
                }
                CreatedPlayer.tag = ("Team2");
                CreatedPlayer.transform.parent = Team2.transform;
                CreatedPlayer.transform.position += new Vector3(0f, (-0.561f), 0f);
                SpriteObject = CreatedPlayer.transform.GetChild(1).gameObject;
                SpriteComponent = SpriteObject.GetComponent<SpriteRenderer>();
                SpriteComponent.sprite = Team2Sprite;
                PlayerMovementComponent = CreatedPlayer.GetComponent<PlayerMovementScript>();
                PlayerMovementComponent.IsBot = Team2AI;
                PlayerMovementComponent.IsActivePlayer = false;
                PlayerMovementComponent.Ship = CreatedShip2;
                PlayerMovementComponent.TeamID = 2;
                //MaterialComponent = CreatedPlayer.GetComponent<ChangeMaterialScript>();
                //MaterialComponent.SetMaterial(1);
            }
            TeamMovementComponent.GetTeam2Player();
        }
        if(Team3InGame)
        {
            Team3 = new GameObject("Team3");
            GameObject CreatedShip3 = Instantiate(TeamShip);
            CreatedShip3.transform.parent = Team3.transform;
            CreatedShip3.name = ("Team3_Ship");
            CreatedShip3.tag = "Ship3";
            CreatedShip3.transform.position = new Vector3((0.883f), (0.673f), (7.472f));
            for (int i = 0; i < 3; i++)
            {
                GameObject CreatedPlayer = Instantiate(PlayerObject);
                switch (i)
                {
                    case 0:
                        CreatedPlayer.name = ("Player_1");
                        break;
                    case 1:
                        CreatedPlayer.name = ("Player_2");
                        break;
                    case 2:
                        CreatedPlayer.name = ("Player_3");
                        break;
                }
                CreatedPlayer.tag = ("Team3");
                CreatedPlayer.transform.parent = Team3.transform;
                CreatedPlayer.transform.position += new Vector3(0f, (-0.561f), 0f);
                SpriteObject = CreatedPlayer.transform.GetChild(1).gameObject;
                SpriteComponent = SpriteObject.GetComponent<SpriteRenderer>();
                SpriteComponent.sprite = Team3Sprite;
                PlayerMovementComponent = CreatedPlayer.GetComponent<PlayerMovementScript>();
                PlayerMovementComponent.IsBot = Team3AI;
                PlayerMovementComponent.IsActivePlayer = false;
                PlayerMovementComponent.Ship = CreatedShip3;
                PlayerMovementComponent.TeamID = 3;
                //MaterialComponent = CreatedPlayer.GetComponent<ChangeMaterialScript>();
                //MaterialComponent.SetMaterial(2);
            }
            TeamMovementComponent.GetTeam3Player();
        }
        if(Team4InGame)
        {
            Team4 = new GameObject("Team4");
            GameObject CreatedShip4 = Instantiate(TeamShip);
            CreatedShip4.transform.parent = Team4.transform;
            CreatedShip4.name = ("Team4_Ship");
            CreatedShip4.tag = "Ship4";
            CreatedShip4.transform.position = new Vector3((-5.13f), (0.673f), (1.53f));
            CreatedShip4.transform.GetChild(0).gameObject.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));
            for (int i = 0; i < 3; i++)
            {
                GameObject CreatedPlayer = Instantiate(PlayerObject);
                switch (i)
                {
                    case 0:
                        CreatedPlayer.name = ("Player_1");
                        break;
                    case 1:
                        CreatedPlayer.name = ("Player_2");
                        break;
                    case 2:
                        CreatedPlayer.name = ("Player_3");
                        break;
                }
                CreatedPlayer.tag = ("Team4");
                CreatedPlayer.transform.parent = Team4.transform;
                CreatedPlayer.transform.position += new Vector3(0f, (-0.561f), 0f);
                SpriteObject = CreatedPlayer.transform.GetChild(1).gameObject;
                SpriteComponent = SpriteObject.GetComponent<SpriteRenderer>();
                SpriteComponent.sprite = Team4Sprite;
                PlayerMovementComponent = CreatedPlayer.GetComponent<PlayerMovementScript>();
                PlayerMovementComponent.IsBot = Team4AI;
                PlayerMovementComponent.IsActivePlayer = false;
                PlayerMovementComponent.Ship = CreatedShip4;
                PlayerMovementComponent.TeamID = 4;
                //MaterialComponent = CreatedPlayer.GetComponent<ChangeMaterialScript>();
                //MaterialComponent.SetMaterial(3);
            }
            TeamMovementComponent.GetTeam4Player();
        }
    }


}
