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

    private Vector3 startPosition = Vector3.zero;
    private Transform startParent = null;
    void PickUpObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (targetObject != null && targetObject.gameObject.layer == 6)
        {
            holdObject = targetObject.transform;
            startParent = holdObject.parent;
            startPosition = holdObject.localPosition;
            if (holdObject.GetComponent<FoodState>().onPlatter)
            {
                platter.RemoveObject(holdObject.gameObject);
            }
        }
    }

    void ToggleDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (holdObject == null)
            {
                PickUpObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    void HoldDrag()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(holdObject == null)
            {
                PickUpObject();
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(holdObject != null)
            {
                DropObject();
            }
        }
    }

    public void DropObject()
    {
        if(holdObject != null)
        {
            CheckLocation();
            holdObject = null;
        }
    }

    void CheckLocation()
    {
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        Physics2D.OverlapCollider(holdObject.GetComponent<Collider2D>(), contactFilter2D, results);
        if(results.Count > 0)
        {
            if (results.Count > 1)
            {
                if (results[results.Count - 2].tag == "Platter" && results[results.Count - 1].tag == "Table")
                {
                    if (results.Count == 2)
                    {
                        platter.AddObject(holdObject.gameObject);
                        return;
                    }
                    else if(results.Count == 3)
                    {
                        if(holdObject.tag == "Rag" && results[0].tag == "Sdoba")
                        {
                            
                            return;
                        }
                    }
                }
            }
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        if (startParent == platter.transform)
        {
            platter.AddObject(holdObject.gameObject);
        }
        else
        {
            holdObject.transform.parent = startParent;
        }
        holdObject.transform.localPosition = startPosition;
    }
}
