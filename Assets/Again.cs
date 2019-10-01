using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Again : MonoBehaviour
{
    //脚本挂在主角身上（主角身上要有碰撞器和刚体，不需要勾选is Trigger）
    //将障碍物的tag改成cube，加上碰撞器，勾上 is Trigger
    public GameObject Youwin;
    public GameObject YouLose;
    public int speed = 6;

    [SerializeField]
     float currtime = 0;
    [SerializeField]
    float time = 0;

    public bool isAddSpeed = false ;
    private Animator Ani;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        Ani= gameObject.GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {

        if (isAddSpeed)
        {
            
            currtime += Time.deltaTime;
            if (currtime>=time)
            {
                speed = 6;
                isAddSpeed = false;
                currtime = 0;
            }
        }

        //控制小车移动（测试用）
        if (Input.GetKey(KeyCode.W))
        {
           
            gameObject.transform.Translate(Vector3.forward* Time.deltaTime* speed, Space.Self) ;
            
            Ani.SetBool("walk", true);
            
        }
        if (Input.GetKeyUp(KeyCode.W))
            {
                Ani.SetBool("walk", false);
            }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(Vector3.back * Time.deltaTime* speed, Space.Self);
            Ani.SetBool("back", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Ani.SetBool("back", false);
        }
        //if (Input.GetKey(KeyCode.A))
        //{
        //    gameObject.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.Self);
        //    Ani.SetBool("walk", true);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    gameObject.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.Self);
        //    Ani.SetBool("walk", true);
        //}


    }
    private void OnTriggerEnter(Collider other)
    {  
        //如果挂有当前脚本的物体碰到tag为cube的物体就执行下面代码
        if (other.gameObject.tag=="win")
        {
  
            Time.timeScale = 0;
            Youwin.SetActive(true);
        }
        if (other.gameObject.tag == "Lose")
        {
            Time.timeScale = 0;
            YouLose.SetActive(true);
        }
    }
    public void Againa()
    {
        Application.LoadLevel(Application.loadedLevelName);//加载当前场景
    }
    
    public void QUIT()
    {
        Application.Quit();
    }

    public void SetSpeed(int Addspeed,float timer)
    {
        isAddSpeed = true;
        speed = 12;
        time = timer;
    }

}
