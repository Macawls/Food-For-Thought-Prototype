
using Animancer;
using UnityEngine;

public interface IPlayer
{
    Transform Transform { get; }
    AnimancerComponent Animancer { get; }
    Rigidbody Rigidbody { get; }
    PlayerStats Stats { get; }
    Vector2 InputDirection { get; }
    
    IPlayerAnimFeedbacks AnimFeedbacks { get; }
}
