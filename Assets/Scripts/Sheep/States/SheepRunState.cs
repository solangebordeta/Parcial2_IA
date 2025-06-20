using UnityEngine;

public class SheepRunState : State<States>
{
    private SheepSteering controller;
    private GameObject wolf;
    Animator animator;
    public SheepRunState(SheepSteering controller, GameObject wolf, Animator animator)
    {
        this.controller = controller;
        this.wolf = wolf;
        this.animator = animator;
    }

    public override void OnEnter()
    {
        controller.WolfTargetRb = wolf.GetComponent<Rigidbody>();
        controller.WolfTransform = wolf.transform;
        controller.ChangeStearingMode(SheepSteering.SteeringMode.flee);
    }

    public override void Execute()
    {
        
    }

    public override void FixedExecute()
    {
      controller.ExecuteSteering();
    }
    public override void OnExit()
    {
        
    }
}
