using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectGraph {//电流图
    private List<Vertex> vertexArray;//顶点表
    private int vertexCount {
        get {
            return vertexArray.Count;
        }
    }
    private int edgeCount; // 边的数目  
    private List<int> indegree;//入度
    public DirectGraph()
    {
        edgeCount = 0;
        vertexArray = new List<Vertex>();
        indegree = new List<int>();
    }
    public DirectGraph(int v) {
        vertexArray = new List<Vertex>();
        indegree = new List<int>();
        for (int i = 0; i < v; i++)
        {
            Vertex vertex = new Vertex(i);
            vertexArray.Add(vertex);
        }
    }
    public void addVertex(Vertex vertex) {
        vertexArray.Add(vertex);
        indegree.Add(0);
    }
    public void addEdge(ElecEdge e)
    {
        vertexArray[e.getFrom().index].adj.Add(e);
        indegree[e.getTo().index]++;
        edgeCount++;
    }

    public void addEdge(int from, int to) {
        ElecEdge e = new ElecEdge(vertexArray[from], vertexArray[to]);
        addEdge(e);
    }
    public int getVertexCount()
    {
        return vertexCount;
    }

    public int getEdgeCount()
    {
        return edgeCount;
    }
    public Vertex getVertex(int index) {
        if (index >= 0 && index < vertexArray.Count&&vertexArray!=null)
            return vertexArray[index];
        else
            throw new KeyNotFoundException("vertex " + index + " is not between 0 and " + (vertexCount - 1));
    }
    public List<ElecEdge> getAdj(int v)
    {
        return vertexArray[v].adj;
    }
    public int outdegree(int v)
    {
        getVertex(v);
        return getAdj(v).Count;
    }
    public List<ElecEdge> edges()
    {
        List<ElecEdge> edges = new List<ElecEdge>();
        for (int i = 0; i < vertexCount; i++)
        {
            foreach (ElecEdge e in vertexArray[i].adj)
            {
                edges.Add(e);
            }
        }
        return edges;
    }

    public string toString()
    {
        string s = vertexCount + " 个顶点, " + edgeCount + " 条边\n";
        for (int i = 0; i < vertexCount; i++)
        {
            s += i + ": ";
            for (int j = 0; j < vertexArray[i].adj.Count; j++)
            {
                ElecEdge e = vertexArray[i].adj[j];
                s += "顶点："+e.getTo().index + " 电阻[" + e.Resistance + "],电压["+e.Voltage+"] ";
            }
            s += "\n";
        }
        return s;
    }
    public DirectGraph reverse()
    {
        DirectGraph R = new DirectGraph();
        for (int v = 0; v < vertexCount; v++)
        {
            for (int w=0;w< getAdj(v).Count;v++)
            {
                R.addEdge(w, v);
            }
        }
        return R;
    }
}
