using UnityEngine;

public class EnemyStatePatrol : State<States>
{
    PFEntity enemyPF;
    PFNodeGrid grid;
    float patrolTimer;
    float patrolCooldown = 5f;

    public EnemyStatePatrol(PFEntity entity)
    {
        this.enemyPF = entity;
    }

    public override void OnEnter()
    {
        //grid = PFManager.Instance.Grid;
        //SetPatrolPath();
    }

    public override void Execute()
    {
        //patrolTimer += Time.deltaTime;
        //if (patrolTimer >= patrolCooldown)
        //{
        //    SetPatrolPath();
        //    patrolTimer = 0f;
        //}
    }

    public override void FixedExecute()
    {
        //enemyPF?.Executepath();
    }

    public override void OnExit() { }

    //void SetPatrolPath()
    //{
    //    if (grid == null || grid.nodeGrid == null || grid.nodeGrid.Length == 0) return;

    //    PFNodes randomPatrolNode = grid.nodeGrid[Random.Range(0, grid.nodeGrid.Length)];
    //    PFManager.Instance.SetPathSingle(enemyPF, randomPatrolNode);
    //}
}



