﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int chosenLevel = 0;

    public int GetChosenLevel()
    {
        return chosenLevel;
    }

    public void EnterScene(string name)
    {
        //GameObject.DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
