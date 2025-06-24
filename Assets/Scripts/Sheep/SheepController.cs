using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class SheepController : MonoBehaviour
{
    [SerializeField] PFEntity PFNodeGrid;
    [SerializeField] SheepSteering controller;
    [SerializeField] SheepLOS LOS;
    [SerializeField] Sheep Sheep;
    [SerializeField] Animator animator;
    public GameObject Wolf;
    public bool isFollowingPlayer;

    SheepMoveState moveState;
    SheepRunState runState;
    SheepFlockState flockState;
    FSM<States> fsm;
    ItreeNode root;

    void Start()
    {
        IninFSM();
        IninTree();
    }

    private void IninTree()
    {
        var walk = new ActionTree(() => fsm.OnTransition(States.Walk));
        var runAway = new ActionTree(() => fsm.OnTransition(States.RunAway));
        var follow = new ActionTree(() => fsm.OnTransition(States.Flock));

        var isPlayerNear = new QuestionTree(() => isFollowingPlayer, follow, walk);
        var isCloseTo = new QuestionTree(() => isEnemiesNear(), runAway, isPlayerNear);
        root = isCloseTo;
    }

    private void IninFSM()
    {

       moveState = new SheepMoveState(PFNodeGrid, animator);
       runState = new SheepRunState( this,controller,animator);
       flockState = new SheepFlockState(controller,animator);

        moveState.AddTransition(States.RunAway, runState);
        moveState.AddTransition(States.Flock, flockState);

        flockState.AddTransition(States.RunAway, runState);

        runState.AddTransition(States.Walk, moveState);
        runState.AddTransition(States.Flock, flockState);


        fsm = new FSM<States>(moveState);

    }

    bool isEnemiesNear()
    {
        return LOS.seeingsomething();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnExecute();
        root.Execute();
    }

    private void FixedUpdate()
    {
        fsm.OnFixedExecute();
    }
}
