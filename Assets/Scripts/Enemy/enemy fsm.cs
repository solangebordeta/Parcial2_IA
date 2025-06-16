using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class enemyfsm : MonoBehaviour
{

    [SerializeField] private SteeringController steering;
    private FSM<States> fsm;
    ItreeNode root;
    // Start is called before the first frame update
    void Start()
    {
        InitialilzeFSM();
        OnInin();
    }

    private void InitialilzeFSM()
    {

        var patrol = new EnemyStatePatrol();
        var idle = new EnemyStateIdle();
        var attack = new EnemyStateAttack();
        var chase = new EnemyStateChase();
        var runAway = new EnemyStateRunAway();

        // Transiciones
        patrol.AddTransition(States.Idle, idle);
        patrol.AddTransition(States.RunAway, runAway);
        patrol.AddTransition(States.Chase, chase);

        idle.AddTransition(States.Patrol, patrol);
        idle.AddTransition(States.RunAway, runAway);
        idle.AddTransition(States.Chase, chase);

        attack.AddTransition(States.Idle, idle);

        chase.AddTransition(States.Idle, idle);
        chase.AddTransition(States.Attack, attack);



        runAway.AddTransition(States.Idle, idle);
        runAway.AddTransition(States.Patrol, patrol);

        fsm = new FSM<States>(idle);

    }
    private void OnInin()
    {

        //ejecuta los estados
        var patrol = new ActionTree(() => fsm.OnTransition(States.Patrol));
        var idle = new ActionTree(() => fsm.OnTransition(States.Idle));
        var attack = new ActionTree(() => fsm.OnTransition(States.Attack));
        var chase = new ActionTree(() => fsm.OnTransition(States.Chase));
        var runAway = new ActionTree(() => fsm.OnTransition(States.RunAway));


    }
        void Update()
    {
        
    }
}
