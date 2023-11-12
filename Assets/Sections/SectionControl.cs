using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SectionControl : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] List<Section> sections = new List<Section>();
    private int indexSection = -1;
    private Vector3 cameraPos = Vector3.zero;
    public void SwitchSections()
    {
        indexSection++;
        cameraPos = camera.position;
        camera.transform.position = sections[indexSection].cameraPosition;
        timer = sections[indexSection].timeToComplete;
        timerIsActive = true;
    }
    [SerializeField] MouseMove mouseMove;
    public void SwitchToMovement()
    {
        mouseMove.DropObject();
        camera.transform.position = cameraPos;
        GetComponent<MovementBetweenSections>().canWalk = true;
    }
    private float timer = 0;
    private bool timerIsActive = false;

    [SerializeField] Transform platter;
    void MovePlatter(float interpolationRatio)
    {
        platter.position = Vector3.Lerp(sections[indexSection].platterStart, 
                                        sections[indexSection].platterEnd, interpolationRatio);
    }
    private void Update()
    {
        if(timerIsActive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                MovePlatter(1 - (timer / sections[indexSection].timeToComplete));
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
