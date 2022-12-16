using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuSystem : MonoBehaviour
{

    /// <summary>
    ///Loads the Level Scene if the button is pressed
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    /// <summary>
    /// Loads the Settings Scene if button is presed
    /// </summary>
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings Scene");
    }

    /// <summary>
    /// Quits the game if button is pressed 
    /// </summary>
    public void  QuitGame()
    {
        Application.Quit();
    }
}
