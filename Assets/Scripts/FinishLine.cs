using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLine : MonoBehaviour
{
    public GameObject textDisplayName;
    public GameObject youWinPanel;

    public PauseMenu pauseMenu;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        
        youWinPanel.SetActive(true);
        Time.timeScale = 0F;

        if (Game_Manager.GetInstance() != null)
            textDisplayName.GetComponent<TextMeshProUGUI>().text = "You made it out " + Game_Manager.GetInstance().getplayerName();
        else
            textDisplayName.GetComponent<TextMeshProUGUI>().text = "You made it out ";
        AudioManager.instance.PauseSound("Theme");
        AudioManager.instance.Play("Win_Sound");
        pauseMenu.DisplayCanvases(false);
    }
}
