using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PauseObject;
    void Start()
    {
        PauseObject.SetActive(false);
    }

    public void DisablePause()
    {
        PauseObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void MobilePause()
    {
        PauseObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
}
