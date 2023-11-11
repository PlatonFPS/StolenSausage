using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    private void Awake()
    {
        //PlayerPrefs.SetInt("ToggleDrag", 0);
        //PlayerPrefs.Save();
    }

    [SerializeField] private Platter platter = null;

    private Transform holdObject = null;
    private Vector3 startPosition = Vector3.zero;

    void Update()
    {
        if(PlayerPrefs.GetInt("ToggleDrag") == 1)
        {
            ToggleDrag();
        }
        else
        {
            HoldDrag();
        }
        if(holdObject != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = holdObject.position.z;
        holdObject.transform.position = mousePosition;
    }

    void PickUpObject(Collider2D targetObject)
    {
        holdObject = targetObject.transform;
        startPosition = holdObject.position;
        if (holdObject.GetComponent<FoodState>().onPlatter)
        {
            platter.RemoveObject(holdObject.gameObject);
        }
    }

    void ToggleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (holdObject == null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject != null && targetObject.gameObject.layer == 6)
                {
                    PickUpObject(targetObject);
                }
            }
            else
            {
                CheckLocation();
                holdObject = null;
            }
        }
    }

    void HoldDrag()
    {
        if(Input.GetMouseButton(0))
        {
            if(holdObject == null)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
                if (targetObject != null && targetObject.gameObject.layer == 6)
                {
                    PickUpObject(targetObject);
                }
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(holdObject != null)
            {
                CheckLocation();
                holdObject = null;
            }
        }
    }

    void CheckLocation()
    {
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        Physics2D.OverlapCollider(holdObject.GetComponent<Collider2D>(), contactFilter2D, results);
        if(results.Count > 0)
        {
            if (results[results.Count - 1].name == "Platter")
            {
                if (results.Count > 1)
                {
                    holdObject.transform.position = startPosition;
                }
                else
                {
                    platter.AddObject(holdObject.gameObject);
                }
            }
            else
            {
                holdObject.transform.position = startPosition;
            }
        }
    }
}