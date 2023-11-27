using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncToRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        var t = transform;
        t.position = rb.position;
        t.rotation = rb.rotation;
    }
}
