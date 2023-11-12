using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] Transform cameraPos;
    [SerializeField] private GameObject sousage;
    [SerializeField] private GameObject sdoba;
    [SerializeField] private GameObject what1;
    [SerializeField] private GameObject what2;
    

    public void CalculateScore()
    {
        VisualizeScore();
        Debug.Log("CalculateScore");
        camera.position = cameraPos.position;
    }
    private bool sousagePresent = false;
    private bool sdobaPresent = false;
    private void VisualizeScore()
    {
        if(sousagePresent)
        {
            sousage.SetActive(true);
            what1.SetActive(false);
        }
        else
        {
            sousage.SetActive(false);
            what1.SetActive(true);
        }
        if (sdobaPresent)
        {
            sdoba.SetActive(true);
            what2.SetActive(false);
        }
        else
        {
            sdoba.SetActive(false);
            what2.SetActive(true);
        }
    }
}
