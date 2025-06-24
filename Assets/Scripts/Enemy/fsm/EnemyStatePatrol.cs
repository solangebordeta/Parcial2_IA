using UnityEngine;

public class EnemyStatePatrol : State<States>
{
    PathFindingEnemyPatrol pathFindingEnemyPatrol;

    PFEntity enemyPF;
    PFNodeGrid grid;

    float patrolTimer;
    float patrolCooldown = 5f;

    public EnemyStatePatrol(PFEntity entity, PathFindingEnemyPatrol pathFindingEnemyPatrol)
    {
        this.enemyPF = entity;
        this.pathFindingEnemyPatrol = pathFindingEnemyPatrol;
    }

    public override void OnEnter()
    {
        //grid = PFManager.Instance.Grid;
        //SetPatrolPath();
    }

    public override void Execute()
    {
        pathFindingEnemyPatrol.CheckForCurrentNode();
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



