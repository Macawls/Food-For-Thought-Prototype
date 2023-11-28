using System.Collections;
using System.Collections.Generic;
using Scriptable;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectiveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI status;
    [SerializeField] private TextMeshProUGUI title;

    [SerializeField] private Image bg;
    [SerializeField] private Color successColor;
    [SerializeField] private UnityEvent onComplete;


    public void Init(Objective objective)
    {
        var s = objective.isCompleted ? "Complete" : "Incomplete";
        status.text = $"Status: {s}";

        title.text = objective.objectiveName;
        
        objective.onComplete?.AddListener(() =>
        {
            bg.color = successColor;
            var s = objective.isCompleted ? "Complete" : "Incomplete";
            status.text = $"Status: {s}";
            onComplete?.Invoke();
        });
    }
}
