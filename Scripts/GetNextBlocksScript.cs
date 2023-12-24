using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNextBlocksScript : MonoBehaviour
{
    public GameObject LBlock, LUBlock, UBlock, RUBlock, RBlock, BRBlock, BBlock, BLBlock; // left, left-upper,
    // upper-block, right-upper, right, back-right, back, back-left
    public GameObject H_LUBlock, H_RUBlock, H_LBBlock, H_RBBlock;
    RaycastHit hitObject;
    public Vector3 LVec, LUVec, UVec, RUVec, RVec, BRVec, BVec, BLVec;
    public Vector3 H_LUVec, H_RUVec, H_LBVec, H_RBVec;
    public Vector3 Left,Right,Up,Down,LeftUP,RightUP,LeftDOWN,RightDOWN;
    public bool IsTestingRay;
    public int Index;
    public GameObject WaterUP,WaterDOWN,WaterLeft,WaterRight;
    void Start()
    {
        LVec = new Vector3(-1, 1, 0);
        LUVec = new Vector3(-1, 1, 1);
        UVec = new Vector3(0, 1, 1);
        RUVec = new Vector3(1, 1, 1);
        RVec = new Vector3(1, 1, 0);
        BRVec = new Vector3(1, 1, -1);
        BVec = new Vector3(0, 1, -1);
        BLVec = new Vector3(-1, 1, -1);
        H_LUVec = new Vector3(-1, 1, 2);
        H_RUVec = new Vector3(1, 1, 2);
        H_LBVec = new Vector3(-1, 1, -2);
        H_RBVec = new Vector3(1, 1, -2);
        Left = new Vector3(-1, 0, 0);
        Right = new Vector3(1, 0, 0);
        Up = new Vector3(0, 0, 1);
        Down = new Vector3(0, 0, -1);
        LeftUP = new Vector3(-1, 0, 1);
        RightUP = new Vector3(1, 0, 1);
        LeftDOWN = new Vector3(-1, 0, -1);
        RightDOWN = new Vector3(1, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        UBlock = GetNextBlock(UVec);
        LBlock = GetNextBlock(LVec);
        LUBlock = GetNextBlock(LUVec);
        RUBlock = GetNextBlock(RUVec);
        RBlock = GetNextBlock(RVec);
        BRBlock = GetNextBlock(BRVec);
        BBlock = GetNextBlock(BVec);
        BLBlock = GetNextBlock(BLVec);
        H_LUBlock = GetNextBlock(H_LUVec);
        H_RUBlock = GetNextBlock(H_RUVec);
        H_LBBlock = GetNextBlock(H_LBVec);
        H_RBBlock = GetNextBlock(H_RBVec);
    }

    public int GetMoveDirection(Vector3 Direction)
    {
        if(Direction == Left)
        {
            Index = 1;
            //Debug.Log("Left");
            return Index;
        }
        if (Direction == Right)
        {
            Index = 2;
            //Debug.Log("Right");
            return Index;
        }
        if (Direction == Up)
        {
            Index = 3;
            //Debug.Log("Up");
            return Index;
        }
        if (Direction == Down)
        {
            Index = 4;
            //Debug.Log("Down");
            return Index;
        }
        if (Direction == LeftUP)
        {
            Index = 5;
            //Debug.Log("LeftUP");
            return Index;
        }
        if (Direction == RightUP)
        {
            Index = 6;
            //Debug.Log("RightUP");
            return Index;
        }
        if (Direction == LeftDOWN)
        {
            Index = 7;
            //Debug.Log("LeftDOWN");
            return Index;
        }
        if (Direction == RightDOWN)
        {
            Index = 8;
            //Debug.Log("RightDOWN");
            return Index;
        }
        return Index;
    }
    GameObject GetNextBlock(Vector3 DirVector)
    {
        Vector3 SearchVector = transform.position + DirVector;
        if (IsTestingRay)
        {
            Debug.DrawRay(SearchVector, Vector3.down, Color.green);
        }
        if (Physics.Raycast(SearchVector, Vector3.down,out hitObject, 100))
        {
            return hitObject.transform.gameObject;
        }
        else
        {
            return null;
        }
    }
}
