using UnityEngine;

public class SheepMoveState : State<States>
{
    Animator animator;
    PFNodeGrid grid;
    float repathTimer;
    float repathCooldown = 3f;

    public SheepMoveState(PFNodeGrid pfNodeGrid, Animator animator)
    {
        this.grid = pfNodeGrid;
        this.animator = animator;
    }

    public override void OnEnter()
    {
        // Cargar el grid cuando PFManager ya fue inicializado
        grid = PFManager.Instance.Grid;
        SetNewRandomPath();
        animator?.SetBool("isWalking", true);
    }

    public override void Execute()
    {
        repathTimer += Time.deltaTime;
        if (repathTimer >= repathCooldown)
        {
            SetNewRandomPath();
            repathTimer = 0f;
        }
    }

    public override void FixedExecute()
    {
        grid.Executepath();
    }

    public override void OnExit()
    {
        animator?.SetBool("isWalking", false);
    }

    void SetNewRandomPath()
    {
        if (grid == null || grid.nodeGrid == null || grid.nodeGrid.Length == 0) return;

        PFNodes randomTarget = grid.nodeGrid[Random.Range(0, grid.nodeGrid.Length)];
        PFManager.Instance.SetPathSingle(grid, randomTarget);
    }
}
