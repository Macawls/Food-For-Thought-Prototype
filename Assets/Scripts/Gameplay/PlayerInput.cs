using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;


public enum InputStrategy
{
    Regular,
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
            InputStrategy.Raw => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized,
            InputStrategy.Regular => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
            _ => inputVariable.Value
        };
    }
}
