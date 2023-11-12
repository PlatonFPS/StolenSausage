using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    [SerializeField] GameObject Cutted;
    private FoodState foodState;
    private void Awake()
    {
        foodState = GetComponent<FoodState>();
    }
    public bool cut = false;
    public void CutToPieces()
    {
        cut = true;
        GetComponent<SpriteRenderer>().enabled = false;
        Cutted.SetActive(true);
    }
}
