using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platter : MonoBehaviour
{
    private List<GameObject> foods;

    private void Awake()
    {
        foods = new List<GameObject>();
    }

    public void AddObject(GameObject food)
    {
        foods.Add(food);
        food.GetComponent<FoodState>().onPlatter = true;
        food.GetComponent<FoodState>().prevParent = food.transform.parent;
        food.transform.parent = transform;
    }

    public void RemoveObject(GameObject food)
    {
        foods.Remove(food);
        food.GetComponent<FoodState>().onPlatter = false;
        food.transform.parent = food.GetComponent<FoodState>().prevParent;
    }
}
