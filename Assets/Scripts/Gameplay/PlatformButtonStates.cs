using System;
using DG.Tweening;
using OceanFSM;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ButtonActive : State<PlatformButtonController>
{
    [SerializeField] private Ease ease;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Vector3 position;

    public override void OnEnter()
    {
        Runner.current?.Kill();
        Perform();
    }

    private void Perform()
    {
        Runner.current = Runner.buttonTransform.DOLocalMove(position, duration).SetEase(ease);
    }
}

[Serializable]
public class ButtonInActive : State<PlatformButtonController>
{
    [SerializeField] private Ease ease;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private Vector3 position;
    
    public override void OnEnter()
    {
        Runner.current?.Kill();
        Perform();
    }
    
    private void Perform()
    {
        Runner.current = Runner.buttonTransform.DOLocalMove(position, duration).SetEase(ease);
    }
}

