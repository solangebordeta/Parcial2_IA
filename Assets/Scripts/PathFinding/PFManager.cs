using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using System;


public class PFManager : MonoBehaviour
{
    public static PFManager Instance { get; private set; }
    [SerializeField] PFEntity entity;
    [SerializeField] PFNodeGrid grid;
    [SerializeField] float distanceToTarget;
    [SerializeField] Color startColor, endColor;
    [SerializeField] LayerMask walls;

    private void Awake()
    {
        Instance = this;
    }
    
    public void SetPath(PFNodes end)
    {
        var startNode = grid.nodeGrid.
            Where(x => (x.transform.position - entity.transform.position).sqrMagnitude <= entity.reachDistance * entity.reachDistance)
               .OrderBy(x => (x.transform.position - entity.transform.position).sqrMagnitude).FirstOrDefault();

        var path = new List<PFNodes>();       
        path = PathFinding.Astar(startNode, end, walls);
        entity.SetPath = path;
    }

    
    


}
