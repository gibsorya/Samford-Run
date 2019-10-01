using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    [SerializeField]
    private Button button;

    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void TaskOnClick()
    {
        Debug.Log("You have clicked the button");
    }

    public void Quit()
    {
        Debug.Log("Quit game!");
        Application.Quit();
    }

    
}
