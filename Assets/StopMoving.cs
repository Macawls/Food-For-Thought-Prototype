using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class StopMoving : MonoBehaviour
{
    [SerializeField] private Vector2Variable variable;

    public void Apply()
    {
        variable.Value = Vector2.zero;
    }
}
