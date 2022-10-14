using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StartSettingsScriptableObject", order = 1)]
public class StartSettingsScriptableObject : ScriptableObject
{
    public float distance;
    public float time;
    public float speed;
}
