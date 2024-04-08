using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartScreen()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
