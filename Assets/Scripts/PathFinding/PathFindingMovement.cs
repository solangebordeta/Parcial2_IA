using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindingMovement : MonoBehaviour
{
    public List<PFNodes> pFNodesStartAndEnd;
    [SerializeField] LayerMask mask;
     public float distanceNodeArrival;

    private int beginningNode;
    private int endingNode;

    public List<PFNodes> pFNodesAllRoute { get; private set; }

    public int currentNodeRoute {  get; private set; }
    
    public Transform currentNodeGoingNow { get; private set; }

    private void Start()
    {
        beginningNode = 0;
        endingNode = 1;

        if (pFNodesStartAndEnd == null || pFNodesStartAndEnd.Count < 2)
        {
            Debug.LogError("Debe haber al menos 2 nodos asignados en 'pFNodesStartAndEnd'");
            return;
        }

        pFNodesAllRoute = PathFinding.Astar(pFNodesStartAndEnd[beginningNode], pFNodesStartAndEnd[endingNode], mask);

        if (pFNodesAllRoute == null || pFNodesAllRoute.Count == 0)
        {
            Debug.LogError("El pathfinding no devolvió ningún camino.");
            return;
        }

        currentNodeRoute = 0;
        currentNodeGoingNow = pFNodesAllRoute[currentNodeRoute].transform;
    }


    public void CheckForCurrentNode()
    {
        if (pFNodesAllRoute == null || pFNodesAllRoute.Count == 0 || currentNodeRoute >= pFNodesAllRoute.Count)
        {
            Debug.LogWarning("No hay camino disponible o el índice está fuera de rango.");
            return;
        }

        if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                             new Vector3(pFNodesAllRoute[currentNodeRoute].transform.position.x, 0, pFNodesAllRoute[currentNodeRoute].transform.position.z)) <= distanceNodeArrival)
        {
            if (currentNodeRoute < pFNodesAllRoute.Count - 1)
            {
                currentNodeRoute++;
                currentNodeGoingNow = pFNodesAllRoute[currentNodeRoute].transform;
            }
        }
    }

}
