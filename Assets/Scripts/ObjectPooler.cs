using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour { 

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Animator animator;

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    // Start is called before the first frame update

    private void Start()
    {
        OnLevelStart();
    }
    public void OnLevelStart()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.SetParent(this.gameObject.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    private float currtime;

    [SerializeField]
    private float timer;

    public GameObject spawnFromPool(string tag, Vector3 position, Quaternion rotation, int direction)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        if (tag.Equals("NPC"))
        {
            animator = objectToSpawn.GetComponent<Animator>();
        }
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        if (tag.Equals("NPC"))
        {
            animator.SetFloat("moving", 0.2f);
        }
        

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if(pooledObj != null)
        {
            objectToSpawn.GetComponent<NPC>().direction = direction;
            pooledObj.OnObjectSpawn();
        }
        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
    
    IEnumerator NPCWave(GameObject objectToSpawn)
    {
        Debug.Log("Timer started");
         yield return new WaitForSecondsRealtime(5);
        /*I had this code in here:
         *  poolDictionary[tag].Enqueue(objectToSpawn); 
         */
        Debug.Log("Timer ended");
        
    }
}
