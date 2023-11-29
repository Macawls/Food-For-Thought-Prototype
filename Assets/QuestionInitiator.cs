using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestionInitiator : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private QuestionUI questionUI;
    [SerializeField] private UnityEvent start;
    [SerializeField] private UnityEvent end;

    private int index = 0;
    private int count;

    public void Play()
    {
        start?.Invoke();
        count = level.questions.levelQuestions.Count;
        questionUI.LoadQuestion(level.questions.levelQuestions[index]);
    }

    public void PlayNext()
    {
        if (index < count)
        {
            questionUI.ClearQuestion();
            index++;
            questionUI.LoadQuestion(level.questions.levelQuestions[index]);
        }

        else if (index == count)
        {
            end?.Invoke();
        }
    }

}
