using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    private bool hasSpawnedTile;

    private bool[,] PositionInUse = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };


    // Use this for initialization
    void Start()
    {
        hasSpawnedTile = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z < WorldScript.World.player.transform.position.z + 80 && !hasSpawnedTile)
        {
            SpawnNextTile();
        }


        if (transform.position.z < WorldScript.World.player.transform.position.z - 15)
        {
            ObjectPool.returnItem(gameObject);
        }
    }

    public void Init(Vector3 position)
    {
        transform.position = position;
        hasSpawnedTile = false;
        PositionInUse = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
        SpawnObstacle();
    }


    void SpawnNextTile()
    {
        GameObject spawnedTile = ObjectPool.GetItem(PoolTypes.GROUND);
        GroundScript script = spawnedTile.GetComponent<GroundScript>();
        script.Init(new Vector3(0, 0, transform.position.z + 10));
        spawnedTile.SetActive(true);
        hasSpawnedTile = true;
    }

    void SpawnObstacle()
    {
        if(!PositionInUse[0, 0])
        {
            GameObject SpawnedObstacle = ObjectPool.GetItem(PoolTypes.COIN);
            CoinScript script = SpawnedObstacle.GetComponent<CoinScript>();
            script.Init(transform.position + new Vector3(-2, 1, -2));
            PositionInUse[0, 0] = true;
        }

        
    }



}
