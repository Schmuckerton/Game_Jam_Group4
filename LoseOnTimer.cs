using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMesh Pro components

public class LoseOnTimerWithTMP : MonoBehaviour
{
    // Total time in seconds for the countdown
    public float countdownTime = 60f;

    // Reference to the UI element that represents the lose screen
    public GameObject loseScreenUI;

    // Reference to the TextMeshProUGUI element that displays the timer
    public TextMeshProUGUI timerTextTMP;

    private float currentTime;

    // Start is called before the first frame update
    private void Start()
    {
        // Initialize the current time to the countdown time
        currentTime = countdownTime;

        // Hide the lose screen UI at the start
        loseScreenUI.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        // If the time is greater than 0, keep counting down
        if (currentTime > 0)
        {
            // Decrease the current time
            currentTime -= Time.deltaTime;

            // Update the timer text if it's assigned
            if (timerTextTMP != null)
            {
                timerTextTMP.text = Mathf.Clamp(currentTime, 0, countdownTime).ToString("F2"); // Format as seconds with 2 decimals
            }
        }
        else
        {
            // If time runs out, show the lose screen
            ShowLoseScreen();
        }
    }

    // Function to display the lose screen and pause the game
    private void ShowLoseScreen()
    {
        if (loseScreenUI != null && !loseScreenUI.activeSelf) // Show only once
        {
            // Activate the lose screen UI
            loseScreenUI.SetActive(true);

            // Pause the game by setting the timescale to 0
            Time.timeScale = 0f;
        }
    }
}