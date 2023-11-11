using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovementBetweenSections : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int numOfKeys;
    [SerializeField] List<Transform> playerPos;
    [SerializeField] ScoreCount scoreCount;
    private float keysPressed = 0;
    private int indexPos = 0;
    public bool canWalk = true;
    private SectionControl sectionControl;
    private void Awake()
    {
        player.transform.position = playerPos[indexPos].position;
        sectionControl = GetComponent<SectionControl>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canWalk)
        {
            keysPressed += 1;
            float interpolationRatio = keysPressed / numOfKeys;
            MovePlayer(interpolationRatio);
            if(interpolationRatio == 1)
            {
                keysPressed = 0;
                indexPos += 1;
                Debug.Log(indexPos);
                canWalk = false;
                if (indexPos < playerPos.Count - 1)
                {

                    sectionControl.SwitchSections();
                }
                else
                {
                    scoreCount.CalculateScore();
                }
            }
        }
    }

    void MovePlayer(float interpolationRatio)
    {
        Vector3 start = playerPos[indexPos].position;
        Vector3 end = playerPos[indexPos + 1].position;
        player.position = Vector3.Lerp(start, end, interpolationRatio);
    }
}
