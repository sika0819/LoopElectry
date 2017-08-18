using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleCheck {
    private bool[] marked;     // marked[v] = has vertex v been visited?
    private int[] id;             // id[v] = id of strong component containing v
    private int count;            // number of strongly-connected components
    public CycleCheck(DirectGraph G)
    {
        // compute reverse postorder of reverse graph
        DepthFirstOrder firstOrder = new DepthFirstOrder(G.reverse());
        // run DFS on G, using reverse postorder to guide calculation
        marked = new bool[G.getVertexCount()];
        id = new int[G.getVertexCount()];
        for (int v=0;v< firstOrder.reversePost().Count;v++)
        {
            if (!marked[v])
            {
                dfs(G, v);
                count++;
            }
        }
        // check that id[] gives strong components
        check(G);
    }
    // DFS on graph G
    private void dfs(DirectGraph G, int v)
    {
        marked[v] = true;
        id[v] = count;
        for (int w=0;w< G.getAdj(v).Count;w++)
        {
            if (!marked[w])
                dfs(G, w);
        }
    }
    public int getCount()
    {
        return count;
    }
    public bool stronglyConnected(int v, int w)
    {
        return id[v] == id[w];
    }
    public int getId(int v)
    {
        return id[v];
    }
    // does the id[] array contain the strongly connected components?
    private bool check(DirectGraph G)
    {
        TransitiveClosure tc = new TransitiveClosure(G);
        for (int v = 0; v < G.getVertexCount(); v++)
        {
            for (int w = 0; w < G.getVertexCount(); w++)
            {
                if (stronglyConnected(v, w) != (tc.reachable(v, w) && tc.reachable(w, v)))
                    return false;
            }
        }
        return true;
    }
}