using System;
using UnityEngine;

[Serializable]
public class Run : PlayerStateBase
{
    private Quaternion _mLookDirection;
    
    public override void OnUpdate(float deltaTime)
    {
        var inputDir = Runner.InputDirection;
        
        if (inputDir == Vector2.zero)
        {
            var idle = Machine.ChangeState<Idle>();
        }
        
        // change rb velocity
        Runner.Rigidbody.velocity = new Vector3(inputDir.x, 0, inputDir.y) * Runner.Stats.speed;
        
        // update look direction of the transform
        var velocity = Runner.Rigidbody.velocity;
        
        if (velocity != Vector3.zero)
        {
            _mLookDirection = Quaternion.LookRotation(velocity);
            
            Runner.Rigidbody.rotation = Quaternion.Slerp(Runner.Rigidbody.rotation, _mLookDirection, Time.deltaTime * Runner.Stats.turnSpeed);
            //Runner.Rigidbody.rotation = _mLookDirection;
        }
        

    }
}

