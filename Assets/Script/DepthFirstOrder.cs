using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthFirstOrder  {

    private bool[] marked;          // marked[v] = has v been marked in dfs?
    private int[] pre;                 // pre[v]    = preorder  number of v
    private int[] post;                // post[v]   = postorder number of v
    private Queue<int> preorder;   // vertices in preorder
    private Queue<int> postorder;  // vertices in postorder
    private int preCounter;            // counter or preorder numbering
    private int postCounter;           // counter for postorder numbering
    public DepthFirstOrder(DirectGraph G)
    {
        pre = new int[G.getVertexCount()];
        post = new int[G.getVertexCount()];
        postorder = new Queue<int>();
        preorder = new Queue<int>();
        marked = new bool[G.getVertexCount()];
        for (int v = 0; v < G.getVertexCount(); v++)
            if (!marked[v]) dfs(G, v);
    }


    // run DFS in digraph G from vertex v and compute preorder/postorder
    private void dfs(DirectGraph G, int v)
    {
        marked[v] = true;
        pre[v] = preCounter++;
        preorder.Enqueue(v);
        for (int w =0;v< G.getAdj(v).Count;v++)
        {
            if (!marked[w])
            {
                dfs(G, w);
            }
        }
        postorder.Enqueue(v);
        post[v] = postCounter++;
    }
   
    public int getPre(int v)
    {
        return pre[v];
    }
    public int getPost(int v)
    {
        return post[v];
    }
    public Queue<int> getPostList()
    {
        return postorder;
    }
    public Queue<int> getPreList()
    {
        return preorder;
    }
    public Stack<int> reversePost()
    {
        Stack<int> reverse = new Stack<int>();
        for (int v=0;v< postorder.Count;v++)
            reverse.Push(v);
        return reverse;
    }
    // check that pre() and post() are consistent with pre(v) and post(v)
    private bool check(DirectGraph G)
    {
        // check that post(v) is consistent with post()
        int r = 0;
        foreach (var v in getPostList()) {
            if (getPost(v) != r)
            {
                Debug.Log("post(v) and post() inconsistent");
                return false;
            }
            r++;
        }
        // check that pre(v) is consistent with pre()
        r = 0;
        foreach (var v in getPreList())
        {
            if (getPre(v) != r)
            {
                Debug.Log("pre(v) and pre() inconsistent");
                return false;
            }
            r++;
        }
        return true;
    }
}
