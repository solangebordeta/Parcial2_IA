using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateRunAway : State<States>
{
    public WolfSteering SteeringController;


    public EnemyStateRunAway(WolfSteering steeringController)
    {
        SteeringController = steeringController;
    }

    public override void OnEnter()
    {
        SteeringController.ChangeStearingMode(WolfSteering.SteeringMode.flee);
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

