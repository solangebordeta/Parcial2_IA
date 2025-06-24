using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingMovement : MonoBehaviour
{
    [SerializeField] List<PFNodes> pFNodesStartAndEnd;
    [SerializeField] LayerMask mask;
    [SerializeField] float distanceNodeArrival;

    private int beginningNode;
    private int endingNode;

    public List<PFNodes> pFNodesAllRoute { get; private set; }

    public int currentNodeRoute {  get; private set; }
    
    public Transform currentNodeGoingNow { get; private set; }

    private void Start()
    {
        beginningNode = 0;
        endingNode = 1;

        pFNodesAllRoute = PathFinding.Astar(pFNodesStartAndEnd[beginningNode], pFNodesStartAndEnd[endingNode], mask);

        currentNodeGoingNow = pFNodesAllRoute[currentNodeRoute].transform;
    }

    public void CheckForCurrentNode()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(pFNodesAllRoute[currentNodeRoute].transform.position.x, 0, pFNodesAllRoute[currentNodeRoute].transform.position.z)) <= distanceNodeArrival)
        {
            if (currentNodeRoute < pFNodesAllRoute.Count - 1)
            {
                currentNodeRoute++;
                currentNodeGoingNow = pFNodesAllRoute [currentNodeRoute].transform;
            }
        }
    }
}
