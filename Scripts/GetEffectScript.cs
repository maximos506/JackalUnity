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
    void RegularBlock() // 0 эффект - стандартный блок
    {
        //PlayerMovementComponent.CanWalk = false;
    }
    void DirectionalMoveUp() // 1 эффект - движение вверх
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
    void DirectionalMoveDown() // 2 эффект - движение вниз
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
    void DirectionalMoveLeft() // 3 эффект - движение влево
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
    void DirectionalMoveRight() // 4 эффект - движение вправо
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
    void DirectionalUpRight() // 5 эффект - движение диагональ вправо вверх
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.RUBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalUpLeft() // 6 эффект - движение диагональ влево вверх
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.LUBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDownRight() // 7 эффект - движение диагональ вправо вниз
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BRBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDownLeft() // 8 эффект - движение диагональ влево вниз
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            GetNextBlocksComponent.BLBlock
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void DirectionalDiagonalDLUR() // 9 - диагональ на выбор назад влево вперед вправо
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
    void DirectionalDiagonalDRUL() // 10 - диагональ на выбор назад вправо вперед влево
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
    void DirectionalRightLeft() // 11 - прямо на выбор ( лево - право)
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
    void DirectionalUpDown() // 12 - прямо на выбор (назад - вперед)
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
    void DirectionalThreeSides1() // 13 три стороны (диагональ влево вперед, назад и право)
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
    void DirectionalThreeSides2() // 14 три стороны (диагональ вправо вперед, назад и влево)
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
    void DirectionalThreeSides3() // 15 три стороны (диагональ вправо назад, вперед и влево)
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
    void DirectionalThreeSides4() // 16 три стороны (диагональ влево назад, вперед и вправо)
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
    void DirectionalStraightAll() // 17 прямо все стороны
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
    void DirectionalDiagonalAll() // 18 диагональ все стороны
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
    void DirectionalHorse() // 19 ход конем
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
    void Barrel() // 20 бочка
    {
        PlayerMovementComponent.GetBarreled();
        if (PlayerMovementComponent.IsBot)
        {
            TeamMovementComponent.BotChangeIndex();
        }
    }
    void Maze_2() // 21 лабиринт 2 точки
    {
        PlayerMovementComponent.SetMaze(2);
    }
    void Maze_3() // 22 лабиринт 3 точки
    {
        PlayerMovementComponent.SetMaze(3);
    }
    void Maze_4() // 23 лабиринт 4 точки
    {
        PlayerMovementComponent.SetMaze(4);
    }
    void Maze_5() // 24 лабиринт 5 точек
    {
        PlayerMovementComponent.SetMaze(5);
    }
    void DirectionalIce() // 25 лед
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
    void Trap() // 26 капкан
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
    void DirectionalAnimal() // 27 крокодил
    {
        PlayerMovementComponent.InDirectionalBlock = true;
        GetNextBlocksComponent = PlayerMovementComponent.BlockBuffer.GetComponent<GetNextBlocksScript>();
        DirectionalBlocks = new List<GameObject>
        {
            PlayerMovementComponent.OldBlockBuffer
        };
        PlayerMovementComponent.DirectionalBlocksList = DirectionalBlocks;
    }
    void Killer() // 28 людоед
    {
        PlayerMovementComponent.GetKilled();
        if (PlayerMovementComponent.IsBot)
        {
            TeamMovementComponent.BotChangeIndex();
        }
    }
    void SafePlace() // 29 крепость
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        BlockComponent.IsShelter = true;
    }
    void PlayerReturner() // 30 аборигенка
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
    void MoneyChest_1() // 31 сундук 1 монета
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 1;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_2() // 32 сундук 2 монеты
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 2;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_3() // 33 сундук 3 монеты
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 3;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_4() // 34 сундук 4 монеты
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 4;
            BlockComponent.isActivated = true;
        }
    }
    void MoneyChest_5() // 35 сундук 5 монет
    {
        BlockComponent = PlayerMovementComponent.BlockBuffer.GetComponent<BlockScript>();
        if (!BlockComponent.isActivated)
        {
            BlockComponent.MoneyAmount = 5;
            BlockComponent.isActivated = true;
        }
    }
    void DirectionalBalloon() // 36 воздушный шар
    {
        PlayerMovementComponent.OnShip = true;
        PlayerMoneyComponent.DestroyMoney();
        PlayerMoneyComponent.AddTeamMoney(PlayerMovementComponent.TeamIndex);
    }
    void DirectionalPlane() // 37 самолет
    {
        PlayerMovementComponent.RangeOnFoot = 100;
    }
    void DirectionalCannonForward() // 38 пушка вперед
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
    void DirectionalCannonRight() // 39 пушка вправо
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
    void DirectionalCannonLeft() // 40 пушка влево
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
    void DirectionalCannonBack() // 41 пушка назад
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
    void WaterBlock() // 42 вода
    {
        PlayerMoneyComponent.DropMoney();
    }

    void Update()
    {

    }
}
