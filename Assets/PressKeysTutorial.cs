using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Scriptable;
using UnityEngine;
using UnityEngine.Events;

public class PressKeysTutorial : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart;
    [SerializeField] private UnityEvent onEnd;
    [Expandable] [SerializeField] private Mission mission;
    public bool beginOnStart;

    public bool active;

    private Dictionary<KeyCode, int> keys = new()
    {
        {KeyCode.W, 0},
        {KeyCode.S, 1},
        {KeyCode.A, 2},
        {KeyCode.D, 3},
    };

    public void Start()
    {
        mission.complete?.AddListener(() =>
        {
            onEnd?.Invoke();
        });
        
        if (beginOnStart)
        {
            Activate();
        }
    }

    public void Activate()
    {
        active = true;
        onStart?.Invoke();
    }

    public void Update()
    {
        if (!active) return;
        
        CheckInput(KeyCode.A);
        CheckInput(KeyCode.W);
        CheckInput(KeyCode.D);
        CheckInput(KeyCode.S);
    }
    
    private void CheckInput(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            int index = keys[key];

            if (index >= 0 && index < mission.objectives.Count)
            {
                var objective = mission.objectives[index];

                if (!objective.isCompleted)
                {
                    objective.Complete();
                }
            }
        }
    }
}
