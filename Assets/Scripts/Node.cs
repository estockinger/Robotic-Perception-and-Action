﻿using UnityEngine;
using System.Collections;
/*
public enum Direction
{
    C = 0,
    N  = 1,
    NE = 2,
    E  = 3,
    SE = 4,
    S  = 5,
    SW = 6,
    W  = 7,
    NW = 8

}*/

public class Node : IHeapItem<Node>
{

    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;
    public int movementPenalty;

    public int gCost; //distance from start
    public int hCost; //distance to target
    public Node parent;
    public Node exploredFrom;
    int heapIndex;

    public int exploredIndex;
    //    public Direction exploredFrom;

    public GameObject token;

    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY, int _penalty, GameObject _token)
    {
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
        movementPenalty = _penalty;
        exploredIndex = 0;


        _token.transform.position = _worldPos;
        _token.SetActive(false);
        token = _token;

    }

    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }

    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }
        return -compare;
    }

    public void ExploreNode()
    {
        token.SetActive(true);
        ++exploredIndex;
    }

    public void ExploreFrom(Node parent)
    {
        exploredFrom = parent;
    }

    public void Reset()
    {
        Token script = token.GetComponent<Token>();
        script.Reset();
    }

}
