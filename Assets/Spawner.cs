using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    List<GameObject> pool = new List<GameObject>();
    List<GameObject> inPlay = new List<GameObject>();
    private int maxSpawn = 10;
    private float despawnXPos;
    private float spawnTimer = 0f;
    private float minSpawnInterval = 1f;
    private float maxSpawnInterval = 5f;
    private float spawnInterval = 0f;

    private void Start()
    {
        ResetSpawnInterval();

        despawnXPos = transform.position.x - 21f;

        for (int i = 0; i < maxSpawn; i++)
        {
            Vector2 spawnPos = new Vector2(despawnXPos, transform.position.y);
            pool.Add(Instantiate(prefab, spawnPos, Quaternion.identity, transform));
        }
    }

    private void ResetSpawnInterval()
    {
        spawnInterval = UnityEngine.Random.Range(minSpawnInterval, maxSpawnInterval);
    }

    private void Update()
    {
        if (GameManager.Instance.state == State.PLAYING)
        {
            MoveItemsInPlay();
            SpawnTimer();
        }

    }

    private void SpawnTimer()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnInterval)
        {
            if (pool.Count > 0)
            {
                Spawn();
            }

            spawnTimer = 0f;
            ResetSpawnInterval();
        }

    }

    private void MoveItemsInPlay()
    {
        List<int> planToRemoveAt = new List<int>();
        for (int i = 0; i < inPlay.Count; i++)
        {
            inPlay[i].transform.position = new Vector2(inPlay[i].transform.position.x - GameManager.Instance.GetScrollSpeed() * Time.deltaTime, inPlay[i].transform.position.y);
            if (inPlay[i].transform.position.x < despawnXPos)
            {
                planToRemoveAt.Add(i);
            }
        }
        for (int i = 0; i < planToRemoveAt.Count; i++)
        {
            GameObject toRecycle = inPlay[i];
            inPlay.RemoveAt(planToRemoveAt[i]);
            pool.Add(toRecycle);
        }
    }

    private void Spawn()
    {
        GameObject toSpawn = pool[0];
        toSpawn.GetComponent<ResetForSpawn>().Reset();
        toSpawn.transform.position = transform.position;
        pool.RemoveAt(0);
        inPlay.Add(toSpawn);
    }
}
