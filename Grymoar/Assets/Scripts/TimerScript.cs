using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {
    public Text gameTimerText;
    float gameTimer = 0f;
    public string timerString = "00:00:00";

    private bool isLaunched = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isLaunched)
        {
            gameTimer += Time.deltaTime;

            int seconds = (int)(gameTimer % 60);
            int minutes = (int)(gameTimer / 60) % 60;
            int hours = (int)(gameTimer / 3600) % 24;

            timerString = string.Format("Timer: {0:0}:{1:00}:{2:00}", hours, minutes, seconds);

            gameTimerText.text = timerString;
        }
	}

    public void launch()
    {
        isLaunched = true;
    }

    public void stop()
    {
        isLaunched = false;
    }

    public void reset()
    {
        gameTimer = 0f;
        gameTimerText.text = "Time: 00:00:00";
    }
}
