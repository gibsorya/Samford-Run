using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementLabel : MonoBehaviour
{
    public Text Name;
    public Text Describe;

    private void Awake()
    {
        Name = transform.Find("NameText").GetComponent<Text>();
        Describe = transform.Find("DescribeText").GetComponent<Text>();
    }

    public void SetContent(string name,string describe)
    {
        Name.text = name;
        Describe.text = describe;
    }

}
