using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SectionControl : MonoBehaviour
{
    [SerializeField] Transform camera = null;
    [SerializeField] List<Section> sections = new List<Section>();
    private int indexSection = 0;
    private Vector3 cameraPos = Vector3.zero;
    private void Awake()
    {
        cameraPos = camera.position;
    }
    public void SwitchSections()
    {
        camera.transform.position = sections[indexSection].cameraPosition;
        indexSection++;
        timer = 10f;
        timerIsActive = true;
    }
    public void SwitchToMovement()
    {
        camera.transform.position = cameraPos;
        GetComponent<MovementBetweenSections>().canWalk = true;
    }
    private float timer = 0;
    private bool timerIsActive = false;
    private void Update()
    {
        if(timerIsActive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = 0;
                timerIsActive = false;
                SwitchToMovement();
            }
        }
    }
}
