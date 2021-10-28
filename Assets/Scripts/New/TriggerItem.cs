using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItem : MonoBehaviour
{
  public int ID;
    public ObjectPooler objectPooler;

    private void Start() {
        objectPooler = FindObjectOfType<ObjectPooler>().GetComponent<ObjectPooler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {

            GameObject.Find("KnapsackPanel").GetComponent<KnapsackPanel>().AddItem(ID);
            if (ID == 1)
            {
                Achievement.Instance.AddRedBox(1);
            }
          
            string objectName = "";

            switch(this.ID){
                case 0:
                    objectName = "Coffee";
                    break;
                case 1:
                    objectName = "Red";
                    break;
                case 2:
                    objectName = "GolfCart";
                    break;
            }
            Debug.Log(objectPooler);
            objectPooler.poolDictionary[objectName].Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
