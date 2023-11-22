using System;
using UnityEngine;

[Serializable]
public class Run : PlayerStateBase
{
    public override void OnUpdate(float deltaTime)
    {
        var dir = Runner.InputDirection;
        Runner.Rigidbody.velocity = new Vector3(dir.x, 0, dir.y) * Runner.Stats.speed;
        
        if (Runner.InputDirection == Vector2.zero)
        {
            Machine.ChangeState<Idle>();
        }
    }
}

