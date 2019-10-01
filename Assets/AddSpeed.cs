using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    [Tooltip("加速度")]
    public int JiaSpeed = 0;
    [Tooltip("加速持续时间")]
    public float Time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            collision.gameObject.GetComponent<Again>().SetSpeed(JiaSpeed, Time);
            Destroy(this.gameObject);
        }
    }
}
