using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateRunAway : State<States>
{
    public SteeringController SteeringController;


    public EnemyStateRunAway(SteeringController steeringController)
    {
        SteeringController = steeringController;
    }

    public override void OnEnter()
    {
        SteeringController.ChangeStearingMode(SteeringController.SteeringMode.flee);
    }

    public override void Execute()
    {
  
    }
    public override void FixedExecute()
    {
        SteeringController.ExecuteSteering();
    }

    public override void OnExit()
    {

    }
}

