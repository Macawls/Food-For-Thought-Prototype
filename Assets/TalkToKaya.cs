using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using Scriptable;
using UnityEngine;
using UnityEngine.Events;

public class TalkToKaya : MonoBehaviour
{
    [Expandable] [SerializeField] private Mission mission;
    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private Level level;

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

    public void LoadQuestion()
    {
        questionUI.LoadQuestion(level.questions.levelQuestions.First());
    }
}
