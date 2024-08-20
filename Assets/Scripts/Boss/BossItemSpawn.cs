using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public Transform scaleRight;
    public Transform spawnPointLeft;
    public Transform spawnPointRight;
    public Transform cannonLeft;
    public Transform cannonRight;
    public GameObject cannonScriptObjectL;
    public GameObject cannonScriptObjectR;

    private CannonSlot cannonScriptL;
    private CannonSlot cannonScriptR;

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

    [Header("Cannon Settings")]
    //[SerializeField] private float offset = .5f;

    [SerializeField] private float threshold = 0.001f;
    private int Left;
    private int Right;
    [SerializeField] private float leftCurrentHeight;
    [SerializeField] private float leftTargetHeight;
    [SerializeField] private float rightCurrentHeight;
    [SerializeField] private float rightTargetHeight;

    [SerializeField] private float leftStartingYPosition;
    [SerializeField] private float rightStartingYPosition;

    private Quaternion startingPivotRotation;


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

        startingPivotRotation = Pivot.rotation;

        if (cannonScriptObjectL)
            cannonScriptL = cannonScriptObjectL.GetComponent<CannonSlot>();
        if(cannonScriptObjectR)
            cannonScriptR = cannonScriptObjectR.GetComponent<CannonSlot>();
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
        // Change height of scales
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

        // Rotate (pivot) the bar in the middle
        float slope = (spawnPointRight.position.y - spawnPointLeft.position.y) / (spawnPointRight.position.x - spawnPointLeft.position.x);
        float pivotAngle = Mathf.Atan(slope) * Mathf.Rad2Deg;
        Pivot.localRotation = startingPivotRotation * Quaternion.Euler(0, 0, pivotAngle);

        // Rotate the cannons toward bottom item
        if(cannonScriptL && cannonScriptR)
        {
            float cannonAngleL = CalculateLaunchAngle(spawnPointLeft, cannonLeft, cannonScriptL.fireForce, Physics.gravity.y);
            cannonLeft.localRotation = Quaternion.Euler(cannonAngleL, 0f, 0f);
            float cannonAngleR = CalculateLaunchAngle(spawnPointRight, cannonRight, cannonScriptR.fireForce, Physics.gravity.y);
            cannonRight.localRotation = Quaternion.Euler(cannonAngleR, 0f, 0f);
        }

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

    private float CalculateLaunchAngle(Transform target, Transform start, float initialVelocity, float gravity)
    {
        // Calculate the distances
        float deltaY = target.position.y + effectiveItemSize * 2.5f - start.position.y;
        float deltaZ = target.position.z - start.position.z;

        // Calculate the discriminant
        float velocitySquared = initialVelocity * initialVelocity;
        float discriminant = velocitySquared * velocitySquared - gravity * (gravity * deltaZ * deltaZ + 2 * deltaY * velocitySquared);

        if (discriminant >= 0)
        {
            // Calculate the angle using the positive root
            float sqrtDiscriminant = Mathf.Sqrt(discriminant);
            float tanTheta = -(velocitySquared - sqrtDiscriminant) / (gravity * deltaZ);

            // Convert to angle in degrees
            float angle = Mathf.Atan(tanTheta) * Mathf.Rad2Deg;

            return angle;
        }
        else
        {
            Debug.LogWarning("Cannon is out of range");
            return 18f;
        }
    }

}
