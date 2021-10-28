using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{

    public GameObject SelectLevel;

    public Button StartBtn;

    public Button Level1;

    public Button Level2;

    public Button Level3;

    private NPCSpawner nacSpawner;

    public void Start()
    {
        Time.timeScale = 0;


        nacSpawner = GameObject.FindObjectOfType<NPCSpawner>();


        StartBtn.onClick.AddListener((() =>
        {
            StartBtn.gameObject.SetActive(false);
            SelectLevel.SetActive(true);
        }));
        Level1.onClick.AddListener((() =>
        {
            SetTIme(6);
        }));
        Level2.onClick.AddListener((() =>
        {
            SetTIme(3);
        }));
        Level3.onClick.AddListener((() =>
        {
            SetTIme(1);
        }));

}

    public void SetTIme(float time)
    {
        nacSpawner.timer = time;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
