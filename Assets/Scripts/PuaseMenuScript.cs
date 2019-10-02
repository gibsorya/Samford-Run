using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//9:50
//10:26 to add animation 

public class PuaseMenuScript : MonoBehaviour {

    public static bool GamesIsPuased = false;
    //bool means the vualue can be either true or false

    public GameObject puaseMenuUI;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {

            if (GamesIsPuased)
            {
                Resume();
            } else
            {
                Puase();
            }
          }
        }

public void Resume ()
{
    puaseMenuUI.SetActive(false);
    Time.timeScale = 1f;
    GamesIsPuased = false;
}
    void Puase ()
{
    puaseMenuUI.SetActive(true);
    Time.timeScale = 0f;
    GamesIsPuased = true;
}
    public void LoadMenu()
{
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
}
    public void QuitGame()
{
        Debug.Log("Quiting game...");
        Application.Quit();
    }

}


