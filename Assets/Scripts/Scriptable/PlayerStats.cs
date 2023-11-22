using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObject/PlayerConfig", order = 0)]
public class PlayerStats : ScriptableObject
{
    public float speed;
    public float turnSpeed;
}
