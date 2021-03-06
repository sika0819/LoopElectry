﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int vertxCount = 4;
        DirectGraph g = new DirectGraph();
        LineGraph dianlutu = new LineGraph();
        Vertex[] vertexArray=new Vertex[vertxCount];
        for (int v = 0; v < vertxCount; v++)
        {
            Vertex vertex = new Vertex(v);
            vertexArray[v] = vertex;
            g.addVertex(vertex);
            Node node = new Node(v);
            dianlutu.addVertex(node);
        }
        g.addEdge(0, 1);
        g.addEdge(0, 2);
        g.addEdge(1, 3);
        g.addEdge(2, 3);
        g.addEdge(3, 0);
        CycleCheck c = new CycleCheck(g);

        Debug.Log("有"+c.getCount()+"个环");
        Debug.Log(g.toString());
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
