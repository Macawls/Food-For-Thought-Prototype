using System;
using OceanFSM;
using UnityEngine;

[Serializable]
public class PlayerStateBase : State<IPlayer>
{
    [SerializeField] private AnimationClip animation;
    public override void OnEnter()
    {
       
    }
}

