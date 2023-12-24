using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float DistancetoCell, MovementRange;
    public GameObject MovementMarker, OldBlockBuffer, BlockBuffer, Ship;
    public float RangeOnFoot,RangeOnShip; // 1,5 1,2
    public bool IsActivePlayer, OnShip, IsBot, InWater;
    Vector3 BlockPosition;
    RaycastHit hitObject;
    public int RandomIndex;
    public GameObject[] GroundBlocks, WaterBlocks, BotBlocksInRange;
    public float BlockToDestination;
    public GameObject CurrentBlock;
    [Header("Components")]
    BlockScript BlockScriptComponent, OldBlockScriptComponent;
    GetEffectScript GetEffectComponent;
    PlayerMoneyScript PlayerMoneyComponent;
    [Header("Other things")]
    RaycastHit CheckBlockRay;
    public LayerMask BlockLayer;
    public Vector3 CheckRayOffset;
    public bool InDirectionalBlock, MissingWalk;
    public GameObject DirectionalBlockBuffer;
    public List<GameObject> DirectionalBlocksList;
    public GameObject EventSystem;
    public AudioScript AudioComponent;
    public TeamMovementScript TeamMovementComponent;
    public float WalkTimer, TimeAmount = 1;
    public int TeamID;
    public bool CantKill, IsTrapped,UnSelectable;
    public int InBarrel,MazeAmount, IceIndex, TeamIndex;
    public bool IsKilled;
    public bool DoOnce, BarrelDoOnce;
    public GameObject PrevBlock;
    string Ship1 = "Ship1", Ship2 = "Ship2", Ship3 = "Ship3", Ship4 = "Ship4", ShipTag;
    public GetNextBlocksScript NextBlockComponent;
    public Vector3 KillVector = new Vector3(0, -5, 0);
    BotMovementScript BotMoveComponent;
    void Start()
    {
        BotMoveComponent = GetComponent<BotMovementScript>();
        MazeAmount = -1;
        InBarrel = 0;
        NextBlockComponent = GetComponent<GetNextBlocksScript>();
        EventSystem = GameObject.Find("EventSystem");
        TeamMovementComponent = EventSystem.GetComponent<TeamMovementScript>();
        AudioComponent = EventSystem.GetComponent<AudioScript>();
        PlayerMoneyComponent = GetComponent<PlayerMoneyScript>();
        GetEffectComponent = GetComponent<GetEffectScript>();
        GroundBlocks = GameObject.FindGameObjectsWithTag("Ground");
        WaterBlocks = GameObject.FindGameObjectsWithTag("ShoreWater");
        MovementMarker = GameObject.Find("MovementMarker");
        GetShipTag();
    }
    void Update()
    {
        GetTeamIndex();
        if(TeamIndex == 1)
        {
            int CheatInt = PlayerPrefs.GetInt("Cheat");
            if (CheatInt == 1)
            {
                CantKill = true;
            }
        }
        WalkingTimer();
        if (BlockBuffer == null)
        {
            Debug.Log("Oops");
        }
        //GetBlockInfo();
        if (OnShip) // если на корабле, то нельзя ходить по диагонали
        {
            MovementRange = RangeOnShip;
        }
        else
        {
            MovementRange = RangeOnFoot; // если вне корабля, можно ходить по диагонали
        }
        if (IsBot && IsActivePlayer)
        {
            BotMovement(); // если игрок бот - включить ИИ
        }
        else if (!IsBot)
        {
            if (IsActivePlayer && WalkTimer < 0.1f) // иначе ходит пользователь
            {
                PlayerMovement();
            }
        }
        StickPlayerToShip(); // засунуть игрока на корабль, если он зашел на блок с ним
        CheckBarrel();
        CheckMaze();
        CheckTrap();
    }
    public void GetTeamIndex()
    {
        switch (transform.tag)
        {
            case "Team1":
                TeamIndex = 1;
                break;
            case "Team2":
                TeamIndex = 2;
                break;
            case "Team3":
                TeamIndex = 3;
                break;
            case "Team4":
                TeamIndex = 4;
                break;
        }
    }
    public void GetShipTag()
    {
        switch (TeamID)
        {
            case 1:
                ShipTag = Ship1;
                break;
            case 2:
                ShipTag = Ship2;
                break;
            case 3:
                ShipTag = Ship3;
                break;
            case 4:
                ShipTag = Ship4;
                break;
        }
    }
    public void CheckTrap()
    {
        if (IsTrapped)
        {
            RangeOnFoot = 0.5f;
        }
    }
    public void GetBarreled()
    {
        if (InBarrel == 0)
        {
            InBarrel = 3;
        }
    }
    public void UnBarrel()
    {
        if (InBarrel > 0)
        {
            InBarrel -= 1;
        }
    }
    public void CheckBarrel()
    {
        if (InBarrel > 0)
        {
            BarrelDoOnce = true;
            RangeOnFoot = 0.5f;
        }
        else if (BarrelDoOnce == true)
        {
            RangeOnFoot = 1.5f;
            BarrelDoOnce = false;
        }
    }
    public void CheckMaze()
    {
        if (MazeAmount > 0)
        {
            DoOnce = true;
            RangeOnFoot = 0.5f;
        }
        else if (DoOnce == true && MazeAmount <= 0)
        {
            DoOnce = false;
            RangeOnFoot = 1.5f;
        }
    }
    public void SetMaze(int Amount)
    {
        if (MazeAmount == -1)
        {
            MazeAmount = Amount;
        }
    }
    public void MazeDecrease()
    {
        if (MazeAmount >= 0)
        {
            MazeAmount-= 1;
        }
    }
    public void WalkingTimer()
    {
        if (IsActivePlayer)
        {
            if (WalkTimer > 0.1f)
            {
                WalkTimer -= Time.deltaTime;
            }
        }
        else
        {
            WalkTimer = TimeAmount;
        }
    }

    public void BotMovement()
    {
        BotMoveComponent.BotMovement();
    }

 
    
    public void StickPlayerToShip()
    {
        if (OnShip)
        {
            Vector3 ShipPosition = new Vector3(Ship.transform.position.x, transform.position.y, Ship.transform.position.z);
            transform.position = ShipPosition;
        }
    }
    public void PlayerMovement()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // луч от камеры до позиции, куда кликнул мышью пользователь
        if (Physics.Raycast(ray, out hitObject, 100)) // если луч достал до объекта и игрок может ходить
        {
            //Debug.Log(hitObject.transform.gameObject.name);
            BlockPosition = new Vector3(hitObject.transform.position.x, transform.position.y, hitObject.transform.position.z); // взять координату полученного объекта
            DistancetoCell = Vector3.Distance(hitObject.transform.position, transform.position); // расстояние от игрока до объекта
            if (DistancetoCell < MovementRange && DistancetoCell > 0.5) // если игрок может пойти на блок, подсветить его
            {
                MovementMarker.SetActive(true);
                MovementMarker.transform.position = BlockPosition;
            }
            else
            {
                MovementMarker.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (DistancetoCell < MovementRange) // если расстояние позволяет пойти на блок, проверить этот блок
                {
                    CheckBlock(hitObject.transform.gameObject.tag);
                }
                //Debug.Log(DistancetoCell);
            }
        }
    }
    public void GetBlockInfo() // не используется, получить инфу о блоке, на котором стоим игрок путем рейкаста
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        if (Physics.Raycast(transform.position + CheckRayOffset, Vector3.down, out CheckBlockRay, 100,BlockLayer))
        {
            SetBlockBuffer(CheckBlockRay.transform.gameObject);
            //Debug.Log("Got Block :" + CheckBlockRay.transform.gameObject.name);
        }
    }
    public void MoveToBlock(Vector3 BlockPos) // перейти на блок
    {
        AudioComponent.PlayMoveSound();
        if (IsActivePlayer)
        {
            MazeDecrease();
            transform.position = BlockPos;
            BlockScriptComponent = BlockBuffer.GetComponent<BlockScript>();
            OldBlockScriptComponent = OldBlockBuffer.GetComponent<BlockScript>();
            if (BlockScriptComponent != null)
            {
                BlockScriptComponent.isDiscovered = true;
                OldBlockScriptComponent.DeletePlayerFromBlock(transform.gameObject);
                BlockScriptComponent.AddPlayerToBlock(transform.gameObject);
                GetDistance();
                GetEffectComponent.IdentifyEffect(BlockScriptComponent.EffectID);
            }
            BeatPlayers();
            //TeamMovementComponent.GetNextTeamIndex();
        }
    }
    public void GetDistance()
    {
        Vector3 Distance = BlockBuffer.transform.position - OldBlockBuffer.transform.position;
        //Debug.Log(Distance);
        IceIndex = NextBlockComponent.GetMoveDirection(Distance);
    }
    public void BeatPlayers()
    {
        for(int i = 0; i < BlockScriptComponent.PlayersInBlock.Count; i++)
        {
            PlayerMovementScript PlayerMoveComponent = BlockScriptComponent.PlayersInBlock[i].gameObject.GetComponent<PlayerMovementScript>();
            if (PlayerMoveComponent.TeamID != TeamID && PlayerMoveComponent.CantKill == false)
            {
                if (PlayerMoveComponent.MazeAmount == MazeAmount)
                {
                    PlayerMoveComponent.GetBeaten();
                }
            }
        }
    }
    public void GetBeaten()
    {
        if (PlayerMoneyComponent.PlayerHasMoney)
        {
            PlayerMoneyComponent.DropMoney();
        }
        if (IsBot)
        {
            
            GameObject ShipBlock = BotMoveComponent.Ship;
            SetBlockBuffer(Ship);
            Vector3 BlockPosition = new Vector3(Ship.transform.position.x, transform.position.y, Ship.transform.position.z);
            MoveToBlock(BlockPosition);
            BotMoveComponent.ClearStuff();
            BotMoveComponent.DestinationBlock = null;
            BotMoveComponent.PathisFound = false;
            BotMoveComponent.StartedMove = false;
        }
        AudioComponent.BeatSound();
        Debug.Log("Beaten!!!");
        MazeAmount = 0;
        InBarrel = 0;
        OnShip = true;
        RangeOnFoot = 1.5f;
    }
    public void GetKilled()
    {
        if(!InWater)
        {
            if (PlayerMoneyComponent.PlayerHasMoney)
            {
                PlayerMoneyComponent.DestroyMoney();
            }
        }
        transform.position = KillVector;
        BlockScriptComponent.DeletePlayerFromBlock(transform.gameObject);
        RangeOnFoot = 0f;
        IsKilled = true;
        PlayerMoneyComponent.CanCollect = false;
    }
    public void GetRestored(GameObject RestoredBlock)
    {
        IsKilled = false;
        Vector3 RestorePosition = new Vector3(RestoredBlock.transform.position.x, (0.45f), RestoredBlock.transform.position.z);
        //Debug.Log("RESTORED");
        RangeOnFoot = 1.5f;
        MoveToBlock(RestorePosition);
        transform.position = RestorePosition;
        PlayerMoneyComponent.CanCollect = true;
    }
    public void CheckBlock(string BlockTag) // проверить блок
    {
        //Debug.Log("ShipTAG = " + ShipTag);
        //Debug.Log(BlockTag);
        if(BlockTag == "ShoreWater") 
        {
            if(InWater && !OnShip)
            {
                SetBlockBuffer(hitObject.transform.gameObject);
                InWater = true;
                OnShip = false;
                MoveToBlock(BlockPosition);
                if (PlayerMoneyComponent.PlayerHasMoney)
                {
                    PlayerMoneyComponent.DestroyMoney();
                }
            }
            if(OnShip) // если блок - вода и игрок на корабле, подвинуть корабль и игроков с ним
            {
                SetBlockBuffer(hitObject.transform.gameObject);
                BlockPosition = new Vector3(hitObject.transform.position.x, Ship.transform.position.y, hitObject.transform.position.z);
                Ship.transform.position = BlockPosition;
                TeamMovementComponent.GetNextTeamIndex();
            }
            if (InDirectionalBlock)
            {
                for (int i = 0; i < DirectionalBlocksList.Count; i++)
                {
                    if (hitObject.transform.gameObject == DirectionalBlocksList[i])
                    {
                        SetBlockBuffer(hitObject.transform.gameObject);
                        BlockScript BlockComponent = BlockBuffer.GetComponent<BlockScript>();
                        MoveToBlock(BlockPosition);
                        //PlayerMoneyComponent.PlayerHasMoney = false;
                        InDirectionalBlock = false;
                        RangeOnFoot = 1.5f;
                        if (PlayerMoneyComponent.PlayerHasMoney)
                        {
                            PlayerMoneyComponent.DestroyMoney();
                        }
                        InWater = true;
                        break;
                    }
                }
            }
        }
        else if (BlockTag == ShipTag)
        {
            if (InDirectionalBlock)
            {
                InDirectionalBlock = false;
            }
            SetBlockBuffer(hitObject.transform.gameObject); // если блок с кораблем, зайти на корабль
            if (PlayerMoneyComponent.PlayerHasMoney) // если игрок зашел на корабль с монетой, то монета переходит на корабль и команда получает очко
            {
                PlayerMoneyComponent.DestroyMoney();
                PlayerMoneyComponent.AddTeamMoney(TeamIndex);
            }
            InWater = false;
            OnShip = true;
            TeamMovementComponent.GetNextTeamIndex();
            RangeOnFoot = 1.5f;
        }
        else if (BlockTag == "Ground" && !InWater)
        {
            if (InDirectionalBlock) // если игрок попал на блок со стрелкой, проверить, соответсвует ли нажатый блок блоку, на который указывает стрелка
            {
                for (int i = 0; i < DirectionalBlocksList.Count; i++)
                {
                    if (hitObject.transform.gameObject == DirectionalBlocksList[i])
                    {
                        SetBlockBuffer(hitObject.transform.gameObject);
                        BlockScript BlockComponent = BlockBuffer.GetComponent<BlockScript>();
                        MoveToBlock(BlockPosition);
                        InWater = false;
                        if (BlockComponent.IsDirectionalBlock == false)
                        {
                            InDirectionalBlock = false;
                        }
                        RangeOnFoot = 1.5f;
                        break;
                    }
                }
            }
            else
            {
                // пойти на указанный блок
                RangeOnFoot = 1.5f;
                BlockScript HitComponent = hitObject.transform.gameObject.GetComponent<BlockScript>();
                if ((HitComponent.CantEnterWithMoney == false) || (HitComponent.CantEnterWithMoney == true && PlayerMoneyComponent.PlayerHasMoney == false))
                {
                    SetBlockBuffer(hitObject.transform.gameObject);
                    BlockScript BlockComponent = BlockBuffer.GetComponent<BlockScript>();

                    if (BlockComponent.IsOccupied == false || BlockComponent.OccupyIndex == TeamIndex)
                    {
                        if ((BlockComponent.CantEnterWithMoney == false) || (BlockComponent.CantEnterWithMoney == true && PlayerMoneyComponent.PlayerHasMoney == false))
                        {
                            InWater = false;
                            OnShip = false;
                            MoveToBlock(BlockPosition);
                        }
                    }
                }
            }
        }
    }
    public void SetBlockBuffer(GameObject BlockObject)
    {
        if (BlockBuffer != null)
        {
            OldBlockBuffer = BlockBuffer;
        }
        BlockBuffer = BlockObject;
    }
}
