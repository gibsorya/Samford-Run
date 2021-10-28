using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Leaderboard : MonoBehaviour
{
    public List<ScoreEntry> scoreList = new List<ScoreEntry>();
    public GameObject GamePanel;
    public static Leaderboard instance;
    // Start is called before the first frame update
    void Start()
    {

        updateSlots();
       // SortSlots();
        //UpdatePostion();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void updateSlots()
    {
        SortSlots();
        UpdatePostion();
        print(scoreList.Count);
        int index = 0;
        foreach(Transform child in GamePanel.transform)
        {
            ScoreSlot Entry = child.GetComponent<ScoreSlot>();
            if (index < scoreList.Count)
            {
                Entry.slot = scoreList[index];
            } else
            {
                Entry.slot = null;
            }
            Entry.updateInfo();
            index++;
        }
    }

    public void SortSlots()
    {
        scoreList = scoreList.OrderByDescending(p => p.score).ToList();
           
        // updateSlots();
        //UpdatePostion();
    }
    public void UpdatePostion()
    {
        int index = 0;
        foreach (Transform child in GamePanel.transform)
        {
            ScoreSlot Entry = child.GetComponent<ScoreSlot>();
            if (index < scoreList.Count)
            {
                Entry.slot.position = index + 1;
            }
            index++;
        }
     //   updateSlots();
}

    public void add(ScoreEntry score)
    {
        if(scoreList.Count <10)
        {
            scoreList.Add(score);
        }
    }
    public void IncreaseScore(int Inputscore)
    {
        int index = 0;
        foreach (Transform child in GamePanel.transform)
        {
            ScoreSlot Entry = child.GetComponent<ScoreSlot>();
            if (index < scoreList.Count)
            {
                if(Entry.slot.Active==true)
                {
                    Entry.slot.score = Entry.slot.score + Inputscore;
                }
            }
            index++;
        }
        SortSlots();
        UpdatePostion();
        updateSlots();
    }
    public void Reset()
    {
        int index = 0;
        foreach (Transform child in GamePanel.transform)
        {
            ScoreSlot Entry = child.GetComponent<ScoreSlot>();
            if (index < scoreList.Count)
            {
                Entry.slot.score = 0;
            }
            index++;
        }
        counter = 0;
    }
    private int counter = 0;
    public void Restart()
    {
        int index = 0;
        foreach (Transform child in GamePanel.transform)
        {
            ScoreSlot Entry = child.GetComponent<ScoreSlot>();
            if (index < scoreList.Count)
            {
                if (Entry.slot.Active == true)
                {
                    if(index==9)  //At 9 stops with 2 left - May need to be adjusted. At index 7 stops at 7
                    {
                        index = 0;
                    }
                    print(index);
                    Entry.slot.Active = false;
                    scoreList[index + 1].Active = true;
                    SortSlots();
                    UpdatePostion();
                    updateSlots();

                    return;
                }
                index++;
            }
        }
        SortSlots();
        UpdatePostion();
        updateSlots();
        
    }

}
