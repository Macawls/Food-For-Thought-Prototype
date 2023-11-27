using System;
using DG.Tweening;
using OceanFSM;
using UnityEngine;

public class PlatformButtonController : MonoBehaviour
{
    private IAutonomousMachine<PlatformButtonController> fsm;
    
    public Transform buttonTransform;
    public Tween current;

    [SerializeField] private ButtonInActive inactive;
    [SerializeField] private ButtonActive active;

    private void Awake()
    {
        fsm = new AutonomousBuilder<PlatformButtonController>(this)
            .AddState(inactive)
            .AddState(active)
            .Build();
    }

    private void OnDisable()
    {
        fsm.Stop();
    }

    private void Update()
    {
        fsm.Update(Time.deltaTime);
    }

    public void Activate()
    {
        fsm.ChangeState<ButtonActive>();
    }

    public void DeActivate()
    {
        fsm.ChangeState<ButtonInActive>();
    }
}
