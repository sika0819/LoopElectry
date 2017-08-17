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

    public DirectGraph()
    {
        edgeCount = 0;
        vertexArray = new List<Vertex>();
    }
    public void addVertex(Vertex vertex) {
        vertexArray.Add(vertex);
    }
    public void addEdge(ElecEdge e)
    {
        vertexArray[e.getFrom().index].adj.Add(e);
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
        if (index >= 0 && index < vertexArray.Count)
            return vertexArray[index];
        else
            return null;
    }
    public List<ElecEdge> getAdj(int v)
    {
        return vertexArray[v].adj;
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
}
