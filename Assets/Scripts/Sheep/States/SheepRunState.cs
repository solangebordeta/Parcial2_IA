using UnityEngine;

public class SheepRunState : State<States>
{
    private PFNodeGrid grid;
    private GameObject wolf;
    private Animator animator;

    public SheepRunState(PFNodeGrid pf, GameObject wolf, Animator anim)
    {
        this.grid = pf;
        this.wolf = wolf;
        this.animator = anim;
    }

    public override void OnEnter()
    {
        animator.SetTrigger("Run");

        PFNodes farthestNode = GetFarthestNode(wolf.transform.position);
        PFManager.Instance.SetPathSingle(grid, farthestNode);
    }

    public override void FixedExecute()
    {
        grid.Executepath();
    }

    PFNodes GetFarthestNode(Vector3 fromPos)
    {
        var grid = PFManager.Instance.Grid;
        PFNodes farthest = null;
        float maxDist = float.MinValue;
        foreach (var node in grid.nodeGrid)
        {
            float dist = Vector3.Distance(fromPos, node.transform.position);
            if (dist > maxDist && !node.Blocked)
            {
                maxDist = dist;
                farthest = node;
            }
        }
        return farthest;
    }
}


