using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
[SerializeField] PFEntity PFEntity;
[SerializeField]SheepSteering controller;
[SerializeField] Flocking flock;
[SerializeField] lineofsight LOS;
[SerializeField] Sheep Sheep;
   

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

       moveState = new SheepMoveState(PFEntity);
       runState = new SheepRunState(controller);
       flockState = new SheepFlockState(controller,flock);

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
        
    }
}
