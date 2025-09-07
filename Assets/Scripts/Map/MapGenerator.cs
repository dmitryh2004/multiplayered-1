using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] Transform obstacleParent;
    List<ObstacleController> obstacles = new();

    private void Awake()
    {
        for (int i = 0; i < obstacleParent.childCount; i++)
        {
            obstacles.Add(obstacleParent.GetChild(i).GetComponent<ObstacleController>());
        }
    }
    private void Start()
    {
        foreach(var obstacle in obstacles)
        {
            obstacle.RemoveRandomSquares();
        }
    }
}
