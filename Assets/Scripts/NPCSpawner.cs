using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    [SerializeField]
    private float respawnTime = 5.0f;

    [SerializeField]
    private Vector3 npcSpawnPoint, playerPos;

    public int direction = 0;

    public bool isNPCSpawner = true, isGolfCartMode = true;

    public float timer = 2;

    [SerializeField]
    private BoxCollider spawnBounds;

    // Start is called before the first frame update
    public void Start()
    {
        playerPos = transform.position;
        objectPooler = ObjectPooler.Instance;

        if (isNPCSpawner)
        {
            InvokeRepeating("spawnNPC", 1, timer);
        }
        else
        {
            Invoke("spawnPowerUps", 2);
        }


    }

    void spawnNPC()
    {
        
        playerPos = transform.position;
        Vector3 npcSpawnPoint;
        
        if (direction == 0)
        {
             npcSpawnPoint = new Vector3(playerPos.x + Random.Range(-4, 4), 0.5f, playerPos.z - 40);
        }
        else 
        {
             npcSpawnPoint = new Vector3(playerPos.x - 40, 1f, playerPos.z + Random.Range(-4, 4));
        }
        if (spawnBounds.bounds.Contains(npcSpawnPoint))
        {
            objectPooler.spawnFromPool("NPC", npcSpawnPoint, Quaternion.identity, direction);
        }
            

    }

#region Power Up Methods
    void spawnPowerUps()
    {
        InvokeRepeating("spawnCoffee", 1, timer + 2);
        InvokeRepeating("spawnRed", 3, timer + 4);
        if (!isGolfCartMode)
        {
        InvokeRepeating("spawnGolfCart", 5, timer + 6);

        }
    }

    void spawnCoffee(){
        playerPos = transform.position;
        Vector3 npcSpawnPoint = new Vector3(playerPos.x + Random.Range(-100, 100), 1f, playerPos.z + Random.Range(-100, 100));
        if (spawnBounds.bounds.Contains(npcSpawnPoint))
        {
        objectPooler.spawnFromPool("Coffee", npcSpawnPoint, Quaternion.identity, direction);
        }
    }

    void spawnRed(){
        playerPos = transform.position;
        Vector3 npcSpawnPoint = new Vector3(playerPos.x + Random.Range(-100, 100), 1f, playerPos.z + Random.Range(-100, 100));
        if (spawnBounds.bounds.Contains(npcSpawnPoint))
        {
        objectPooler.spawnFromPool("Red", npcSpawnPoint, Quaternion.identity, direction);
        }
    }

    void spawnGolfCart(){
        playerPos = transform.position;
        Vector3 npcSpawnPoint = new Vector3(playerPos.x + Random.Range(-100, 100), 1f, playerPos.z + Random.Range(-100, 100));
        if (spawnBounds.bounds.Contains(npcSpawnPoint))
        {
        objectPooler.spawnFromPool("GolfCart", npcSpawnPoint, Quaternion.identity, direction);
        }
    }
    
#endregion

}
