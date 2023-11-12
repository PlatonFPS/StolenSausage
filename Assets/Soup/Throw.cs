using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] GameObject withSausage;
    private FoodState foodState;
    private void Awake()
    {
        foodState = GetComponent<FoodState>();
    }
    public void ThrowSausageIn()
    {
        foodState.concealed = true;
        GetComponent<SpriteRenderer>().enabled = false;
        withSausage.SetActive(true);
    }
}
