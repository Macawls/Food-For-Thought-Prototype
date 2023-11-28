using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimBinding : MonoBehaviour
{
    [SerializeField] private UnityEvent onEvent;

    public void TriggerEvent()
    {
        onEvent?.Invoke();
    }
}
