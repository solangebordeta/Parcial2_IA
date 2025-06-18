using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyStateChase : State<States>
{

    WolfSteering steeringController;
    GameObject target;
    EnemyController enemcontroller; 
    public EnemyStateChase(WolfSteering controller,GameObject Target,EnemyController enemyController)
    {
        this.steeringController = controller;
        this.target = Target;
        this.enemcontroller = enemyController;
        }


    public override void OnEnter()
    {
    
        steeringController.Sheeptarget = target.transform;
        steeringController.Sheeptargetrb = target.GetComponent<Rigidbody>();

        steeringController.ChangeStearingMode(WolfSteering.SteeringMode.persuit);


    }
    public override void FixedExecute()
    {
       

    }
    
    

    public override void OnExit()
    {
        enemcontroller.Sheep = null;
    }
}
