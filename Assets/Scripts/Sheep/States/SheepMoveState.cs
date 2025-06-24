using UnityEngine;

public class SheepMoveState : State<States>
{
    Animator animator;
    PFEntity grid;
    float repathTimer;
    float repathCooldown = 3f;

    public SheepMoveState(PFEntity pfNodeGrid, Animator animator)
    {
        this.grid = pfNodeGrid;
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
  
    }

    public override void OnExit()
    {
      
    }

 
}
