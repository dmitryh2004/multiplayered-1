using System;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] int squaresToRemove = 4;
    List<GameObject> squares = new();
    System.Random rand = new();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            squares.Add(transform.GetChild(i).gameObject);
        }
    }
    public void RemoveRandomSquares()
    {
        List<int> indexes = new();
        for (int i = 0; i < squaresToRemove; i++)
        {
            if (indexes.Count == squares.Count) break;
            int index = rand.Next(0, squares.Count);
            while (indexes.Contains(index))
            {
                index = (index + 1) % squares.Count;
            }
            indexes.Add(index);
        }

        foreach(int i in indexes)
        {
            squares[i].SetActive(false);
        }
    }
}
