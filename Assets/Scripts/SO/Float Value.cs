using UnityEngine;

[CreateAssetMenu(menuName = "Data/FloatValue")]
public class FloatValue : ScriptableObject
{
    public float defaultValue = 1f;
    public float value;
}