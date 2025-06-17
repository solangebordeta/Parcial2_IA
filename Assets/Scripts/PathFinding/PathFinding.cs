using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathFinding
{
    public static List<PFNodes> BFS(PFNodes start, PFNodes end)
    {
        var frontier = new Queue<PFNodes>();
        frontier.Enqueue(start);
        Dictionary<PFNodes, PFNodes> cameFrom = new() { { start, null } };

        while(frontier.Count > 0)
        {
            PFNodes currentInSearch = frontier.Dequeue();
            currentInSearch.Color = Color.gray;

            if(currentInSearch == end)
            {
                //Creación del Path
                PFNodes currentInPath = end;
                List<PFNodes> path = new();
                while (currentInPath != null) //Podemos preguntar que sea distinto de start para no agregarlo
                {
                    path.Add(currentInPath);
                    currentInPath = cameFrom[currentInPath];
                }
                path.Reverse();
                return path; 
            }

            for (int i = 0; i < currentInSearch.Neighbors.Count; i++)
            {
                //Podríamos hacer la salida anticipada en esta instancia donde se encuentra el final como vecino del actual
                var next = currentInSearch.Neighbors[i];
                if (next.Blocked) continue;
                if(!cameFrom.ContainsKey(next))
                {
                    frontier.Enqueue(next);
                    cameFrom.Add(next, currentInSearch);
                }
            }
        }
        return new();
    }

    public static List<PFNodes> DFS(PFNodes start, PFNodes end)
    {
        var frontier = new Stack<PFNodes>();
        frontier.Push(start);
        Dictionary<PFNodes, PFNodes> cameFrom = new() { { start, null } };

        while (frontier.Count > 0)
        {
            PFNodes currentInSearch = frontier.Pop();
            currentInSearch.GetComponent<Renderer>().material.color = Color.cyan;
            if (currentInSearch == end)
            {
                //Creación del Path
                PFNodes currentInPath = end;
                List<PFNodes> path = new();
                while (currentInPath != null) //Podemos preguntar que sea distinto de start para no agregarlo
                {
                    path.Add(currentInPath);
                    currentInPath = cameFrom[currentInPath];
                }
                path.Reverse();
                return path;
            }

            for (int i = 0; i < currentInSearch.Neighbors.Count; i++)
            {
                var next = currentInSearch.Neighbors[i];
                if (next.Blocked) continue;

                if (!cameFrom.ContainsKey(next))
                {
                    frontier.Push(next);
                    cameFrom.Add(next, currentInSearch);
                }
            }
        }

        return null;
    }

    public static List<PFNodes> Dijkstra(PFNodes start, PFNodes end)
    { 
        var frontier = new PriorityQueue<PFNodes>();
        frontier.Enqueue(start, 0);
        Dictionary<PFNodes, float> costSoFar = new() { { start, 0 } };
        Dictionary<PFNodes, PFNodes> cameFrom = new() { { start, null } };

        while (!frontier.IsEmpty)
        {
            PFNodes currentInSearch = frontier.Dequeue();
            currentInSearch.Color = Color.Lerp(Color.yellow, Color.red, currentInSearch.Cost/5);

            if (currentInSearch == end)
            {
                //Creación del Path
                PFNodes currentInPath = end;
                List<PFNodes> path = new();
                while (currentInPath != null) //Podemos preguntar que sea distinto de start para no agregarlo
                {
                    path.Add(currentInPath);
                    currentInPath = cameFrom[currentInPath];
                }
                path.Reverse();
                return path;
            }

            for (int i = 0; i < currentInSearch.Neighbors.Count; i++)
            {
                var next = currentInSearch.Neighbors[i];
                if (next.Blocked) continue;
                float newCost = costSoFar[currentInSearch] + next.Cost;
                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;
                    frontier.Enqueue(next, newCost);
                    cameFrom[next] = currentInSearch;
                }
            }
        }
        return new();
    }

    private static float Heuristic(PFNodes a, PFNodes b)
    {
        return Mathf.Abs(a.x - b.x) +
             Mathf.Abs(a.y - b.y);
    }

    public static List<PFNodes> GreedyBestFirst(PFNodes start, PFNodes end)
    {
        var frontier = new PriorityQueue<PFNodes>();
        frontier.Enqueue(start, 0);
        Dictionary<PFNodes, PFNodes> cameFrom = new() { { start, null } };

        while (!frontier.IsEmpty)
        {
            PFNodes currentInSearch = frontier.Dequeue();
            currentInSearch.Color = Color.gray;

            if (currentInSearch == end)
            {
                //Creación del Path
                PFNodes currentInPath = end;
                List<PFNodes> path = new();
                while (currentInPath != null) //Podemos preguntar que sea distinto de start para no agregarlo
                {
                    path.Add(currentInPath);
                    currentInPath = cameFrom[currentInPath];
                }
                path.Reverse();
                return path;
            }

            for (int i = 0; i < currentInSearch.Neighbors.Count; i++)
            {
                var next = currentInSearch.Neighbors[i];
                if (next.Blocked) continue;
                if (!cameFrom.ContainsKey(next))
                {
                    frontier.Enqueue(next, Heuristic(end, next));
                    cameFrom.Add(next, currentInSearch);
                }
            }
        }
        return new();
    }
    public static List<PFNodes> Astar(PFNodes start, PFNodes end, LayerMask mask)
    {
        var frontier = new PriorityQueue<PFNodes>();
        frontier.Enqueue(start, 0);
        Dictionary<PFNodes, float> costSoFar = new() { { start, 0 } };
        Dictionary<PFNodes, PFNodes> cameFrom = new() { { start, null } };

        while (!frontier.IsEmpty)
        {
            PFNodes currentInSearch = frontier.Dequeue();
            currentInSearch.Color = Color.Lerp(Color.yellow, Color.red, currentInSearch.Cost / 5);

            if (currentInSearch == end)
            {
                //Creación del Path
                PFNodes currentInPath = end;
                List<PFNodes> path = new();
                while (currentInPath != null) //Podemos preguntar que sea distinto de start para no agregarlo
                {
                    path.Add(currentInPath);
                    currentInPath = cameFrom[currentInPath];
                }
                path.Reverse();
                return path;
            }

            for (int i = 0; i < currentInSearch.Neighbors.Count; i++)
            {
                var next = currentInSearch.Neighbors[i];
                if (next.Blocked || !LineOfSight(currentInSearch.transform.position, next.transform.position, mask)) continue;
                float newCost = costSoFar[currentInSearch] + next.Cost;
                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;
                    frontier.Enqueue(next, newCost + Heuristic(end, next));
                    cameFrom[next] = currentInSearch;
                }
            }
        }
        return new();
    }
    
    public static bool LineOfSight(Vector3 nodeA, Vector3 nodeB, LayerMask mask)
    {
        return !Physics.Linecast(nodeA, nodeB, mask);
    }
    public static List<PFNodes> AstarPS(PFNodes start, PFNodes end, LayerMask walls)
    {
        var path = Astar(start, end, walls);
        int current = 0;
        while (current + 2 < path.Count)
        {
            Vector3 a = path[current].transform.position;
            Vector3 b = path[current + 2].transform.position;
            if (LineOfSight(a, b, walls))
                path.RemoveAt(current + 1);
            else
                current++;
        }
        return path;

    }

    public static List<PFNodes> Dijkstra(PFNodes start, Func<PFNodes, bool> Predicate, LayerMask mask)
    {
        var frontier = new PriorityQueue<PFNodes>();
        frontier.Enqueue(start, 0);
        Dictionary<PFNodes, float> costSoFar = new() { { start, 0 } };
        Dictionary<PFNodes, PFNodes> cameFrom = new() { { start, null } };

        while (!frontier.IsEmpty)
        {
            PFNodes currentInSearch = frontier.Dequeue();
            currentInSearch.Color = Color.Lerp(Color.yellow, Color.red, currentInSearch.Cost / 5);

            if (Predicate(currentInSearch))
            {
                //Creación del Path
                PFNodes currentInPath = currentInSearch;
                List<PFNodes> path = new();
                while (currentInPath != null) //Podemos preguntar que sea distinto de start para no agregarlo
                {
                    path.Add(currentInPath);
                    currentInPath = cameFrom[currentInPath];
                }
                path.Reverse();
                return path;
            }

            for (int i = 0; i < currentInSearch.Neighbors.Count; i++)
            {
                var next = currentInSearch.Neighbors[i];
                if (next.Blocked || !LineOfSight(currentInSearch.transform.position, next.transform.position, mask)) continue;
                float newCost = costSoFar[currentInSearch] + next.Cost;
                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;
                    frontier.Enqueue(next, newCost);
                    cameFrom[next] = currentInSearch;
                }
            }
        }
        return new();
    }
}
