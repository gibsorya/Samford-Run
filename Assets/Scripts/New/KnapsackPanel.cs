using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public int ID;
    public Sprite Icon;

    public Item(int ID, Sprite Icon)
    {
        this.ID = ID;
        this.Icon = Icon;
    }
}

public class KnapsackPanel : MonoBehaviour
{
    private List<int> PlayerItemList;

    private List<Item> AllItemList;

    public List<Image> ItemSprite;

    private int MaxItem;

    public Sprite Coffee;
    public Sprite SpeedCut;
    public Sprite Car;

    public MovingScriptRigidBody MovingScriptRigidBody;

    private float Timer;

    public Text TimerText;

    private void Start()
    {
        PlayerItemList = new List<int>();
        AllItemList = new List<Item>();
        AllItemList.Add(new Item(0, Coffee));
        AllItemList.Add(new Item(1, SpeedCut));
        AllItemList.Add(new Item(2, Car));
    }
    private void Update()
    {
        if (Timer>=0)
        {
            Timer -= Time.deltaTime;
            TimerText.text = Timer.ToString("f1");
            if (Timer<=0)
            {
                TimerText.text = "";
                MovingScriptRigidBody.NotInvincible();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (PlayerItemList.Count<=0)
            {
                return;
            }
            int id = PlayerItemList[0];
            switch (id)
            {
                case 0:
                    MovingScriptRigidBody.SetSpeed(20, 3);
                    break;
                case 1:
                    MovingScriptRigidBody.SetSpeed(-20, 3);
                    break;
                case 2:
                    MovingScriptRigidBody.Invincible();
                    Timer = 10;
                    break;
            }
            PlayerItemList.Remove(id);
            UpdateItem();
            
        }
    }

    public void AddItem(int ID)
    {
        if (PlayerItemList.Count>=3)
        {
            return;
        }
        PlayerItemList.Add(ID);
        UpdateItem();
    }

    public void Remove(int ID)
    {
        if (PlayerItemList.Contains(ID))
        {
            PlayerItemList.Remove(ID);
        }
        UpdateItem();
    }

    private Item GetItemInfoByID (int id)
    {
        foreach (var item in AllItemList)
        {
            if (item.ID == id)
            {
                return item;
            }
        }
        return null;
    }

    private void UpdateItem()
    {
        for (int i = 0; i < PlayerItemList.Count; i++)
        {
            ItemSprite[i].sprite = GetItemInfoByID(PlayerItemList[i]).Icon;
            ItemSprite[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < 3-PlayerItemList.Count; i++)
        {
            ItemSprite[2-i].gameObject.SetActive(false);
        }
    }
    
}
