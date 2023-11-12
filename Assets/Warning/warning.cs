using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class warning : MonoBehaviour
{
    [SerializeField] GameObject screen;
    [SerializeField] GameObject canvas;

    [SerializeField] float time;
    private float timer = 0f;
    private bool timerIsActive = false;
    private Color color = Color.white;
    private void Awake()
    {
        timerIsActive = true;
        timer = time;
        color = screen.GetComponent<SpriteRenderer>().color;
    }
    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            color.a = (timer / time);
            screen.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            timer = 0;
            timerIsActive = false;
            StartGame();
        }    
    }

    private void StartGame()
    {
        foreach(Transform child in canvas.GetComponentInChildren<Transform>())
        {
            child.GetComponent<Button>().enabled = true;
        }
        screen.SetActive(false);
    }
}
