using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuSystem : MonoBehaviour
{


    public void StartGame()
    {
        Debug.Log("Game Started");
        SceneManager.LoadScene("Filips Scene");
    }

    public void OpenSettings()
    {
        Debug.Log("Settings Opened");
        SceneManager.LoadScene("Adams Scene");
    }

    public void  QuitGame()
    {
        Debug.Log("game Quit");
        Application.Quit();
    }
}
