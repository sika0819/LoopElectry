using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitiveClosure  {
    private DirectedDFS[] tc;  // tc[v] = reachable from v
    public TransitiveClosure(DirectGraph G)
    {
        tc = new DirectedDFS[G.getVertexCount()];
        for (int v = 0; v < G.getVertexCount(); v++)
            tc[v] = new DirectedDFS(G, v);
    }
    public bool reachable(int v, int w)
    {
        return tc[v].getMarked(w);
    }
}
