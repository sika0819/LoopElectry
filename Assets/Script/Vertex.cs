using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex {
    private int i;//序号
    public int index {
        get {
            return i;
        }
    }
    private float electry;
    public List<ElecEdge> adj;
    public Vertex(int i) {
        this.i = i;
        adj = new List<ElecEdge>();
    }
    public void setElectry(int e) {
        electry = e;//当前点电流
    }
    public ElecEdge head {
        get {
            if (adj.Count > 0)
                return adj[0];
            else
                return null;
        }
    }
    
}
