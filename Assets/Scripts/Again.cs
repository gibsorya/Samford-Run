using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Again : MonoBehaviour
{
    public GameObject Youwin;
    public GameObject YouLose;
    public int speed=6;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    private void OnTriggerEnter(Collider other)
    {  
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
        Debug.Log("Restart button clicked");
        SceneManager.LoadScene("RunningScene");

    }
    
    public void QUIT()
    {
        Application.Quit();
    }

}
