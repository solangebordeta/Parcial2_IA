using UnityEngine;

public class EnemyStatePatrol : State<States>
{
    PathFindingMovement pathFindingEnemyPatrol;
    WolfSteering wolfSteering;



    public EnemyStatePatrol(PathFindingMovement pathFindingEnemyPatrol,WolfSteering steering)
    {
    wolfSteering = steering;
     this.pathFindingEnemyPatrol = pathFindingEnemyPatrol;

    }

    public override void OnEnter()
    {
        wolfSteering.ChangeStearingMode(WolfSteering.SteeringMode.Move);
        wolfSteering.changeDirection(pathFindingEnemyPatrol.currentNodeGoingNow);
    }

    public override void Execute()
    {
     pathFindingEnemyPatrol.CheckForCurrentNode();
    }

    public override void FixedExecute()
    {
   wolfSteering.ExecuteSteering();
    }

    public override void OnExit() { }

   
}



