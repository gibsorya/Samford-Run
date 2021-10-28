using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreSlot : MonoBehaviour
{
    public ScoreEntry slot;
    
    public void updateInfo()
    {
       // Image leaderStar = transform.Find("trophy").GetComponent<Image>();
        Text posText = transform.Find("posText").GetComponent<Text>();
        Text scoreText = transform.Find("scoreText").GetComponent<Text>();
        Text nameText = transform.Find("nameText").GetComponent<Text>();
        if (slot)
        {
            posText.text = slot.position.ToString();
            scoreText.text = slot.score.ToString();
            nameText.text = slot.name;
        } else
        {
            posText.text = "";
            scoreText.text = "";
            nameText.text = "";
        }
    }
   
}