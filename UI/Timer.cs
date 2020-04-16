using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Timer : MonoBehaviour
{
    private bool isTimerActive;
    public float levelTimer;
    public float totalTimer;
    public Text currentTimerTextBox;
    public Text totalTimerTextBox;
    public string tempTime;
    public int hours;
    public int minutes;
    public int seconds;
    public int milliseconds;
    
    

 

    void Start()
    {
        currentTimerTextBox.text = levelTimer.ToString("F2");
        isTimerActive = true;
        formatTotalTime();
        
    }

    
    void FixedUpdate()
    {
        if(isTimerActive == true)
        {
            levelTimer += Time.deltaTime;
            currentTimerTextBox.text = levelTimer.ToString("F2");
        }

       

        if(Input.GetKeyUp("space"))
        {
            isTimerActive = !isTimerActive;
        }

       
    }

    void formatTotalTime()
    {
            
            milliseconds = (int)(totalTimer * 1000) % 1000;
            seconds = (int)(totalTimer / 1);
            minutes = (int)(totalTimer / 60);
            hours = (int)(totalTimer / 3600);

            if (seconds >= 60)
            {
                seconds -= 60 * minutes;
            }

            if (minutes >= 60)
            {
                minutes -= 60 * hours;
            }
            totalTimerTextBox.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("000");
        
    }

    
}
