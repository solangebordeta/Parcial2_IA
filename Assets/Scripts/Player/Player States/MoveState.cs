using UnityEngine;

internal class MoveState : State<States>
{
    Rigidbody rb;
    PlayerController controller;
    Animator animator;
    public MoveState(Rigidbody rb,PlayerController controller, Animator animator) 
    {
        this.rb = rb;
        this.controller = controller;
        this.animator = animator;
    }


    public override void OnEnter()
    {

    }
    public override void Execute()
    {

    }
    public override void FixedExecute()
    {
        controller.Movement(rb);
    }
    public override void OnExit() {  }
}
