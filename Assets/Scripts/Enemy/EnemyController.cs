using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyController : MonoBehaviour
{

    [SerializeField] PathFindingMovement PathFinding;
    [SerializeField] private WolfSteering SteeringController;
    [SerializeField] WolfEnemy enemy;
    [SerializeField] lineofsight playerLOS;
    [SerializeField] EnemyLOS wolfLOS;
    [SerializeField] EnemyLOS wolfAttackLOS;
    [SerializeField] GameObject player;
    public GameObject Sheep;
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
        var attack = new ActionTree(() => fsm.OnTransition(States.Attack));
        var chase = new ActionTree(() => fsm.OnTransition(States.Chase));
        var runAway = new ActionTree(() => fsm.OnTransition(States.RunAway));

        var iscloseto = new QuestionTree(() => inattackRange(), attack, chase);
        var qsawsheep = new QuestionTree(() => hasseemsheep(), iscloseto, patrol);
        var qisoutsideview = new QuestionTree(() => lostplayer(), patrol, runAway);
        var qsawbyplayer = new QuestionTree(() => ISbeingseen(),qisoutsideview, qsawsheep);
        root = qsawbyplayer;
    }

    private bool lostplayer()
    {
        return Vector3.Distance(this.transform.position, player.transform.position) >= wolfLOS.loseplayer;
    }

    bool inattackRange()
    {
        return Vector3.Distance(this.transform.position, Sheep.transform.position) <= wolfAttackLOS.detectionRange;
    }
    public bool hasseemsheep()
    {
        return wolfLOS.seeingsomething();
    }

    private void IninFSM()
    {

        patrol = new EnemyStatePatrol(PathFinding,SteeringController);
        chase = new EnemyStateChase(SteeringController, this);
        attack = new EnemyStateAttack(this.gameObject,Sheep,this);
        runAway = new EnemyStateRunAway(SteeringController);

        patrol.AddTransition(States.Idle, idle);
        patrol.AddTransition(States.Chase, chase);
        patrol.AddTransition(States.RunAway, runAway);

     
        attack.AddTransition(States.Patrol, patrol);

   
        chase.AddTransition(States.Attack, attack);
        chase.AddTransition(States.Patrol, patrol);
        chase.AddTransition(States.RunAway, runAway);

        runAway.AddTransition(States.Patrol, patrol);

        fsm = new FSM<States>(patrol);
    }

    bool ISbeingseen()
    {

        return playerLOS.CheckDistance(this.transform);
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
