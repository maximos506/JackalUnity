using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotationScript : MonoBehaviour
{
    public GameObject Camera;
    public float coordX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Camera.transform.eulerAngles.x + coordX, Camera.transform.eulerAngles.y, 0);
    }
}
