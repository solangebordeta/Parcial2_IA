using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateIdle : State<States>
{
    private SteeringController steeringController;

    public EnemyStateIdle()
    {
  
    }

    public EnemyStateIdle(SteeringController steeringController)
    {
        this.steeringController = steeringController;
    }

    public override void OnEnter()
    {
    
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
