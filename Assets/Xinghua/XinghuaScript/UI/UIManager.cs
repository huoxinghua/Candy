using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("boss Hp in world space")]
    [SerializeField] private GameObject hpBar;

    [Header("cookmachine Hp in world space")]
    [SerializeField] private GameObject hpBarMachineFill;
    [SerializeField] public GameObject hpBarMachine;
    [SerializeField] public GameObject candyHealPeople;
    [SerializeField] public GameObject CookMachineUI;

    [Header("GameState")]
    [SerializeField] public GameObject lostUI;
    [SerializeField] public GameObject winUI;
    [SerializeField] public GameObject pauseMenu;

    private bool isCookMachineUIShow;

    [Header("screen")]
    [SerializeField] TMP_Text timer;
    public float timeRemaining;
    private bool timerIsRunning;
    public GameObject timerUI;

    private void Start()
    {
        hpBar.SetActive(false);
        timerUI.SetActive(true);
        timerIsRunning = true;
        candyHealPeople.SetActive(false);
        CookMachineUI.SetActive(false);
        lostUI.SetActive(false);
        pauseMenu.SetActive(false);
        winUI.SetActive(false);
        isCookMachineUIShow = false;
    }
    public void ShowBossHp()
    {
        
       hpBar.SetActive(true);
    }

    public void ShowCookMachineUI()
    {
        CookMachineUI.SetActive(true);
        isCookMachineUIShow =true;
    }

    public void ShowCandyHealUI()
    {
        if (isCookMachineUIShow)return;

        candyHealPeople.SetActive(true);
    }

    void Update()
    {
        if (timerIsRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
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


}
