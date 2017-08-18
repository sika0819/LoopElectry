using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DirectedDFS
{
    private bool[] marked;  // marked[v] = true if v is reachable
                               // from source (or sources)
    private int count;         // number of vertices reachable from s
    public DirectedDFS(DirectGraph G, int s)
    {
        marked = new bool[G.getVertexCount()];
        dfs(G, s);
    }
    public DirectedDFS(DirectGraph G, List<int> sources)
    {
        marked = new bool[G.getVertexCount()];
        for (int v=0; v< sources.Count;v++)
        {
            if (!marked[v])
                dfs(G, v);
        }
    }
    private void dfs(DirectGraph G, int v)
    {
        count++;
        marked[v] = true;
        for (int w =0;w< G.getAdj(v).Count;w++)
        {
            if (!marked[w])
                dfs(G, w);
        }
    }
    public bool getMarked(int v)
    {
        return marked[v];
    }
    public int getCount()
    {
        return count;
    }
}
