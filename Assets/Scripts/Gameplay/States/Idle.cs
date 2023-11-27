using System;
using OceanFSM;
using UnityEngine;

[Serializable]
public class Idle : State<IPlayer>
{
    [SerializeField] private AnimationClip idle;
    [HideInInspector] public Quaternion lookDirection = Quaternion.identity;
    
    public override void OnEnter()
    {
        Runner.Animancer.Play(idle);
    }
    
    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (Runner.InputDirection != Vector2.zero)
        {
            Machine.ChangeState<Locomotion>();
        }
    }
}

