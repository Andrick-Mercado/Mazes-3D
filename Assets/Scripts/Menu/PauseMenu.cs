using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField] 
    private Canvas[] _allCanvases;

    private bool _isPressedPause;

    private void Update()
    {
        if (_isPressedPause)
        {
            if (GameIsPaused)
            {
                Resume();
                
                _isPressedPause = false;
            }
            else
            {
                Pause();
                _isPressedPause = false;
            }
        }
    }
    public void Resume()
    {
        DisplayCanvases(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PauseSound("Theme");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetPause(bool pause)
    {
        _isPressedPause = pause;
    }

    public void DisplayCanvases(bool canvas)
    {
        foreach (var t in _allCanvases)
        {
            t.enabled = canvas;
        }
    }

}

