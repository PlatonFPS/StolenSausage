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

    private Transform holdObject = null;

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
                    holdObject = targetObject.transform;
                }
            }
            else
            {
                holdObject = null;
            }
        }
    }

    void HoldDrag()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject != null && targetObject.gameObject.layer == 6)
            {
                holdObject = targetObject.transform;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            holdObject = null;
        }
    }
}
