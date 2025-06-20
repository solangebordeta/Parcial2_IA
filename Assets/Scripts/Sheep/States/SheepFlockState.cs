using UnityEngine;

public class SheepFlockState : State<States>
{
    private SheepSteering controller;
    private Flocking flock;
    private Animator animator;

    public SheepFlockState(SheepSteering controller, Flocking flock,Animator animator)
    {
        this.controller = controller;
        this.flock = flock;
        this.animator = animator;
    }

    public override void OnEnter()
    {
        controller.ChangeStearingMode(SheepSteering.SteeringMode.follow);
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