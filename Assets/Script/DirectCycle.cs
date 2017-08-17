using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DirectCycle {
    private bool[] inStack;
    private List<Stack<Vertex>> cycleList;//电流环
    private int[] edgeTo;
    private bool[] isMarked;
    int[] color;//黑白灰找环
    public DirectCycle(DirectGraph g)
    {
        inStack = new bool[g.getVertexCount()];
        edgeTo = new int[g.getVertexCount()];
        isMarked = new bool[g.getVertexCount()];
        color = new int[g.getVertexCount()];
        cycleList = new List<Stack<Vertex>>();
        for (int i = 0; i < g.getVertexCount(); i++)
        {
            if (color[i] == 0)
            {
                color[i] = -1;
                dfs(g, i);
            }
        }
    }

    private void dfs(DirectGraph g, int begin)
    {
        isMarked[begin] = true;
        inStack[begin] = true;
        foreach (ElecEdge e in g.getAdj(begin))
        {
            int node = e.getTo().index;
            //if (hasCycle()) return;

            if (color[node] == 0)
            {
                color[node] = -1;
                edgeTo[node] = begin;
                dfs(g, node);
            }
            else if (color[node] == -1)
            { // 如果当前路径Stack中含有node，又再次访问的话，说明有环  
              // 将环保存下来  
                Stack<Vertex> cycle = new Stack<Vertex>();
                for (int i = begin; i != node; i = edgeTo[i])
                {
                    cycle.Push(g.getVertex(i));
                    Debug.Log("访问环点：" + i + " ");
                }
                Debug.Log("访问环点：" + node + " ");
                cycle.Push(g.getVertex(node));
                cycleList.Add(cycle);
            }
        }
        color[begin] = 1;
        Debug.Log(begin + "节点不在当前路径了");
        inStack[begin] = false;
    }


    public bool hasCycle()
    {
        return cycleList.Count>0;
    }

    public string toString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("有" + cycleList.Count + "个环，分别为：\n");
        for (int i = 0; i < cycleList.Count; i++)
        {
            for (int j = cycleList[i].Count-1; j >=0 ; j--)
            {
                sb.Append(cycleList[i].Pop().index + "————>");
            }
            sb.Append("\n");
        }

        return sb.ToString();
    }
    /// <summary>
    /// 并联设计思路：
    /// 找出所有连接电池的环
    /// 找到环的公共节点。
    /// 把公共节点的
    /// 
    /// </summary>
    /// <param name="g"></param>
    /// <param name="battery"></param>
    public void Generation(DirectGraph g, Vertex battery)
    {//计算电路，为了方便直接给出电池在哪.为了方便暂定电池只有一个
        if (CheckLinked(battery))
        {
           
            if (cycleList.Count == 1)
            {//串联
                Debug.Log("电路为串联");
                
            }
            else
            {
                Debug.Log("并联，算法测试中……可能有bug");
                
            }
        }
    }
    public void SetEle(DirectGraph g, Stack<Vertex> cycle, float electry)
    {//每圈分别设置电压，电流
        
    }
    bool CheckLinked(Vertex battery)
    {//检测断路
        if (cycleList.Count > 0)
        {
            for (int i = 0; i < cycleList.Count; i++)
            {
                if (CheckBattery(cycleList[i], battery))
                    return true;
            }
        }
        Debug.Log("断路！请链接电池！");
        return false;
    }
    bool CheckBattery(Stack<Vertex> ring, Vertex battery)
    {
        return ring.Contains(battery);
    }

    public float AllResistance;//总电阻
    public float Voltage;//总电压
    public float Eletry;//总电流

}
