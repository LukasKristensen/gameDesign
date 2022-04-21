using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScreen : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
