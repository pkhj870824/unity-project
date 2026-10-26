using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObjectScript", menuName = "Scriptable Objects/NewScriptableObjectScript")]
public class ZombieData : ScriptableObject
{
    public float maxHp = 100f;
    public float damage = 20f;
    public float speed = 2f;
    public Color skinColor = Color.white;
}
