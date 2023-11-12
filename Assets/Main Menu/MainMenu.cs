using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform cameraPos;
    [SerializeField] private MovementBetweenSections movementBetweenSections;
    private Transform startCameraPos;
    private void Awake()
    {
        startCameraPos = camera;
    }
    [SerializeField] private float delayTime;
    private float timer = 0;
    private bool timerIsActive = false;
    private void DelayAction()
    {
        timer = delayTime;
        timerIsActive = true;
    }
    private void Update()
    {
        if(timerIsActive)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0;
                timerIsActive = false;
                if(gameStarted)
                {
                    gameStarted = false;
                    StartGameAfterDelay();
                }
                if(settingsStarted)
                {
                    settingsStarted = false;
                    StartSettingsAfterDelay();
                }
                if(titlesStarted)
                {
                    titlesStarted = false;
                    StartTitlesAfterDelay();
                }
            }
        }
    }
    private bool CheckStatus()
    {
        return (gameStarted == false && settingsStarted == false && titlesStarted == false);
    }
    private bool gameStarted = false;
    public void StartGame()
    {
        if(CheckStatus())
        {
            DelayAction();
            gameStarted = true;
        }
    }
    private void StartGameAfterDelay()
    {
        camera.position = cameraPos.position;
        movementBetweenSections.canWalk = true;
        gameObject.SetActive(false);
    }
    private bool settingsStarted = false;
    public void StartSettings()
    {
        if(CheckStatus())
        {
            DelayAction();
            settingsStarted = true;
        }
    }
    private void StartSettingsAfterDelay()
    {
        Debug.Log("Settings");
    }
    private bool titlesStarted = false;
    public void StartTitles()
    {
        if(CheckStatus())
        {
            DelayAction();
            titlesStarted = true;
        }
    }
    private void StartTitlesAfterDelay()
    {
        Debug.Log("Titles");
    }
}
