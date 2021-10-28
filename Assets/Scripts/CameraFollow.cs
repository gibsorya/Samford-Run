using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 5, -5);


    
    void Start()
    {
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //Quaternion TargetBodyCurrentRotation = player.transform.rotation;

        //transform.rotation = Quaternion.Lerp(transform.rotation,TargetBodyCurrentRotation, 0.5f);


       // transform.position = player.transform.position + offset;
    }
}
