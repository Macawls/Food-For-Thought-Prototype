
using Animancer;
using UnityEngine;

public interface IPlayer
{
    AnimancerComponent Animancer { get; }
    Rigidbody Rigidbody { get; }
    PlayerStats Stats { get; }
    
    public Vector2 InputDirection { get; }
}
