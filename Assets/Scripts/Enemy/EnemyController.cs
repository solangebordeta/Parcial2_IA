using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyController : MonoBehaviour
{

   [SerializeField] PFEntity PathFinding;
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
        var qsawbyplayer = new QuestionTree(() => ISbeingseen(), runAway,qsawsheep);
        root = qsawbyplayer;

        
    }

     bool inattackRange()
    {
        return Vector3.Distance(this.transform.position, Sheep.transform.position) <= wolfAttackLOS.detectionRange;
    }
   bool hasseemsheep()
    {
        return wolfLOS.seeingsomething();
    }

    private void IninFSM()
    {

        patrol = new EnemyStatePatrol(PathFinding);
        chase = new EnemyStateChase(SteeringController,Sheep,this);
        attack = new EnemyStateAttack(enemy);
        runAway = new EnemyStateRunAway(SteeringController);

        patrol.AddTransition(States.Idle, idle);
        patrol.AddTransition(States.Chase, chase);
        patrol.AddTransition(States.RunAway, runAway);

        attack.AddTransition(States.Idle, idle);
        attack.AddTransition(States.Patrol, patrol);

        chase.AddTransition(States.Idle, idle);
        chase.AddTransition(States.Attack, attack);
        chase.AddTransition(States.Patrol, patrol);

        runAway.AddTransition(States.Idle, idle);
        runAway.AddTransition(States.Patrol, patrol);

        fsm = new FSM<States>(patrol);
    }

    bool ISbeingseen()
    {
      
        return Vector3.Distance(this.transform.position,player.transform.position) <= playerLOS.detectionRange;
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
