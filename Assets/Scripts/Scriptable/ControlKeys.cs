using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "NavigationKeys", menuName = "ScriptableObjects/NavigationKeys", order = 0)]
public class ControlKeys : ScriptableObject
{
#if UNITY_EDITOR
    [InfoBox("TODO: add joystick buttons for controller support")]
#endif
    
    public List<KeyCode> up;
    public List<KeyCode> down;
    
    public List<KeyCode> right;
    public List<KeyCode> left;

    public List<KeyCode> select;
}
