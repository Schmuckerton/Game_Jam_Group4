using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("Settings_Menu");
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu_Screen");
    }
    public void GotoPauseMenu()
    {
        SceneManager.LoadScene("Pause_Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
