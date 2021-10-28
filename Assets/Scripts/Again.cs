using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Again : MonoBehaviour
{
    public GameObject Youwin;
    public GameObject YouLose;
    public GameObject nameInputBox;
    public int speed=6;
    public ObjectPooler ObjectPooler;
    public GameObject leaderboard;

    public bool IsInvincible;

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
            if (IsInvincible)
            {
                return;
            }
            Time.timeScale = 0;
            //nameInputBox.SetActive(true);
            YouLose.SetActive(true);
            leaderboard.gameObject.GetComponent<Leaderboard>().Restart();
            
        }
        
    }
    public void Againa()
    {

        Debug.Log("Restart button clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    
    public void QUIT()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

   

}
