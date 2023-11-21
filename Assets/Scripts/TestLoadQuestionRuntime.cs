using NaughtyAttributes;
using UnityEngine;

public class TestLoadQuestionRuntime : MonoBehaviour
{
    [SerializeField] private Level level;
    [SerializeField] private QuestionUI questionUI;


    public int currentIndex = 0;


    public void LoadNextQuestion()
    {
        currentIndex++;
        
        if (currentIndex >= level.questions.levelQuestions.Count)
        {
            // next level or do something else
            return;
        }
        
        questionUI.ClearQuestion();
        questionUI.LoadQuestion(level.questions.levelQuestions[currentIndex]);
    }

#if UNITY_EDITOR
    [Button("Load question", EButtonEnableMode.Playmode)]
    private void LoadQuestion()
    {
        questionUI.LoadQuestion(level.questions.levelQuestions[currentIndex]);
    }
#endif
    
}
