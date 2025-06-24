using UnityEngine;

public class SheepMoveState : State<States>
{
    Animator animator;
    PathFindingMovement grid;
    SheepSteering steering;


    public SheepMoveState(PathFindingMovement pfNodeGrid, Animator animator,SheepSteering steering)
    {
        this.grid = pfNodeGrid;
        this.animator = animator;
        this.steering = steering;
    }

    public override void OnEnter()
    {
        steering.ChangeStearingMode(SheepSteering.SteeringMode.move);
        steering.changeDirection(grid.currentNodeGoingNow);
    }

    public override void Execute()
    {
        grid.CheckForCurrentNode();
    }

    public override void FixedExecute()
    {
  steering.ExecuteSteering();
    }

    public override void OnExit()
    {
      
    }

 
}
