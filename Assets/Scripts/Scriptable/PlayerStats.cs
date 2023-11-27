using UnityEngine;


[CreateAssetMenu(fileName = "PlayerStats", menuName = "ScriptableObject/PlayerConfig", order = 0)]
public class PlayerStats : ScriptableObject
{
    public float speed;
    public float rampUpSpeed;
    public float turnSpeed;
    public AnimationCurve speedCurve = new(new Keyframe(0, 0), new Keyframe(1, 1));
}
