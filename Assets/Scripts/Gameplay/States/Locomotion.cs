using System;
using Animancer;
using OceanFSM;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Locomotion : State<IPlayer>
{
    [SerializeField] private LinearMixerTransitionAsset.UnShared linearMixer;

    [SerializeField] [Range(0.0f, 1.0f)] private float runThreshold = 0.3f;
    [SerializeField] private UnityEvent onRanBegun;
    [SerializeField] private UnityEvent onRanEnd;
        
    private bool _mRanBegun;
    private Quaternion _mLookDirection;
    private float _mCurrentSpeed;
    private float _mElapsedTime;

    public override void OnEnter()
    {
        // set look direction here
        base.OnEnter();
        Runner.Animancer.Play(linearMixer);
    }

    public override void OnUpdate(float deltaTime)
    {
        var inputDir = Runner.InputDirection;

        if (inputDir == Vector2.zero)
        {
            var idle = Machine.ChangeState<Idle>();
        }
        
        // calc interpolated speed
        _mElapsedTime += deltaTime;
        float targetSpeed = inputDir.magnitude * Runner.Stats.speed * Runner.Stats.speedCurve.Evaluate(_mElapsedTime);
        _mCurrentSpeed = Mathf.Lerp(_mCurrentSpeed, targetSpeed, deltaTime * Runner.Stats.rampUpSpeed);
        
        // check if has fall component
        if (Runner.Transform.gameObject.TryGetComponent(out PlayerFall fall))
        {
            return;
        }

        // Change rb velocity
        var newVelocity =  new Vector3(inputDir.x, 0f, inputDir.y).normalized * _mCurrentSpeed;
        Runner.Rigidbody.velocity = newVelocity;

        // Change rb rotation
        var velocity = Runner.Rigidbody.velocity;

        if (velocity.normalized.magnitude > 0.7)
        {
            _mLookDirection = Quaternion.LookRotation(new Vector3(inputDir.x, 0, inputDir.y).normalized);
            var newRot = Quaternion.Slerp(Runner.Rigidbody.rotation, _mLookDirection, deltaTime * Runner.Stats.turnSpeed);
            Runner.Rigidbody.rotation = newRot;
        }
        
        float normalizedSpeed = (_mCurrentSpeed - 0f) / (Runner.Stats.speed - 0f);
        // mixer will choose appropriate animation
        linearMixer.State.Parameter = Mathf.Clamp01(normalizedSpeed);

        if (linearMixer.State.Parameter > runThreshold && !_mRanBegun)
        {
            _mRanBegun = true;
            onRanBegun?.Invoke();
        }
    }

    public override void OnExit()
    {
        if (_mRanBegun)
        {
            onRanEnd?.Invoke();
        }
        
        
        _mRanBegun = false;
        _mElapsedTime = 0f;
        _mCurrentSpeed = 0f;
    }
}


