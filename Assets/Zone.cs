using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Zone : MonoBehaviour
{

    [SerializeField] private string tagName;

    [SerializeField] private UnityEvent enter;
    [SerializeField] private UnityEvent exit;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tag))
        {
            enter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tag))
        {
            exit?.Invoke();
        }
    }
}
