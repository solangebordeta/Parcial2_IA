using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateIdle : State<States>
{
    private WolfSteering steeringController;

    public EnemyStateIdle()
    {
  
    }

    public EnemyStateIdle(WolfSteering steeringController)
    {
        this.steeringController = steeringController;
    }

    public override void OnEnter()
    {
    steeringController.ChangeStearingMode(WolfSteering.SteeringMode.None);
    }

    public override void Execute()
    {
   
      
    }
    public override void FixedExecute()
    {
    }



    public override void OnExit()
    {
   
    }
}
