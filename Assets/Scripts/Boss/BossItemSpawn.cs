using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossItemSpawn : MonoBehaviour
{
    [Header("References")]
    public List<GameObject> bossItems;
    [SerializeField] private float itemHeight;
    [SerializeField] private float itemScale;
    public GameObject Pivot;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    private int listSize = 0;
    private List<GameObject> bossItemPool;
    private List<GameObject> activeItemLeft;
    private List<GameObject> activeItemRight;
    private int index;
    void Start()
    {
        bossItemPool = new List<GameObject>();
        activeItemLeft = new List<GameObject>();
        activeItemRight = new List<GameObject>();

        foreach (GameObject bossItem in bossItems)
        {
            GameObject _object = Instantiate(bossItem, transform.position, Quaternion.identity);
            BossItemBehavior behaviorScript =  _object.GetComponent<BossItemBehavior>();
            if(behaviorScript)
            {
                behaviorScript.spawnScript = this;
            }
            _object.SetActive(false);
            bossItemPool.Add(_object);
        }
        listSize = bossItems.Count;
        itemScale = bossItems[0].transform.localScale.y;
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
        if (bossItemPool.Count <= 0) // No valid items in pool
            return;
        index = UnityEngine.Random.Range(0, bossItemPool.Count);
        GameObject itemToSpawn = bossItemPool[index];

        if (itemToSpawn.activeSelf)
            print("Item was active when spawned, that's not supposed to happen...");

        bossItemPool.Remove(itemToSpawn);

        bool isLeft = (UnityEngine.Random.value > .5f);
        print(isLeft);

        if (isLeft)
        {
            activeItemLeft.Add(itemToSpawn);
            itemToSpawn.transform.position = NextSpawnPosition(spawnPointLeft.position, activeItemLeft.Count);
        }
        else
        {
            activeItemRight.Add(itemToSpawn);
            itemToSpawn.transform.position = NextSpawnPosition(spawnPointRight.position, activeItemRight.Count);
        }
        print(activeItemLeft.Count);
        ResetForces(itemToSpawn);

        itemToSpawn.SetActive(true);
    }

    private Vector3 NextSpawnPosition(Vector3 spawnPosition, float count)
    {
        spawnPosition.y += itemHeight * itemScale * (count + 1);
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

    public void RemoveItem(GameObject _object)
    {
        if(activeItemLeft.Contains(_object))
        {
            activeItemLeft.Remove(_object);
        }
        else
        {
            activeItemRight.Remove(_object);
        }
        bossItemPool.Add(_object);
    }
}
