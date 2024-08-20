using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class BossItemSpawn : MonoBehaviour
{
    [Header("References")]
    public List<GameObject> bossItems;
    [SerializeField] private float itemHeight;
    [SerializeField] private float itemScale;
    private float effectiveItemSize;

    public Transform Pivot;
    public Transform scaleLeft;
    public Transform spawnPointLeft;
    public Transform scaleRight;
    public Transform spawnPointRight;

    private List<GameObject> bossItemPool;
    private List<GameObject> activeItemLeft;
    private List<GameObject> activeItemRight;
    private int listSize = 0;
    private int index;

    [Header("Scale Settings")]
    [SerializeField, Tooltip("Change in height per unit of weight difference")]
    private float weightImpact = 1f;
    [SerializeField, Tooltip("Maximum units of weight difference shown on the scales")]
    private int maxWeightDifference = 4;
    [SerializeField] private float changeProgress = 0f;

    public int Left;
    public int Right;

    [SerializeField] private float leftCurrentHeight;
    [SerializeField] private float leftTargetHeight;
    [SerializeField] private float rightCurrentHeight;
    [SerializeField] private float rightTargetHeight;

    [SerializeField] private float leftStartingYPosition;
    [SerializeField] private float rightStartingYPosition;

    private Quaternion startingRotation;

    [SerializeField] private float threshold = 0.001f;

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
        effectiveItemSize = itemHeight * itemScale;

        leftStartingYPosition = scaleLeft.position.y;
        rightStartingYPosition = scaleRight.position.y;

        leftCurrentHeight = leftStartingYPosition;
        rightCurrentHeight = rightStartingYPosition;
        leftTargetHeight = leftStartingYPosition;
        rightTargetHeight = rightStartingYPosition;

        startingRotation = Pivot.rotation;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnItem();
        }
    }

    private void FixedUpdate()
    {
        
        if (Mathf.Abs(leftTargetHeight - leftCurrentHeight) > threshold)
        {
            changeProgress += Time.fixedDeltaTime * 0.01f;

            leftCurrentHeight = Mathf.Lerp(leftCurrentHeight, leftTargetHeight, EaseIn(changeProgress));

            if (Mathf.Abs(leftTargetHeight - leftCurrentHeight) <= threshold)
            {
                changeProgress = 0f;
                leftCurrentHeight = leftTargetHeight;
            }
        }

        if (Mathf.Abs(rightTargetHeight - rightCurrentHeight) > threshold)
        {
            changeProgress += Time.fixedDeltaTime * 0.01f;

            rightCurrentHeight = Mathf.Lerp(rightCurrentHeight, rightTargetHeight, EaseIn(changeProgress));

            if (Mathf.Abs(rightTargetHeight - rightCurrentHeight) <= threshold)
            {
                changeProgress = 0f;
                rightCurrentHeight = rightTargetHeight;
            }
        }

        scaleLeft.position = new Vector3(scaleLeft.position.x, leftCurrentHeight, scaleLeft.position.z);
        scaleRight.position = new Vector3(scaleRight.position.x, rightCurrentHeight, scaleRight.position.z);


        float slope = (spawnPointRight.position.y - spawnPointLeft.position.y) / (spawnPointRight.position.x - spawnPointLeft.position.x);
        float angle = Mathf.Atan(slope) * Mathf.Rad2Deg;

        Pivot.rotation = startingRotation * Quaternion.Euler(0, 0, angle);

    }
    private float EaseIn(float x)
    {
        // Other easing functions don't work at the moment
        return x;
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
        //print(isLeft);

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
        //print(activeItemLeft.Count);
        ResetForces(itemToSpawn);

        itemToSpawn.SetActive(true);

        ChangeHeight();
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

        ChangeHeight();
    }
    private Vector3 NextSpawnPosition(Vector3 spawnPosition, float count)
    {
        spawnPosition.y += effectiveItemSize * (count + 1);
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
    private void ChangeHeight()
    {
        print("Change height");
        Left = activeItemLeft.Count;
        Right = activeItemRight.Count;
        if (Mathf.Abs(Left - Right) > maxWeightDifference)
            return;
        if (Left > Right)
        {
            leftTargetHeight = leftStartingYPosition - ((Left - Right) * weightImpact);
            rightTargetHeight = rightStartingYPosition + ((Left - Right) * weightImpact);
        }
        else
        {
            leftTargetHeight = leftStartingYPosition + (Right - Left) * weightImpact;
            rightTargetHeight = rightStartingYPosition - (Right - Left) * weightImpact;
        }
    }
}
