using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemSpawn : MonoBehaviour
{
    public GameObject bossItem;
    [SerializeField] private float itemHeight;
    public Transform spawnPoint;
    [SerializeField] private int listSize = 10;
    private List<GameObject> bossItemPool;
    private List<GameObject> activeBossItems;
    private int index;
    void Start()
    {
        //itemHeight = bossItem.transform.localScale.y;
        bossItemPool = new List<GameObject>();
        activeBossItems = new List<GameObject>();
        for (int i = 0; i < listSize; i++)
        {
            GameObject _object = Instantiate(bossItem, transform.position, Quaternion.identity);
            _object.SetActive(false);
            bossItemPool.Add(_object);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        GameObject itemToSpawn = bossItemPool[index];

        itemToSpawn.transform.position = NextSpawnPosition();
        ResetForces(itemToSpawn);
        itemToSpawn.SetActive(true);

        if (!activeBossItems.Contains(itemToSpawn))
        {
            activeBossItems.Add(itemToSpawn);
        }
        print(activeBossItems.Count);

        index = ++index % listSize;
    }

    private Vector3 NextSpawnPosition()
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.y += itemHeight * (activeBossItems.Count + 2);
        return spawnPosition;
    }
    private void ResetForces(GameObject itemToSpawn)
    {
        Rigidbody rb = itemToSpawn.GetComponent<Rigidbody>();
        if(rb)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
