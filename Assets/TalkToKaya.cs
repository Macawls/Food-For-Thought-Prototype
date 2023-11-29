using NaughtyAttributes;
using Scriptable;
using UnityEngine;
using UnityEngine.Events;

public class TalkToKaya : MonoBehaviour
{
    [Expandable] [SerializeField] private Mission mission;

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
        if (mission.objectives[0].isCompleted) return;
        mission.objectives[0].Complete();
    }
}
