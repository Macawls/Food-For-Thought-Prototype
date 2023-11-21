using System;
using UnityEngine;
using UnityEngine.Events;

public class AnswerClickHandlerUI : MonoBehaviour
{
    [SerializeField] private UnityEvent<Answer> onCorrectSelected;
    [SerializeField] private UnityEvent<Answer> onWrongSelected;
    
    
    public void SelectAnswer(Answer value)
    {
        if (value.isCorrect)
        {
            onCorrectSelected?.Invoke(value);
        }
        else
        {
            onWrongSelected?.Invoke(value);
        }
    }
}



