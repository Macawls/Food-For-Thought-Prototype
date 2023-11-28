using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using Scriptable;
using UnityEngine;
using UnityEngine.Events;

public class TalkToKaya : MonoBehaviour
{
    [Expandable] [SerializeField] private Mission mission;

    [SerializeField] private UnityEvent end;
    [SerializeField] private UnityEvent start;


    private void Start()
    {
        mission.complete?.AddListener(() => end.Invoke());
    }

    public void Begin()
    {
        start?.Invoke();
    }

    public void Satisfy()
    {
        mission.objectives[0].Complete();
    }
}
