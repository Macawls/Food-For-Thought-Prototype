using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerAnimFeedbacks
{
    void TriggerStep();
    void TriggerLand();
    void TriggerWalkStep();
}

public class PlayerAnimationFeedbacks : MonoBehaviour, IPlayerAnimFeedbacks
{
    [SerializeField] private UnityEvent onStep;
    [SerializeField] private UnityEvent onLand;
    [SerializeField] private UnityEvent onWalkStep;

    public void TriggerStep()
    {
        onStep?.Invoke();
    }

    public void TriggerLand()
    {
        onLand?.Invoke();
    }

    public void TriggerWalkStep()
    {
        onWalkStep?.Invoke();
    }
}
