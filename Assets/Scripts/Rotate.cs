using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public Transform Pos;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.RotateAround(Pos.position, 90);
        }
    }
}
