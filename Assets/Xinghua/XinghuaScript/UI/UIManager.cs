using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("show in word space")]
    [SerializeField] private HpBar[] image;
    [SerializeField] string hpBarName;
    [SerializeField] private GameObject hpBar;

    [Header("screen")]
    [SerializeField] TMP_Text timer;
    [SerializeField] private float timeRemaining;
    private bool timerIsRunning;
    [SerializeField] private GameObject timerUI;

    private void Start()
    {
        hpBar.SetActive(false);
        timerUI.SetActive(true);
        timerIsRunning = true;
    }
    public void ShowBossHp()
    {
        
       hpBar.SetActive(true);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                timerUI.SetActive(false);
                TimerEnded();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        // Calculate hours, minutes, and seconds
        int hours = Mathf.FloorToInt(timeRemaining / 3600);
        int minutes = Mathf.FloorToInt((timeRemaining % 3600) / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);


        // Format the time string
        string timeFormatted = string.Format("{0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);

        // Update the timer text display
        timer.text = timeFormatted; 
       
    }

    private void TimerEnded()
    {
        //Game over
        Debug.Log("Timer has ended!");
        GameManager.Instance.GameOver();
    }


}
