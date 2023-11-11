using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionControl : MonoBehaviour
{
    [SerializeField] List<Section> sections = new List<Section>();

    public void SwitchSections()
    {
        Debug.Log("Switched Sections");
    }
}
