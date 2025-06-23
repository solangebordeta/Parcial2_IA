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
    public EnemyStateChase(WolfSteering controller,EnemyController enemyController)
    {
        this.steeringController = controller;
        this.enemcontroller = enemyController;
        }


    public override void OnEnter()
    {
        target = enemcontroller.Sheep;

        steeringController.Sheeptarget = target.transform;
        steeringController.Sheeptargetrb = enemcontroller.Sheep.GetComponent<Rigidbody>();

        steeringController.ChangeStearingMode(WolfSteering.SteeringMode.persuit);
    }
    public override void FixedExecute()
    {
       
        steeringController.ExecuteSteering();
    }
    
    

    public override void OnExit()
    {
        enemcontroller.Sheep = null;
        steeringController.Sheeptarget =  null;
        steeringController.Sheeptargetrb = null;
    }
}
