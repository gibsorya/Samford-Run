﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    // Start is called before the first frame update
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectPooler.spawnFromPool("Cube", transform.position, Quaternion.identity, 0);
    }
}
