using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NodeState
{
    Aviable,
    Current,
    Completed
}
public class MazeNode : MonoBehaviour
{
    public GameObject[] Walls;

    public void RemoveWall(int wallToRemove)
    {
        Walls[wallToRemove].gameObject.SetActive(false);
    }
}
