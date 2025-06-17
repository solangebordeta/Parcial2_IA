using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class EnemyStatePatrol : State<States>
{

    PFEntity enemyPF;
    public EnemyStatePatrol(PFEntity entity)
    {
        this.enemyPF = entity;
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

