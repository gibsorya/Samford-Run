using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IPooledObject
{
    public float sideForce;
    public float direction;
    [SerializeField]
    private BoxCollider spawnBounds;
    Animator animator;

    public void OnObjectSpawn()
    {
        spawnBounds = GameObject.Find("Spawn Boundaries").GetComponent<BoxCollider>();
        animator = this.gameObject.GetComponent<Animator>();
        float zForce = Random.Range(-sideForce + (sideForce/2), sideForce);
        Vector3 force;
        if (direction == 0)
        {
            force = new Vector3(0, 0, zForce);
        } else
        {
            force = new Vector3(zForce, 0, 0);
        }

        GetComponent<Rigidbody>().velocity = force;


    }

    private void Update()
    {
        animator.SetFloat("moving", 0.2f);
        if (!spawnBounds.bounds.Contains(this.gameObject.transform.position))
        {
            this.gameObject.SetActive(false);
        }
    }
    public enum Direction
    {
        Forward,
        Back,
        Right,
        Left
    }
    [HideInInspector]
    public bool isFB = true;

    private Direction dir;

    private float Speed = 5;

    
}
