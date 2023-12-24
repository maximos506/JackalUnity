using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class BotMovementScript : MonoBehaviour
{
    PlayerMovementScript PlayerMoveComponent;
    public List<int> BannedID;
    public bool PathisFound;
    public GameObject[] GroundBlocks;
    public int RandomIndex;
    public float BotCheckingDistance, BotMinDistance;
    public List<GameObject> openList, closedList, Path;
    public GameObject DestinationBlock;
    public GameObject[] PathToBlock;
    public GameObject[] newReachable;
    PlayerMoneyScript MoneyComponent;
    public List<GameObject> NextBlocksList;
    public int CurrentMoveIndex;
    public GameObject ShipBlock;
    public GameObject ShipBlock1,ShipBlock2,ShipBlock3,ShipBlock4;
    public GameObject Ship;
    void Start()
    {
        MoneyComponent = GetComponent<PlayerMoneyScript>();
        StartedMove= false;
        CurrentMoveIndex = 1;
        BannedID = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19,20, 25, 26, 27, 28, 29, 30, 36, 38, 39, 40, 41 };
        PlayerMoveComponent = GetComponent<PlayerMovementScript>();
        DestinationBlock = null;
        PathToBlock = null;
        GroundBlocks = GameObject.FindGameObjectsWithTag("Ground");
        GetShipBlocks();
    }
    public void GetShipBlocks()
    {
        Ship = PlayerMoveComponent.Ship;
        PlayerMoveComponent.BlockBuffer = Ship;
        switch (PlayerMoveComponent.TeamID)
        {
            case 1:
                ShipBlock = ShipBlock1;
                break;
            case 2:
                ShipBlock = ShipBlock2;
                break;
            case 3:
                ShipBlock = ShipBlock3;
                break;
            case 4:
                ShipBlock = ShipBlock4;
                break;
        }
    }
    public GameObject ForceRandomBlock()
    {
        GameObject BotBlockBuffer = null;
        while (BotBlockBuffer == null)
        {
            RandomIndex = Random.Range(0, GroundBlocks.Length);
            BotBlockBuffer = GroundBlocks[RandomIndex];
            BotCheckingDistance = Vector3.Distance(BotBlockBuffer.transform.position, transform.position);
            if (BotCheckingDistance > BotMinDistance)
            {
                if (CheckBannedBlock(BotBlockBuffer))
                {
                    return BotBlockBuffer;
                }
            }
            BotBlockBuffer = null;
        }
        return null;
    }
    public GameObject GetRandomBlock()
    {
        GameObject BotBlockBuffer = null;
        if(MoneyComponent.PlayerHasMoney)
        {
            BotBlockBuffer = ShipBlock;
            return BotBlockBuffer;
        }
        if (!MoneyComponent.PlayerHasMoney)
        {
            for (int i = 0; i < GroundBlocks.Length; i++)
            {
                BlockScript BlockComponent = GroundBlocks[i].GetComponent<BlockScript>();
                if (BlockComponent.HasMoney)
                {
                    BotBlockBuffer = GroundBlocks[i];
                    BotCheckingDistance = Vector3.Distance(BotBlockBuffer.transform.position, transform.position);
                    if (BotCheckingDistance > BotMinDistance)
                    {
                        if (CheckBannedBlock(BotBlockBuffer))
                        {
                            return BotBlockBuffer;
                        }
                    }
                    
                }
            }
            BotBlockBuffer = null;
        }
        while (BotBlockBuffer == null)
        {
            RandomIndex = Random.Range(0, GroundBlocks.Length);
            BotBlockBuffer = GroundBlocks[RandomIndex];
            BotCheckingDistance = Vector3.Distance(BotBlockBuffer.transform.position, transform.position);
            if (BotCheckingDistance > BotMinDistance)
            {
                if (CheckBannedBlock(BotBlockBuffer))
                {
                    return BotBlockBuffer;
                }
            }
            BotBlockBuffer = null;
        }
        return null;
    }
    public void ClearStuff()
    {
        for(int i = 0; i < GroundBlocks.Length; i++)
        {
            GroundBlocks[i].GetComponent<BlockScript>().MoveCost = 1000000;
            GroundBlocks[i].GetComponent<BlockScript>().PreviousBlock = null;
        }
        openList.Clear();
        closedList.Clear();
        Path.Clear();
        NextBlocksList.Clear();
        newReachable = null;
        PathToBlock = null;
    }
    public GameObject[] GetPathBlock(GameObject GoalNode)
    {
        GameObject StartBlock = PlayerMoveComponent.BlockBuffer;
        StartBlock.GetComponent<BlockScript>().MoveCost = 0;
        openList = new List<GameObject> { StartBlock };
        closedList = new List<GameObject>();
        while (openList != null)
        {
            GameObject Node = ChooseNode(openList);
            if (Node == GoalNode)
            {
                PathisFound = true;
                return GetPath(GoalNode);
            }
            newReachable = GetNextBlocks(Node);
            openList.Remove(Node);
            closedList.Add(Node);
            //Debug.Log("Here");
            for (int i = 0; i < newReachable.Length; i++)
            {
                if (closedList.Contains(newReachable[i]))
                { continue; }
                if (openList.Contains(newReachable[i]) != true)
                {
                    openList.Add(newReachable[i]);
                    BlockScript blockscript = newReachable[i].GetComponent<BlockScript>();
                    if (Node.GetComponent<BlockScript>().MoveCost + 1 < blockscript.MoveCost)
                    {
                        if (CheckBannedBlock(newReachable[i]))
                        {
                            blockscript.PreviousBlock = Node;
                            blockscript.MoveCost = Node.GetComponent<BlockScript>().MoveCost + 1;
                        }
                    }
                }
                
            }
        }
        return null;
    }
    public GameObject ChooseNode(List<GameObject> openlist)
    {
        float MinCost = 1000000;
        GameObject BestNode = null;
        for(int i = openlist.Count - 1; i >= 0; i--)
        {
            float CostStart = openlist[i].GetComponent<BlockScript>().MoveCost;
            float CostNodetoGoal = Vector3.Distance(openlist[i].transform.position, DestinationBlock.transform.position);
            float TotalCost = CostStart + CostNodetoGoal;
            if (MinCost > TotalCost)
            {
                MinCost = TotalCost;
                BestNode = openlist[i];
            }
        }
        return BestNode;
    }
    public GameObject[] GetPath(GameObject Block)
    {
        Path = new List<GameObject>();
        while (Block != null)
        {
           Path.Add(Block);
           BlockScript blockscript = Block.GetComponent<BlockScript>();
            Block = blockscript.PreviousBlock;
        }
        return Path.ToArray();
    }
    public GameObject[] GetNextBlocks(GameObject Block)
    {
        //Debug.Log(Block);
        if(Block == null)
        {
            Debug.Log("No Block found");
            DestinationBlock = null;
            ClearStuff();
            PathisFound = false;
            StartedMove = false;
            return null;
        }
        GetNextBlocksScript NextBlockComponent = Block.GetComponent<GetNextBlocksScript>();
        NextBlocksList = new List<GameObject>();
            if (NextBlockComponent.LBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.LBlock);
            }
            if (NextBlockComponent.LUBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.LUBlock);
            }
            if (NextBlockComponent.UBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.UBlock);
            }
            if (NextBlockComponent.RUBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.RUBlock);
            }
            if (NextBlockComponent.RBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.RBlock);
            }
            if (NextBlockComponent.BRBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.BRBlock);
            }
            if (NextBlockComponent.BBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.BBlock);
            }
            if (NextBlockComponent.BLBlock != null)
            {
                NextBlocksList.Add(NextBlockComponent.BLBlock);
            }
        for(int i = NextBlocksList.Count - 1; i >= 0; i--)
        {
            if (CheckBannedBlock(NextBlocksList[i]) == false)
            {
                NextBlocksList.RemoveAt(i);
            }
            else if (NextBlocksList[i].tag != "Ground")
            {
                NextBlocksList.RemoveAt(i);
            }
        }
        if(NextBlocksList.Count == 0)
        {
            FailsCount++;
            //Debug.Log("NOTHING");
        }
        GameObject[] NextBlocksArray = NextBlocksList.ToArray();
        return NextBlocksArray;  
    }
    public int FailsCount;
    public bool CheckBannedBlock(GameObject CheckBlock)
    {
        //Debug.Log(CheckBlock);
        BlockScript BlockComponent = CheckBlock.GetComponent<BlockScript>();
        if (BlockComponent != null)
        {
            //Debug.Log(CheckBlock);
        }
        if (BannedID.Contains(BlockComponent.EffectID))
        {
            return false;
        }
        return true;
    }
    public bool StartedMove;
    public void MovementToPath()
    {
        if (!StartedMove)
        {
            CurrentMoveIndex = PathToBlock.Length - 2;
            StartedMove = true;
        }
        //Debug.Log("Moving");
        //Debug.Log("Moved to" + PathToBlock[CurrentMoveIndex]);
        GameObject MoveBuffer = PathToBlock[CurrentMoveIndex];
        if (MoveBuffer.tag == "Ground")
        {
            PlayerMoveComponent.OnShip = false;
        }
        PlayerMoveComponent.SetBlockBuffer(MoveBuffer);
        Vector3 BlockPosition = new Vector3(MoveBuffer.transform.position.x, transform.position.y, MoveBuffer.transform.position.z);
        PlayerMoveComponent.MoveToBlock(BlockPosition);
        if (MoveBuffer.GetComponent<BlockScript>().HasMoney && !MoneyComponent.PlayerHasMoney)
        {
            MoneyComponent.CollectMoney();
        }
        if (MoveBuffer != DestinationBlock)
        {
            CurrentMoveIndex -= 1;
        }
        else
        {
            if(DestinationBlock == ShipBlock)
            {
                if(MoneyComponent.PlayerHasMoney)
                {
                    MoneyComponent.DestroyMoney();
                    MoneyComponent.AddTeamMoney(PlayerMoveComponent.TeamIndex);
                }
            }
            ClearStuff();
            DestinationBlock = null;
            PathisFound = false;
            StartedMove = false;
            //Debug.Log("Reached Path");

        }
    }
    public void BotMovement()
    {
        while(DestinationBlock == null)
        {
           DestinationBlock = GetRandomBlock();
        }
        if (PathisFound == false)
        {
            PathToBlock = GetPathBlock(DestinationBlock);
        }
        else
        {
            if (PlayerMoveComponent.MazeAmount > 0)
            {
                Vector3 MovePos = new Vector3(PlayerMoveComponent.BlockBuffer.transform.position.x, transform.position.y, PlayerMoveComponent.BlockBuffer.transform.position.z);
                PlayerMoveComponent.MoveToBlock(MovePos);
            }
            else if (PlayerMoveComponent.MazeAmount <= 0)
            {
                MovementToPath();
            }
        }
        
    }
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            DestinationBlock = null;
            ClearStuff();
            PathisFound = false;
            StartedMove = false;
        }*/
    }

}
