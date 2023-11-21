using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector2Variable inputVariable;

    [SerializeField] private Rigidbody rb;


    [SerializeField] private float speed;


    private void Update()
    {
        var dir = inputVariable.Value;
        rb.velocity = new Vector3(dir.x, 0, dir.y) * speed;
    }
}
