using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
[SerializeField] PFEntity PFEntity;
[SerializeField]SheepSteering controller;
[SerializeField] Flocking flock;
[SerializeField] SheepLOS LOS;
[SerializeField] Sheep Sheep;
[SerializeField] Animator animator;
 public GameObject Wolf;
 
 SheepMoveState moveState;
 SheepRunState runState;
 SheepFlockState flockState;

    FSM<States> fsm;
    ItreeNode root;
    // Start is called before the first frame update
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
    }

    private void IninFSM()
    {

       moveState = new SheepMoveState(PFEntity,animator);
       runState = new SheepRunState(controller,Wolf,animator);
       flockState = new SheepFlockState(controller,flock,animator);

        moveState.AddTransition(States.RunAway, runState);
        moveState.AddTransition(States.Flock, flockState);

        flockState.AddTransition(States.RunAway, runState);

        runState.AddTransition(States.Walk, moveState);
        runState.AddTransition(States.Flock, flockState);


        fsm = new FSM<States>();

    }
    // Update is called once per frame
    void Update()
    {
        fsm.OnExecute();
    }

    private void FixedUpdate()
    {
        fsm.OnFixedExecute();
    }
}
