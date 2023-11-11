using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platter : MonoBehaviour
{
    public void AddObject(GameObject food)
    {
        food.GetComponent<FoodState>().onPlatter = true;
        food.GetComponent<FoodState>().prevParent = food.transform.parent;
        food.transform.parent = transform;
    }

    public void RemoveObject(GameObject food)
    {
        food.GetComponent<FoodState>().onPlatter = false;
        food.transform.parent = food.GetComponent<FoodState>().prevParent;
    }
}
