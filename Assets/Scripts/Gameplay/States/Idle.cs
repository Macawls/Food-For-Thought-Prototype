using System;
using UnityEngine;

[Serializable]
public class Idle : PlayerStateBase
{
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnUpdate(float deltaTime)
    {
        base.OnUpdate(deltaTime);

        if (Runner.InputDirection != Vector2.zero)
        {
            Machine.ChangeState<Run>();
        }
    }
}

