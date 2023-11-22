using System;
using UnityEngine;

[Serializable]
public class Idle : PlayerStateBase
{
    [HideInInspector] public Quaternion lookDirection = Quaternion.identity;
    
    public override void OnEnter()
    {
        base.OnEnter();
        
        /*
        var transformRotation = Runner.Transform.rotation;
        float yRot = transformRotation.eulerAngles.y;
        transformRotation.eulerAngles = new Vector3(0, yRot, 0);

        Runner.Transform.rotation = transformRotation;
        */
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

