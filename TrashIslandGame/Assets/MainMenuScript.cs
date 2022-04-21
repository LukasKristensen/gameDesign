using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
    
    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
