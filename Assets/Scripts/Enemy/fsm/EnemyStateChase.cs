using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyStateChase : State<States>
{

    SteeringController controller;
    public EnemyStateChase(SteeringController controller)
    {
        this.controller = controller;
        }


    public override void OnEnter()
    {
  
   
    }
    public override void FixedExecute()
    {
       

    }
    
    

    public override void OnExit()
    {

    }
}
