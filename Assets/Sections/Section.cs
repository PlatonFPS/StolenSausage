using UnityEngine;

[CreateAssetMenu(fileName = "Section")]
public class Section : ScriptableObject
{
    public float timeToComplete;
    public Vector3 cameraPosition;
    public Vector3 platterStart;
    public Vector3 platterEnd;
}
