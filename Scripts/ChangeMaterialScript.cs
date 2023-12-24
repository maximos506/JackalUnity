using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialScript : MonoBehaviour
{
    public GameObject PlayerModel;
    public MeshRenderer meshComponent;
    public Material[] materials;
    void Start()
    {
        PlayerModel = this.gameObject.transform.GetChild(0).gameObject;
        meshComponent = PlayerModel.GetComponent<MeshRenderer>();
    }
    public void SetMaterial(int ID)
    {
      meshComponent.material = materials[ID];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
