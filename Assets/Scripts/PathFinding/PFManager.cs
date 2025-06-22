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

    
    


}
