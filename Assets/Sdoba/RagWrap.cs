using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagWrap : MonoBehaviour
{
    private FoodState foodState;
    private void Awake()
    {
        foodState = GetComponent<FoodState>();
    }
    [SerializeField] GameObject inRag;
    public void WrapInRag()
    {
        if(!foodState.concealed)
        {
            foodState.concealed = true;
            inRag.SetActive(true);
        }
    }
}
