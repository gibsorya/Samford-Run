using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//9:50
//10:26 to add animation 

public class PuaseMenuScript : MonoBehaviour {

    public static bool GamesIsPuased = false;
    //bool means the vualue can be either true or false

    public GameObject puaseMenuUI;
    public Button pauseButton;

    // Update is called once per frame
    void Start() {
        Button btn = pauseButton.GetComponent<Button>();
        puaseMenuUI.GetComponent<Canvas>();
        btn.onClick.AddListener(isPaused);
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused();
        } 
    }

public void Resume ()
{
    puaseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GamesIsPuased = false;
//    FindObjectOfType<Player>().GetComponent<MovingScriptRigidBody>().isGamePaused = false;
    pauseButton.gameObject.SetActive(true);
    pauseButton.image.gameObject.SetActive(true);
    
}
public void Puase ()
{
        Debug.Log("Paused");
    puaseMenuUI.SetActive(true);
    pauseButton.gameObject.SetActive(false);
    pauseButton.image.gameObject.SetActive(false);
    Time.timeScale = 0f;
    //FindObjectOfType<Player>().GetComponent<MovingScriptRigidBody>().isGamePaused = true;
    GamesIsPuased = true;
}
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene("RunningSceneN");
        puaseMenuUI.SetActive(false);
    }
    public void QuitGame()
{
        Debug.Log("Quiting game...");
        Application.Quit();
    }

    public void isPaused(){
        
            if (GamesIsPuased)
            {
                Resume();
            } else
            {
                Puase();
            }
        
    }

}


