using UnityEngine;

public class FoodState : MonoBehaviour
{
    public bool onPlatter = false;
    public bool concealed = false;
    public Transform prevParent = null;

    private void Awake()
    {
        prevParent = transform.parent;
    }
}
