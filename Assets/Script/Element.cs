using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element{//电子元器件基类
    private ElecEdge electryElement;
    private Vertex pos;//正极点
    private Vertex negative;//负极点
    public Element(float resistance)
    {
        pos = new Vertex(GenrateIndex.Index);
        negative = new Vertex(GenrateIndex.Index);
        electryElement = new ElecEdge(pos, negative);//从正极到负极建立一个有向边
        electryElement.Resistance = resistance;
    }
    public ElecEdge ElectryElement{//返回元器件
        get {
            return electryElement;
        }
    }
}
