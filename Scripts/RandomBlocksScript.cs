using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomBlocksScript : MonoBehaviour
{
    GameObject[] GroundBlocks;
    public GameObject[] StartBlocks;
    public int RegularBlocksCount = 28; // 40 - 12 = 28
    public int StraightArrow, DiagonalArrow, TwoDiagonal, SideArrow, TripleArrow, AllDirArrow, AllDirDiagonalArrow;
    public int HorseCount;
    public int BarrelCount;
    public int Maze2Count, Maze3Count, Maze4Count, Maze5Count;
    public int IceCount;
    public int TrapCount;
    public int CrocodileCount;
    public int KillerCount;
    public int FortressCount;
    public int WomanCount;
    public int Chest1Count, Chest2Count, Chest3Count, Chest4Count, Chest5Count;
    public int PlaneCount;
    public int BalloonCount;
    public int GunCount;
    public int[] BlocksID;
    public int blocksCount;
    public int RandomIndex;
    public int tempGO;

    void FillBlocksID()
    {
        blocksCount = 0;
        BlocksID= new int[121];
        for (int i = 0; i < RegularBlocksCount; i++)
        {
            BlocksID[blocksCount] = 0;
            blocksCount++;
        }
        for (int i = 0; i < StraightArrow; i++)
        {
            RandomIndex = Random.Range(1, 4);
            BlocksID[blocksCount] = RandomIndex;
            blocksCount++;
        }
        for (int i = 0; i < DiagonalArrow; i++)
        {
            RandomIndex = Random.Range(5, 8);
            BlocksID[blocksCount] = RandomIndex;
            blocksCount++;
        }
        for (int i = 0; i < TwoDiagonal; i++)
        {
            RandomIndex = Random.Range(9, 10);
            BlocksID[blocksCount] = RandomIndex;
            blocksCount++;
        }
        for (int i = 0; i < SideArrow; i++)
        {
            RandomIndex = Random.Range(11, 12);
            BlocksID[blocksCount] = RandomIndex;
            blocksCount++;
        }
        for (int i = 0; i < TripleArrow; i++)
        {
            RandomIndex = Random.Range(13, 16);
            BlocksID[blocksCount] = RandomIndex;
            blocksCount++;
        }
        for (int i = 0; i < AllDirArrow; i++)
        {
            BlocksID[blocksCount] = 17;
            blocksCount++;
        }
        for (int i = 0; i < AllDirDiagonalArrow; i++)
        {
            BlocksID[blocksCount] = 18;
            blocksCount++;
        }
        for (int i = 0; i < HorseCount; i++)
        {
            BlocksID[blocksCount] = 19;
            blocksCount++;
        }
        for (int i = 0; i < BarrelCount; i++)
        {
            BlocksID[blocksCount] = 20;
            blocksCount++;
        }
        for (int i = 0; i < Maze2Count; i++)
        {
            BlocksID[blocksCount] = 21;
            blocksCount++;
        }
        for (int i = 0; i < Maze3Count; i++)
        {
            BlocksID[blocksCount] = 22;
            blocksCount++;
        }
        for (int i = 0; i < Maze4Count; i++)
        {
            BlocksID[blocksCount] = 23;
            blocksCount++;
        }
        for (int i = 0; i < Maze5Count; i++)
        {
            BlocksID[blocksCount] = 24;
            blocksCount++;
        }
        for (int i = 0; i < IceCount; i++)
        {
            BlocksID[blocksCount] = 25;
            blocksCount++;
        }
        for (int i = 0; i < TrapCount; i++)
        {
            BlocksID[blocksCount] = 26;
            blocksCount++;
        }
        for (int i = 0; i < CrocodileCount; i++)
        {
            BlocksID[blocksCount] = 27;
            blocksCount++;
        }
        for (int i = 0; i < KillerCount; i++)
        {
            BlocksID[blocksCount] = 28;
            blocksCount++;
        }
        for (int i = 0; i < FortressCount; i++)
        {
            BlocksID[blocksCount] = 29;
            blocksCount++;
        }
        for (int i = 0; i < WomanCount; i++)
        {
            BlocksID[blocksCount] = 30;
            blocksCount++;
        }
        for (int i = 0; i < Chest1Count; i++)
        {
            BlocksID[blocksCount] = 31;
            blocksCount++;
        }
        for (int i = 0; i < Chest2Count; i++)
        {
            BlocksID[blocksCount] = 32;
            blocksCount++;
        }
        for (int i = 0; i < Chest3Count; i++)
        {
            BlocksID[blocksCount] = 33;
            blocksCount++;
        }
        for (int i = 0; i < Chest4Count; i++)
        {
            BlocksID[blocksCount] = 34;
            blocksCount++;
        }
        for (int i = 0; i < Chest5Count; i++)
        {
            BlocksID[blocksCount] = 35;
            blocksCount++;
        }
        for (int i = 0; i < BalloonCount; i++)
        {
            BlocksID[blocksCount] = 36;
            blocksCount++;
        }
        for (int i = 0; i < PlaneCount; i++)
        {
            BlocksID[blocksCount] = 37;
            blocksCount++;
        }
        for (int i = 0; i < GunCount; i++)
        {
            RandomIndex = Random.Range(38, 41);
            BlocksID[blocksCount] = RandomIndex;
            blocksCount++;
        }
        for (int i = 0; i < BlocksID.Length; i++)
        {
            int rnd = Random.Range(0, BlocksID.Length);
            tempGO = BlocksID[rnd];
            BlocksID[rnd] = BlocksID[i];
            BlocksID[i] = tempGO;
        }
    }
    void Start()
    {
        FillBlocksID();
        GroundBlocks = GameObject.FindGameObjectsWithTag("Ground");
        SetStartBlocks();
        SetRandomBlocks();
    }
    public void SetStartBlocks()
    {
        for(int i = 0; i < StartBlocks.Length; i++)
        {
            BlockScript BlockComponent = StartBlocks[i].gameObject.GetComponent<BlockScript>();
            BlockComponent.SetEffect(0);
        }
    }
    void SetRandomBlocks()
    {
        for(int i = 0; i < GroundBlocks.Length; i++)
        {
            if (StartBlocks.Contains(GroundBlocks[i]))
            {
                continue;
            }
            BlockScript BlockComponent = GroundBlocks[i].gameObject.GetComponent<BlockScript>();
            BlockComponent.SetEffect(BlocksID[i]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
