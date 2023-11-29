using System;
using Scriptable;
using UnityEngine;
using UnityEngine.Events;

public class AnswerQuestionsMission : MonoBehaviour
{
    [SerializeField] private Mission mission;


    [SerializeField] private UnityEvent end;
    [SerializeField] private UnityEvent start;

    public void Start()
    {
        mission.complete.AddListener(() => end?.Invoke());
    }

    public void BeginMission()
    {
        start?.Invoke();
    }

    public void Satisfy()
    {
        if (!mission.objectives[0].isCompleted)
        {
            mission.objectives[0].Complete();
        }
    }
} 
