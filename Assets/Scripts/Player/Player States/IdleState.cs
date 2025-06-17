using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<States>
{
    Animator animator;
    public IdleState(Animator animator)
    {
        this.animator = animator;   
    }


    public override void OnEnter()
    {

    }
    public override void Execute()
    {
        base.Execute();
    }

    public override void FixedExecute()
    {

    }
    public override void OnExit() { }
}
  
