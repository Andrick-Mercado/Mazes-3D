using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_char : MonoBehaviour
{
    public void play()
    {
        if (Game_Manager.GetInstance().getplayerDifficulty().Contains("Medium") )
        {
            SceneManager.LoadScene("MazeLevel1_medium");
        }
        else if (Game_Manager.GetInstance().getplayerDifficulty().Contains("Hard") )
        {
            SceneManager.LoadScene("MazeLevel1_hard");
        }
        else
            SceneManager.LoadScene("MazeLevel1_easy");
        AudioManager.instance.Play("Theme");
    }

    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
}
