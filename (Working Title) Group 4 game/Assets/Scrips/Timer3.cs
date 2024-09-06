using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //This gives us access to our UI elements so we can display the text. Only using it internally? Don't need it.
using TMPro;

//This is a basic timer good for counting down seconds in Minutes and Seconds and stops immediately at 0

public class Timer3 : MonoBehaviour
{
    [SerializeField]
    private float timeRemaining = 10f;
    [SerializeField]
    private float endTime = 0f;
    private bool timerRunning = false;
    [SerializeField]
    private TextMeshProUGUI timerText;
    public bool gameLost = false;

    // Start is called before the first frame update
    void Start()
    {
        timerRunning = true;
    }

    // Update is called once per frame *works up to here*
    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > endTime) //if timer is still running
            {
                timeRemaining -= Time.deltaTime; //subtract the frame rate from the timer
                DisplayTime(timeRemaining);
            }
            else
            {
                timerRunning = false;
                timeRemaining = 0f;
                Debug.Log("Time Out");
                timerText.text = string.Format("Time: 00:00");
                gameLost = true;
            }
        }



    }


    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; //TimeToDisplay = TimeToDisplay + 1f
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //2
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //10
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
