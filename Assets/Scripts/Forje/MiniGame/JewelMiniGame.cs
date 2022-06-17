using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelMiniGame : MonoBehaviour
{
    public ArrayLayout boardLayour;
    int width = 0, height = 14;

    Node[,] board;
    void Start()
    {
        
    }

    System.Random random;
    void Update()
    {
        
    }

    void StartGame()
    {
        string seed = GetRandomSeed();
        random = new System.Random(seed.GetHashCode());
        InitializeBoard();
    }

    void InitializeBoard()
    { 
        board = new Node[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                board[x, y] = new Node(-1, new Point(x,y));
            }
        }
    }
    string GetRandomSeed()
    {
        string seed = "";
        string accetableChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()";

        for (int i = 0; i < 20; i++)
        {
            seed += accetableChars[Random.Range(0, accetableChars.Length)];
        }

        return seed;
    }
}

[System.Serializable]
public class Node
{
    public int value; // 0 = star , 1 = mushroom, 2 = trebol , 3 = RedDiamond , 4 = BlueJewel, -1 = Hole
    public Point index;

    public Node(int v, Point i)
    {
        value = v;
        index = i;
    }
}
