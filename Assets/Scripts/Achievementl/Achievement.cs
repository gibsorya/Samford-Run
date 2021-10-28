using System.Collections.Generic;
using UnityEngine;




public class Achievement : MonoBehaviour
{
    public static Achievement Instance;

    private List<AchievementItem> achievements;

    private GameObject AchievementLabel;

    private int RedBox = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        AchievementLabel = transform.Find("Achievement").gameObject;

        achievements = new List<AchievementItem>();
        achievements.Add(new AchievementItem(0, "GetRedBox1", "To get one red box", 1, AchievementType.GetRedBox));
        achievements.Add(new AchievementItem(1, "GetRedBox2", "To get three red box", 3, AchievementType.GetRedBox));
        achievements.Add(new AchievementItem(2, "GetRedBox3", "To get five red box", 5, AchievementType.GetRedBox));
        achievements.Add(new AchievementItem(2, "ArriveScore", "Bring the score up to 50 ", 50, AchievementType.ArriveScore));
    }

    public void AddRedBox(int num)
    {
        RedBox += num;
        foreach (var item in achievements)
        {
            if (item.AchievementType == AchievementType.GetRedBox)
            {
                if (RedBox >= item.TargetNum && !item.IsComplete)
                {
                    item.IsComplete = true;
                    ShowAchievementLabal(item);
                }
            }
        }
    }


    private void ShowAchievementLabal(AchievementItem item)
    {
        GameObject label = Instantiate(AchievementLabel, transform);
        label.transform.GetComponent<AchievementLabel>().SetContent(item.Name, item.Describe);
        label.SetActive(true);
        Destroy(label, 5);
    }
}
