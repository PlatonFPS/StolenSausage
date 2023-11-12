using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using System.Runtime.CompilerServices;

public class ScoreCount : MonoBehaviour
{
    [SerializeField] int totalMoney;
    [SerializeField] int lunchPrice;
    [SerializeField] int sdobaPrice;
    [SerializeField] int sausagePrice;
    [SerializeField] Transform camera;
    [SerializeField] Transform cameraPos;
    [SerializeField] private GameObject sousage;
    [SerializeField] private GameObject sdoba;
    [SerializeField] private GameObject what1;
    [SerializeField] private GameObject what2;
    [SerializeField] private GameObject platter;

    public void CalculateScore()
    {
        CalculateFoodScore();
        VisualizeScore();
        camera.position = cameraPos.position;
    }
    private int moneySpent = 0;
    
    private bool fork = false;
    private bool spoon = false;
    private void CalculateFoodScore()
    {
        List<FoodState> states = new List<FoodState>();
        int salad = 0;
        int first = 0;
        int second = 0;
        int concealedSdoba = 0;
        int concealedSausage = 0;
        foreach (Transform food in platter.GetComponentsInChildren<Transform>())
        {
            if(food.GetComponent<FoodState>())
            {
                if (food.tag == "Salad") salad++;
                if (food.tag == "FirstMeal")
                {
                    if(food.GetComponent<FoodState>().concealed) concealedSausage++;
                    first++;
                }
                if (food.tag == "SecondMeal") second++;
                if (food.tag == "Sdoba")
                {
                    if(food.GetComponent<FoodState>().concealed)
                    {
                        concealedSdoba++;
                    }
                    else
                    {
                        moneySpent += sdobaPrice;
                    }
                }
                if (food.tag == "Sausage") moneySpent += sausagePrice;
                if (food.tag == "Spoon") spoon = true;
                if (food.tag == "Fork") fork = true;
            }
        }
        int max = salad;
        if (max < first) max = first;
        if(max < second) max = second;
        moneySpent += lunchPrice * max;
        if(moneySpent <= totalMoney)
        {
            if (concealedSausage == 1)
            {
                sausagePresent = true;
            }
            if (concealedSdoba == 1)
            {
                sdobaPresent = true;
            }
            if (concealedSausage < 2 && concealedSdoba < 2)
            {
                if(first > 0)
                {
                    firstScore++;
                    if(spoon)
                    {
                        firstScore++;
                    }
                }
                if(second > 0)
                {
                    secondScore++;
                    if(fork)
                    {
                        secondScore++;
                    }
                }
                if(salad > 0)
                {
                    saladScore++;
                }
                if(concealedSausage == 1)
                {
                    sausageScore++;
                }
                if(concealedSdoba == 1)
                {
                    sdobaScore++;
                }
            }
            else
            {
                busted = true;
            }
        }
        else
        {
            noMoney = true;
        }
    }
    private int firstScore = 0;
    private int secondScore = 0;
    private int saladScore = 0;
    private int sausageScore = 0;
    private int sdobaScore = 0;
    private bool noMoney = false;
    private bool busted = false;
    private bool sausagePresent = false;
    private bool sdobaPresent = false;
    private float score = 0;
    private void VisualizeScore()
    {
        if(sausagePresent)
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
        switch (firstScore)
        {
            case 0:

                break;
            case 1:
                score += 0.25f;
                break;
            case 2:
                score += 0.5f;
                break;
        }
        switch (secondScore)
        {
            case 0:

                break;
            case 1:
                score += 0.25f;
                break;
            case 2:
                score += 0.5f;
                break;
        }
        switch (saladScore)
        {
            case 0:

                break;
            case 1:
                score += 1;
                break;
        }
        switch (sausageScore)
        {
            case 0:

                break;
            case 1:
                score += 1.5f;
                break;
        }
        switch (sdobaScore)
        {
            case 0:

                break;
            case 1:
                score += 1.5f;
                break;
        }
        Debug.Log(score);
    }
}
