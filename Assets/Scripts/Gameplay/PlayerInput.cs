using UnityAtoms.BaseAtoms;
using UnityEngine;

public enum InputStrategy
{
    Smooth,
    Raw
}

public class PlayerInput : MonoBehaviour
{
    public Vector2Variable inputVariable;
    public InputStrategy strategy;
    
    public void Update()
    {
        inputVariable.Value = strategy switch
        {
            InputStrategy.Raw => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")),
            InputStrategy.Smooth => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
            _ => inputVariable.Value
        };
    }
}
