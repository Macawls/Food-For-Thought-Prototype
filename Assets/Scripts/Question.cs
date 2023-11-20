using System;
using System.Collections.Generic;

[Serializable]
public class Question
{
    public string content;
    public List<Answer> answers;
}


[Serializable]
public class Questions
{
    public List<Question> levelQuestions;
}
