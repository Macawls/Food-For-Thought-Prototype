using System;
using System.Collections;
using System.Collections.Generic;
using Animancer;
using NaughtyAttributes;
using OceanFSM;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayer
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AnimancerComponent animancerComponent;
    public AnimancerComponent Animancer => animancerComponent;
    public Rigidbody Rigidbody => rb;
    public PlayerStats Stats => stats;
    public Vector2 InputDirection => inputVariable.Value;
    
    
    [Header("Variables")]
    [SerializeField] private Vector2Variable inputVariable;
    [Expandable] [SerializeField] private PlayerStats stats;
    
    
    [Header("States")]
    [SerializeField] private Idle idle;
    [SerializeField] private Run run;


    

    private IAutonomousMachine<IPlayer> fsm;

    private void Awake()
    {
        fsm = new AutonomousBuilder<IPlayer>(this)
            .AddState(idle)
            .AddState(run)
            .SetInitialState(nameof(Idle))
            .Build();
    }

    private void Start()
    {
        fsm.Start();
    }

    private void Update()
    {
        fsm.Update(Time.deltaTime);
    }

    private void OnDisable()
    {
        fsm.Stop();
    }
}
