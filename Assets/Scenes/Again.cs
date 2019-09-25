using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Again : MonoBehaviour
{
    //脚本挂在主角身上（主角身上要有碰撞器和刚体，不需要勾选is Trigger）
    //将障碍物的tag改成cube，加上碰撞器，勾上 is Trigger

    void Start()
    {
        
    }

    // Update is called once per frame
   
    private void OnTriggerEnter(Collider other)
    {  
        //如果挂有当前脚本的物体碰到tag为cube的物体就执行下面代码
        if (other.gameObject.tag=="cube")
        {
            //GetScene();
            Application.LoadLevel(Application.loadedLevelName);//加载当前场景
          


        }
    }


}
