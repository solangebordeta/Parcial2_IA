using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyController : MonoBehaviour
{
    PFEntity PathFinding;
    [SerializeField] private SteeringController SteeringController;

    [SerializeField] WolfEnemy enemy;

    private FSM<States> fsm;
    EnemyStateIdle idle;
    EnemyStateAttack attack;
    EnemyStatePatrol patrol;
    EnemyStateChase chase;
    EnemyStateRunAway runAway;

    ItreeNode root;
    void Start()
    {
        IninFSM();
        ininTree();
    }

    private void ininTree()
    {
        var patrol = new ActionTree(() => fsm.OnTransition(States.Patrol));
        var idle = new ActionTree(() => fsm.OnTransition(States.Idle));
        var attack = new ActionTree(() => fsm.OnTransition(States.Attack));
        var chase = new ActionTree(() => fsm.OnTransition(States.Chase));
        var runAway = new ActionTree(() => fsm.OnTransition(States.RunAway));
    }

    private void IninFSM()
    {

        patrol = new EnemyStatePatrol(PathFinding);
        chase = new EnemyStateChase(SteeringController);
        idle = new EnemyStateIdle(SteeringController);
        attack = new EnemyStateAttack(enemy);
        runAway = new EnemyStateRunAway(SteeringController);
        patrol.AddTransition(States.Idle, idle);
        patrol.AddTransition(States.Chase, chase);

        idle.AddTransition(States.Patrol, patrol);
        idle.AddTransition(States.Chase, chase);

        attack.AddTransition(States.Idle, idle);
        attack.AddTransition(States.Patrol, patrol);

        chase.AddTransition(States.Idle, idle);
        chase.AddTransition(States.Attack, attack);
        chase.AddTransition(States.Patrol, patrol);

        runAway.AddTransition(States.Idle, idle);
        runAway.AddTransition(States.Patrol, patrol);

        fsm = new FSM<States>(idle);
    }

    // Update is called once per frame
    void Update()
    {
      //  fsm.OnExecute();
       // root.Execute();
        
    }

    private void FixedUpdate()
    {
        fsm.OnFixedExecute();
    }
}
