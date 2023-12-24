using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBlocksScript : MonoBehaviour
{
    public GameObject LBlock, LUBlock, UBlock, RUBlock, RBlock, BRBlock, BBlock, BLBlock;
    RaycastHit hitObject;
    public Vector3 UVec;
    public bool IsTestingRay;
    void Start()
    {
        UVec = new Vector3(0, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        UBlock = GetNextBlock(UVec);
    }


    GameObject GetNextBlock(Vector3 DirVector)
    {
        Vector3 SearchVector = transform.position + DirVector;
        if (IsTestingRay)
        {
            Debug.DrawRay(SearchVector, Vector3.down, Color.red);
        }
        if (Physics.Raycast(SearchVector, Vector3.down, out hitObject, 100))
        {
            return hitObject.transform.gameObject;
        }
        else
        {
            return null;
        }
    }
}
