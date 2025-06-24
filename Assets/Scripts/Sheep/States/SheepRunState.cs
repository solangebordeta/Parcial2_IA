using UnityEngine;

public class SheepRunState : State<States>
{
 
    private GameObject wolf;
    SheepController controller;
    SheepSteering sheepSteering;
    private Animator animator;

    public SheepRunState( SheepController wolf, SheepSteering steering,Animator anim)
    {
        sheepSteering = steering;
        controller = wolf;
        this.animator = anim;
    }

    public override void OnEnter()
    {
        wolf = controller.Wolf;
        sheepSteering.Target = wolf;
        sheepSteering.ChangeStearingMode(SheepSteering.SteeringMode.flee);
    }

    public override void FixedExecute()
    {
        sheepSteering.ExecuteSteering();

    }

    public override void OnExit()
    {
   wolf = null;
   controller.Wolf = null;
    }
}


