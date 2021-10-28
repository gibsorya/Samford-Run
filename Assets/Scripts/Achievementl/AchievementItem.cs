using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AchievementType
{
    GetRedBox,
    ArriveScore
}

public class AchievementItem 
{
   
    public int ID;
    public string Name;
    public string Describe;
    public AchievementType AchievementType;
    public int TargetNum;
    public bool IsComplete;

    public AchievementItem()
    {

    }

    public AchievementItem(int ID,string Name,string Describe,int TargetNum,AchievementType AchievementType)
    {
        this.ID = ID;
        this.Name = Name;
        this.Describe = Describe;
        this.TargetNum = TargetNum;
        this.AchievementType = AchievementType;
    }
}
