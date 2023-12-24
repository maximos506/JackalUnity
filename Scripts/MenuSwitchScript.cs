using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSwitchScript : MonoBehaviour
{
    public GameObject MainMenu, GameSettings, Options;
    void Start()
    {
         MainMenu.SetActive(true);
            GameSettings.SetActive(false);
            Options.SetActive(false);

    }

    public void GetToMenu()
    {
        MainMenu.SetActive(true);
        GameSettings.SetActive(false);
        Options.SetActive(false);
    }
    public void GetToOptions()
    {
        MainMenu.SetActive(false);
        GameSettings.SetActive(false);
        Options.SetActive(true);
    }
    public void GetToGameSettings()
    {
        MainMenu.SetActive(false);
        GameSettings.SetActive(true);
        Options.SetActive(false);
    }
    public void GameLaunch()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    public void GameQuit()
    {
        Application.Quit();
    }

    void Update()
    {
        
    }
}
