using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using NaughtyAttributes;
using OceanFSM;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayer
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private HybridAnimancerComponent animancerComponent;
    [SerializeField] private PlayerAnimationFeedbacks animationFeedbacks;
    public Transform Transform => transform;
    public AnimancerComponent Animancer => animancerComponent;
    public Rigidbody Rigidbody => rb;
    public PlayerStats Stats => stats;
    public Vector2 InputDirection => inputVariable.Value;
    public IPlayerAnimFeedbacks AnimFeedbacks => animationFeedbacks;


    [Header("Variables")]
    [SerializeField] private Vector2Variable inputVariable;
    [Expandable] [SerializeField] private PlayerStats stats;
    
    
    [Header("States")]
    [SerializeField] private Idle idle;
    [SerializeField] private Locomotion locomotion;

    [Header("Events")] 
    [SerializeField] private UnityEvent<State<IPlayer>> onNewState;
    private IAutonomousMachine<IPlayer> _mFsm;

    private void Awake()
    {
        _mFsm = new AutonomousBuilder<IPlayer>(this)
            .AddState(idle)
            .AddState(locomotion)
            .SetInitialState<Idle>()
            .Build();
    }

    private void OnEnable()
    {
        _mFsm.StateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        _mFsm.StateChanged -= OnStateChanged;
        
        _mFsm.Stop();
    }

    private void OnStateChanged(State<IPlayer> state)
    {
        onNewState?.Invoke(state);
    }

    private void Start()
    {
        _mFsm.Start();
    }

    private void Update()
    {
        _mFsm.Update(Time.deltaTime);
    }
}
