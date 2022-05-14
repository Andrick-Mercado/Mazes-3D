using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class store_user_input : MonoBehaviour
{
    /**  METHODS FOR TO PLAYER NAME    **/

    public TMP_InputField inputPlayerName;

    public void getPlayerName()
    {
        Game_Manager.GetInstance().setplayerName(inputPlayerName.text);
    }

    /**  METHODS FOR TO PLAYER COLOR    **/

    public Transform dropdownMenuColor;
    public void getPlayerColor()
    {
        int playerRaceIndex = GameObject.Find("Dropdown_Color").GetComponent<TMP_Dropdown>().value;
        List<TMP_Dropdown.OptionData> menuOptions = dropdownMenuColor.GetComponent<TMP_Dropdown>().options;
        string value = menuOptions[playerRaceIndex].text;
        Game_Manager.GetInstance().setplayerColor(value);//so.playerRace = value;
    }

    /**  METHODS FOR TO PLAYER DIFICULTY    **/

    public Transform dropdownMenuDificulty;
    public void getPlayerDificulty()
    {
        int playerIndex = GameObject.Find("Dropdown_Difficulty").GetComponent<TMP_Dropdown>().value;
        List<TMP_Dropdown.OptionData> menuOptions = dropdownMenuDificulty.GetComponent<TMP_Dropdown>().options;
        string value = menuOptions[playerIndex].text;
        Game_Manager.GetInstance().setplayerDifficulty(value);
    }


}
