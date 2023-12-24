using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEffectScript : MonoBehaviour
{
    public PlayerMovementScript PlayerMovementComponent;
    public GetNextBlocksScript GetNextBlocksComponent;
    public PlayerMoneyScript PlayerMoneyComponent;
    public BlockScript BlockComponent;
    public Vector3 TempVector;
    List<GameObject> DirectionalBlocks;
    public GameObject EventSystem;
    public GameObject BlockMove;
    public TeamMovementScript TeamMovementComponent;
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        TeamMovementComponent = EventSystem.GetComponent<TeamMovementScript>();
        PlayerMoneyComponent = GetComponent<PlayerMoneyScript>();
        PlayerMovementComponent = GetComponent<PlayerMovementScript>();
        GetNextBlocksComponent = GetComponent<GetNextBlocksScript>();
    }

    public void IdentifyEffect(int effectId)
    {
        switch(effectId)
        {
            case 0:
                RegularBlock();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 1:
                DirectionalMoveUp();
                break;
            case 2:
                DirectionalMoveDown();
                break;
            case 3:
                DirectionalMoveLeft();
                break;
            case 4:
                DirectionalMoveRight();
                break;
            case 5:
                DirectionalUpRight();
                break;
            case 6:
                DirectionalUpLeft();
                break;
            case 7:
                DirectionalDownRight();
                break;
            case 8:
                DirectionalDownLeft();
                break;
            case 9:
                DirectionalDiagonalDLUR();
                break;
            case 10:
                DirectionalDiagonalDRUL();
                break;
            case 11:
                DirectionalRightLeft();
                break;
            case 12:
                DirectionalUpDown();
                break;
            case 13:
                DirectionalThreeSides1();
                break;
            case 14:
                DirectionalThreeSides2();
                break;
            case 15:
                DirectionalThreeSides3();
                break;
            case 16:
                DirectionalThreeSides4();
                break;
            case 17:
                DirectionalStraightAll();
                break;
            case 18:
                DirectionalDiagonalAll();
                break;
            case 19:
                DirectionalHorse();
                break;
            case 20:
                Barrel();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 21:
                Maze_2();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 22:
                Maze_3();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 23:
                Maze_4();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 24:
                Maze_5();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 25:
                DirectionalIce();
                break;
            case 26:
                Trap();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 27:
                DirectionalAnimal();
                break;
            case 28:
                Killer();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 29:
                SafePlace();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 30:
                PlayerReturner();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 31:
                MoneyChest_1();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 32:
                MoneyChest_2();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 33:
                MoneyChest_3();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 34:
                MoneyChest_4();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 35:
                MoneyChest_5();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 36:
                DirectionalBalloon();
                TeamMovementComponent.GetNextTeamIndex();
                break;
            case 37:
                DirectionalPlane();
                break;
            case 38:
                DirectionalCannonForward();
                break;
            case 39:
                DirectionalCannonRight();
                break;
            case 40:
                DirectionalCannonLeft();
                break;
            case 41:
                DirectionalCannonBack();
                break;
            case 42:
                WaterBlock();
                TeamMovementComponent.GetNextTeamIndex();
                break;
        }
    }
    void RegularBlock() // 0 ������ - ����������� ����
    {
        //PlayerMovementComponent.CanWalk = false;
    }
    void DirectionalMoveUp() // 1 ������ - �������� �����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.UBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Up");
    }
    void DirectionalMoveDown() // 2 ������ - �������� ����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Down");
    }
    void DirectionalMoveLeft() // 3 ������ - �������� �����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.LBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Left");
    }
    void DirectionalMoveRight() // 4 ������ - �������� ������
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.RBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Right");
    }
    void DirectionalUpRight() // 5 ������ - �������� ��������� ������ �����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.RUBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalUpLeft() // 6 ������ - �������� ��������� ����� �����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.LUBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDownRight() // 7 ������ - �������� ��������� ������ ����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BRBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDownLeft() // 8 ������ - �������� ��������� ����� ����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BLBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDiagonalDLUR() // 9 - ��������� �� ����� ����� ����� ������ ������
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BLBlock,
            GetNextBlocksComponent.RUBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDiagonalDRUL() // 10 - ��������� �� ����� ����� ������ ������ �����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BRBlock,
            GetNextBlocksComponent.LUBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalRightLeft() // 11 - ����� �� ����� ( ���� - �����)
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.RBlock,
            GetNextBlocksComponent.LBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalUpDown() // 12 - ����� �� ����� (����� - ������)
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.UBlock,
            GetNextBlocksComponent.BBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalThreeSides1() // 13 ��� ������� (��������� ����� ������, ����� � �����)
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.LUBlock,
            GetNextBlocksComponent.BBlock,
            GetNextBlocksComponent.RBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalThreeSides2() // 14 ��� ������� (��������� ������ ������, ����� � �����)
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.RUBlock,
            GetNextBlocksComponent.BBlock,
            GetNextBlocksComponent.LBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalThreeSides3() // 15 ��� ������� (��������� ������ �����, ������ � �����)
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BRBlock,
            GetNextBlocksComponent.UBlock,
            GetNextBlocksComponent.LBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalThreeSides4() // 16 ��� ������� (��������� ����� �����, ������ � ������)
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BLBlock,
            GetNextBlocksComponent.UBlock,
            GetNextBlocksComponent.RBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalStraightAll() // 17 ����� ��� �������
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.UBlock,
            GetNextBlocksComponent.BBlock,
            GetNextBlocksComponent.RBlock,
            GetNextBlocksComponent.LBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDiagonalAll() // 18 ��������� ��� �������
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.LUBlock,
            GetNextBlocksComponent.RUBlock,
            GetNextBlocksComponent.BLBlock,
            GetNextBlocksComponent.BRBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalHorse() // 19 ��� �����
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.H_LUBlock,
            GetNextBlocksComponent.H_RUBlock,
            GetNextBlocksComponent.H_LBBlock,
            GetNextBlocksComponent.H_RBBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        PlayerMovementComponent.RangeOnFoot = 5;
    }
    void Barrel() // 20 �����
    {
        PlayerMovementComponent.GetBarreled();
        if (PlayerMovementComponent.IsBot)
        {
            TeamMovementComponent.BotChangeIndex();
        }
    }
    void Maze_2() // 21 �������� 2 �����
    {
        PlayerMovementComponent.SetMaze(2);
    }
    void Maze_3() // 22 �������� 3 �����
    {
        PlayerMovementComponent.SetMaze(3);
    }
    void Maze_4() // 23 �������� 4 �����
    {
        PlayerMovementComponent.SetMaze(4);
    }
    void Maze_5() // 24 �������� 5 �����
    {
        PlayerMovementComponent.SetMaze(5);
    }
    void DirectionalIce() // 25 ���
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        int IceIndex = PlayerMovementComponent.IceIndex;
        switch(IceIndex)
        {
            case 1:
                BlockMove = GetNextBlocksComponent.LBlock;
                break;
            case 2:
                BlockMove = GetNextBlocksComponent.RBlock;
                break;
            case 3:
                BlockMove = GetNextBlocksComponent.UBlock;
                break;
            case 4:
                BlockMove = GetNextBlocksComponent.BBlock;
                break;
            case 5:
                BlockMove = GetNextBlocksComponent.LUBlock;
                break;
            case 6:
                BlockMove = GetNextBlocksComponent.RUBlock;
                break;
            case 7:
                BlockMove = GetNextBlocksComponent.BLBlock;
                break;
            case 8:
                BlockMove = GetNextBlocksComponent.BRBlock;
                break;
        }
        DirectionalBlocks = new List<GameObject>
        {
            BlockMove
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void Trap() // 26 ������
    {
        BlockScript BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if(BlockComponent.HasPlayer)
        {
            for (int i = 0; i < BlockComponent.PlayersInBlock.Count; i++)
            {
                PlayerMovementScript PlayerBlockMove = BlockComponent.PlayersInBlock[i].GetComponent<PlayerMovementScript>();
                if (BlockComponent.PlayersInBlock[i] != gameObject)
                {
                    PlayerBlockMove.IsTrapped = false;
                    PlayerBlockMove.RangeOnFoot = 1.5f;
                }
            }
        }
        else
        {
            PlayerMovementComponent.IsTrapped = true;
        }
    }
    void DirectionalAnimal() // 27 ��������
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            PlayerMovementComponent.OldBlockBuffer
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void Killer() // 28 ������
    {
        PlayerMovementComponent.GetKilled();
        if (PlayerMovementComponent.IsBot)
        {
            TeamMovementComponent.BotChangeIndex();
        }
    }
    void SafePlace() // 29 ��������
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        BlockComponent.IsShelter = true;
    }
    void PlayerReturner() // 30 ����������
    {
        GameObject RestoredBlock = PlayerMovementComponent.BlockBuffer;
        GameObject[] AllPlayers = GameObject.FindGameObjectsWithTag(gameObject.tag);
        for(int i = 0; i < AllPlayers.Length; i++)
        {
            PlayerMovementScript playermovecomponent = AllPlayers[i].GetComponent<PlayerMovementScript>();
            if (playermovecomponent.IsKilled)
            {
                Debug.Log("Player is restored");
                playermovecomponent.GetRestored(RestoredBlock);
                for(int j = 0; j < AllPlayers.Length; j++)
                {
                    PlayerMovementScript playermovecomponent1 = AllPlayers[j].GetComponent<PlayerMovementScript>();
                    playermovecomponent1.GetBarreled();
                }
                break;
            }
        }
    }
    void MoneyChest_1() // 31 ������ 1 ������
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 1;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_2() // 32 ������ 2 ������
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 2;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_3() // 33 ������ 3 ������
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 3;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_4() // 34 ������ 4 ������
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 4;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_5() // 35 ������ 5 �����
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 5;
            BlockComponent.isActivated = true;
        }
    }
    void DirectionalBalloon() // 36 ��������� ���
    {
        PlayerMovementComponent.OnShip = true;
        PlayerMoneyComponent.DestroyMoney();
        PlayerMoneyComponent.AddTeamMoney(PlayerMovementComponent.TeamIndex);
    }
    void DirectionalPlane() // 37 �������
    {
        PlayerMovementComponent.RangeOnFoot = 100;
    }
    void DirectionalCannonForward() // 38 ����� ������
    {
        PlayerMovementComponent.RangeOnFoot = 100;
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.WaterUP
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Water UP");
    }
    void DirectionalCannonRight() // 39 ����� ������
    {
        PlayerMovementComponent.RangeOnFoot = 100;
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.WaterRight
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Water RIGHT");
    }
    void DirectionalCannonLeft() // 40 ����� �����
    {
        PlayerMovementComponent.RangeOnFoot = 100;
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.WaterLeft
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Water LEFT");
    }
    void DirectionalCannonBack() // 41 ����� �����
    {
        PlayerMovementComponent.RangeOnFoot = 100;
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.WaterDOWN
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
        Debug.Log("Moved Water DOWN");
    }
    void WaterBlock() // 42 ����
    {
        PlayerMoneyComponent.DropMoney();
    }

    void Update()
    {

    }
}
