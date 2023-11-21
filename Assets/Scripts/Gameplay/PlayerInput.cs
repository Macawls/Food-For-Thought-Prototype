using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    public Vector2Variable inputVariable;

    public void Update()
    {
        inputVariable.Value = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
