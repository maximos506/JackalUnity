using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoneyScript : MonoBehaviour
{
    public bool PlayerHasMoney;
    public PlayerMovementScript PlayerMovementComponent;
    public BlockScript BlockComponent;
    public GameObject EventSystem;
    public RoundScript RoundComponent;
    public AudioScript AudioComponent;
    public bool CanCollect;
    [SerializeField] private Button MoneyButton;

    void Start()
    {
        MoneyButton.onClick.AddListener(InputCheckMobile);
        CanCollect = true;
        EventSystem = GameObject.Find("EventSystem");
        AudioComponent = EventSystem.GetComponent<AudioScript>();
        RoundComponent = EventSystem.GetComponent<RoundScript>();
        PlayerMovementComponent = GetComponent<PlayerMovementScript>();
    }

    public void CollectMoney()
    {
        if (CanCollect)
        {
            BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
            if (BlockComponent.HasMoney)
            {
                BlockComponent.MoneyAmount -= 1;
                PlayerHasMoney = true;
                AudioComponent.GetMoney();
            }
        }
    }
    public void DropMoney()
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        BlockComponent.MoneyAmount += 1;
        PlayerHasMoney = false;
        AudioComponent.DropMoney();
    }
    public void DestroyMoney()
    {
        PlayerHasMoney = false;
        RoundComponent.DecreaseMoney();
    }
    public void AddTeamMoney(int TeamIndex)
    {
        switch(TeamIndex)
        {
            case 1:
                RoundComponent.Team1Money += 1;
                break;
            case 2:
                RoundComponent.Team2Money += 1;
                break;
            case 3:
                RoundComponent.Team3Money += 1;
                break;
            case 4:
                RoundComponent.Team4Money += 1;
                break;
        }
    }
    void InputCheckMobile()
    {
        if (PlayerMovementComponent.IsActivePlayer)
        {
                if (!PlayerHasMoney)
                {
                    CollectMoney();
                }
                else
                {
                    DropMoney();
                }
        }
    }
    void InputCheck()
    {
        if (PlayerMovementComponent.IsActivePlayer)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (!PlayerHasMoney)
                {
                    CollectMoney();
                }
                else
                {
                    DropMoney();
                }
            }
        }
    }
    void Update()
    {
        InputCheck();
    }
}
