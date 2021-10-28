using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Level : MonoBehaviour
{
    public int num;
    public new string name;
    public int levelID;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            //FindObjectOfType<Leaderboard>().IncreaseScore(100);
            Debug.Log("Building reached!");
            this.gameObject.SetActive(false);
            FindObjectOfType<LevelHandler>().OnBuildingClear(this.levelID);
            FindObjectOfType<LevelHandler>().Arrows[num].SetActive(false);
        }
    }

}
