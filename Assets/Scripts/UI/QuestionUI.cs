using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private RectTransform answerContainer;
    

    [Header("Variables")] 
    [SerializeField] private AnswerUI answerPrefab;
    [SerializeField] private AnswerHandlerUI answerHandlerUI;


    [Header("Events")] 
    [SerializeField] private UnityEvent<Question> onNewQuestion;
    [SerializeField] private UnityEvent onQuestionCleared;

    public void LoadQuestion(Question value)
    {
        onNewQuestion?.Invoke(value);
        question.text = value.content;
        
        foreach (var answer in value.answers)
        {
            var answerUI = Instantiate(answerPrefab, answerContainer);
            answerUI.Load(answer, answerHandlerUI.SelectAnswer);
        }
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