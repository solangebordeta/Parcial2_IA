using UnityEngine;

public class SheepMoveState : State<States>
{

    PFEntity PFEntity;
    Animator animator;

    public SheepMoveState(PFEntity pFEntity, Animator animator)
    {
        PFEntity = pFEntity;
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
     //   PFEntity.Executepath();
    }
    public override void OnExit()
    {

    }
}