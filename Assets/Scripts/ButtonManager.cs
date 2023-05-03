using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("ControlHelp");
    }

    public void ExitButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void ReTryButton()
    {
        SceneManager.LoadScene("Ingame");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}