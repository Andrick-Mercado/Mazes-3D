using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    static Timer instance;//public

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    public static Timer GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (!Game_Manager.GetInstance())
        {
            timeCounter.text = "Time: 00:00:00";
            timerGoing = false;
            return;
        }
        
        if (Game_Manager.GetInstance().getplayerColor().Contains("Black"))
            timeCounter.color = Color.black;
        else if (Game_Manager.GetInstance().getplayerColor().Contains("White"))
            timeCounter.color = Color.white;
        else if (Game_Manager.GetInstance().getplayerColor().Contains("Blue"))
            timeCounter.color = Color.blue;
        else if (Game_Manager.GetInstance().getplayerColor().Contains("Yellow"))
            timeCounter.color = Color.yellow;
        else if (Game_Manager.GetInstance().getplayerColor().Contains("Red"))
            timeCounter.color = Color.red;
        else if (Game_Manager.GetInstance().getplayerColor().Contains("Green"))
            timeCounter.color = Color.green;
        else if (Game_Manager.GetInstance().getplayerColor().Contains("Grey"))
            timeCounter.color = Color.grey;

        timeCounter.text = "Time: 00:00:00";
        timerGoing = false;
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while( timerGoing )
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
        
    }
}
