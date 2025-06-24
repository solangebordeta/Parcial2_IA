using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;
using System;
public class PFManager : MonoBehaviour
{
    public static PFManager Instance { get; private set; }
    [SerializeField] PFEntity[] entities;
    [SerializeField] PFNodeGrid grid;
    [SerializeField] float distanceToTarget;
    [SerializeField] LayerMask walls;

    public PFNodeGrid Grid => grid;


    private void Awake()
    {
        Instance = this;
    }
    
    public void SetPath(PFNodes end)
    {
        for (int i = 0; i < entities.Length; i++) 
        {
               var startNode = grid.nodeGrid.
            Where(x => (x.transform.position - entities[i].transform.position).sqrMagnitude <= entities[i].reachDistance * entities[i].reachDistance)
               .OrderBy(x => (x.transform.position - entities[i].transform.position).sqrMagnitude).FirstOrDefault();

        var path = new List<PFNodes>();       
        path = PathFinding.Astar(startNode, end, walls);
            entities[i].SetPath = path;
        }
     
    }

    public void SetPathSingle(PFEntity entity, PFNodes end)
    {
        var startNode = grid.nodeGrid
            .Where(x => (x.transform.position - entity.transform.position).sqrMagnitude <= entity.reachDistance * entity.reachDistance)
            .OrderBy(x => (x.transform.position - entity.transform.position).sqrMagnitude)
            .FirstOrDefault();

        if (startNode == null) return;

        var path = PathFinding.Astar(startNode, end, walls);
        entity.SetPath = path;
    }
}
