﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void goGameScene()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
