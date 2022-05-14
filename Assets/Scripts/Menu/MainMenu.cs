using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        AudioManager.instance.PauseSound("Win_Sound");
        AudioManager.instance.Play("Theme");
    }

    public void NextButton()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PauseSound("Win_Sound");
    }

    
}
