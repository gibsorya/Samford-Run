using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    [Tooltip("加速度")]
    public int speed = 0;
    [Tooltip("加速持续时间")]
    public float Time = 0;

    

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        other.gameObject.GetComponent<MovingScriptRigidBody>().SetSpeed(speed, Time);
    //        Destroy(this.gameObject);
    //    }
    //}


}