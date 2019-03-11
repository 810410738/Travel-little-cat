using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private int chosenLevel = 0;
    public void SetChooseLevel(int chosenLevel)
    {
        this.chosenLevel = chosenLevel;
        EnterScene();
    }

    public int GetChosenLevel()
    {
        return chosenLevel;
    }

    private void EnterScene()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("page3");
    }
}
