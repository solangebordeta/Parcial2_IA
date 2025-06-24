using UnityEngine;

public class EnemyStateChase : State<States>
{
    private PFEntity pathEntity;
    private EnemyController controller;
    private GameObject sheep;

    public EnemyStateChase(PFEntity pathEntity, EnemyController controller)
    {
        this.pathEntity = pathEntity;
        this.controller = controller;
    }

    public override void OnEnter()
    {
        sheep = controller.Sheep;

        PFNodes sheepNode = GetClosestNode(sheep.transform.position);
        PFManager.Instance.SetPathSingle(pathEntity, sheepNode);
    }

    public override void FixedExecute()
    {
        pathEntity.Executepath();
    }

    PFNodes GetClosestNode(Vector3 pos)
    {
        var grid = PFManager.Instance.Grid;
        PFNodes closest = null;
        float minDist = float.MaxValue;
        foreach (var node in grid.nodeGrid)
        {
            float dist = Vector3.Distance(pos, node.transform.position);
            if (dist < minDist && !node.Blocked)
            {
                minDist = dist;
                closest = node;
            }
        }
        return closest;
    }
}



