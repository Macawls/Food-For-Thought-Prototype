using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private RectTransform answerContainer;


    [Header("Variables")]
    [SerializeField] private AnswerUI answerPrefab;
    [SerializeField] private AnswerClickHandlerUI answerClickHandlerUI;


    [Header("Events")] 
    [SerializeField] private UnityEvent<Question> onNewQuestion;
    [SerializeField] private UnityEvent<List<AnswerUI>> onNewQuestionAnswerUI;
    [SerializeField] private UnityEvent onQuestionCleared;

    [SerializeField] private UnityEvent show;
    [SerializeField] private UnityEvent hide;

    [ContextMenu(nameof(Show))]
    public void Show()
    {
        show?.Invoke();
    }
    
    [ContextMenu(nameof(Hide))]
    public void Hide()
    {
        hide?.Invoke();
    }

    public void LoadQuestion(Question value)
    {
        question.text = value.content;
        var answerUis = new List<AnswerUI>();

        foreach (var answer in value.answers)
        {
            var ui = Instantiate(answerPrefab, answerContainer); // spawn
            ui.Load(answer, answerClickHandlerUI.SelectAnswer); // init with select callback
            
            answerUis.Add(ui);
        }
        
        onNewQuestion?.Invoke(value);
        onNewQuestionAnswerUI?.Invoke(answerUis);
    }

    public void ClearQuestion()
    {
        if (answerContainer.childCount > 0)
        {
            for (int i = 0; i < answerContainer.childCount; i++)
            {
                Destroy(answerContainer.GetChild(i).gameObject);
            }
        }
        
        onQuestionCleared?.Invoke();
    }
}