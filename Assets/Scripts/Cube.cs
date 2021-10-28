using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public enum Direction
    {
        Forward,
        Back,
        Right,
        Left
    }
    public bool isFB;
   
    private Direction dir;

    private float Speed = 5;
    
    void Start()
    {

        int numDir = 0;
        if (isFB)
        {
            numDir = UnityEngine.Random.Range(0, 2);
        }
        else
        {
            numDir = UnityEngine.Random.Range(2, 4);
        }
        dir = (Direction)(numDir);


    }

    
    void Update()
    {
        switch (dir)
        {
            case Direction.Forward:
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
                break;
            case Direction.Back:
                transform.Translate(Vector3.back * Time.deltaTime * Speed);
                break;
            case Direction.Right:
                transform.Translate(Vector3.right * Time.deltaTime * Speed);
                break;
            case Direction.Left:
                transform.Translate(Vector3.left * Time.deltaTime * Speed);
                break;
        }
    }
}
