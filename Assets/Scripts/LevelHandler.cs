using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelHandler : MonoBehaviour
{
    public List<Level> levels;
    public List<Text> buildingNames;
    public GameObject levelWinUI, Player;
    private int buildingOne, buildingTwo, buildingThree, buildingsLeft = 3;
    public int score = 0;

    public List<GameObject> Arrows ;
    public GameObject leaderboard;

    private void Start()
    {
        SetUpLevel();
    }
    public void ChooseBuildingNumbers()
    {
        buildingOne = Random.Range(0, 8);

        while (true)
        {
            buildingTwo = Random.Range(0, 8);
            if (buildingTwo != buildingOne)
            {
                break;
            }
        }

        while (true)
        {
            buildingThree = Random.Range(0, 8);
            if (buildingThree != buildingOne && buildingThree != buildingTwo)
            {
                break;
            }
        }
    }

    public void SetUpLevel()
    {
        ChooseBuildingNumbers();
        levels[buildingOne].gameObject.SetActive(true);
        levels[buildingTwo].gameObject.SetActive(true);
        levels[buildingThree].gameObject.SetActive(true);

        levels[buildingOne].num = 0;
        levels[buildingTwo].num = 1;
        levels[buildingThree].num = 2;

        foreach (var item in Arrows)
        {
            item.SetActive(true);
        }


        Arrows[0].GetComponent<ArrowS>().Target = levels[buildingOne].gameObject.transform;
        Arrows[1].GetComponent<ArrowS>().Target = levels[buildingTwo].gameObject.transform;
        Arrows[2].GetComponent<ArrowS>().Target = levels[buildingThree].gameObject.transform;

        buildingNames[0].text = levels[buildingOne].name;
        buildingNames[1].text = levels[buildingTwo].name;
        buildingNames[2].text = levels[buildingThree].name;
    }

    public void OnBuildingClear(int levelID)
    {
        if(levelID != buildingOne && levelID != buildingTwo && levelID != buildingThree)
        {
            Debug.LogError("Building is not active!");
            return;
        }
        
        if(levelID == buildingOne)
        {
            buildingNames[0].color = new Color(0f, 1f, 0f);
            leaderboard.GetComponent<Leaderboard>().IncreaseScore(100);
            //score +=100;
        } else if (levelID == buildingTwo)
        {
            buildingNames[1].color = new Color(0f, 1f, 0f);
            leaderboard.GetComponent<Leaderboard>().IncreaseScore(100);
            
           /// score+=100;
        } else if (levelID == buildingThree)
        {
            buildingNames[2].color = new Color(0f, 1f, 0f);
            leaderboard.GetComponent<Leaderboard>().IncreaseScore(100);
            
            //score += 100;
        }

        buildingsLeft--;
        if(buildingsLeft == 0)
        {
            OnLevelCompletion();
        }
    }

    public void OnLevelCompletion()
    {
        buildingNames[0].color = new Color(1f, 0f, 0f);
        buildingNames[1].color = new Color(1f, 0f, 0f);
        buildingNames[2].color = new Color(1f, 0f, 0f);
        levelWinUI.SetActive(true);
        Player.GetComponent<Again>().IsInvincible = true;
        buildingsLeft = 3;
        
    }

    public void OnNextLevelButtonClicked()
    {
        SetUpLevel();
        levelWinUI.SetActive(false);
        Player.GetComponent<Again>().IsInvincible = false;
    }


}
