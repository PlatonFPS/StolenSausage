using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] Transform cameraPos;
    [SerializeField] private TMP_Text scoreText;
    

    public void CalculateScore()
    {
        camera.transform.position = cameraPos.position;
        int temp = 3;
        string score = $"Your Score is {temp}";
        scoreText.text = score;
    }
}
