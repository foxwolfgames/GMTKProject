using System.Collections.Generic;
using UnityEngine;

public class ItemLauncher : MonoBehaviour
{
    private const int PoolSize = 25;
    
    [Tooltip("Background launcher used to indicate that the item is spawning")]
    public ItemLauncherPhysical itemLauncherPhysical;
    
    public ItemLauncherSO itemLauncherScriptableObject;
    
    public ArenaOrchestrator arenaOrchestrator;

    public float launchInterval = 5.0f;
    public float yLevel = 20;
    public bool isLaunching = false;

    private Dictionary<ScaleItemSO, List<GameObject>> _objectPools = new();
    private float _timeSinceLastLaunch = 0.0f;

    private void Awake()
    {
        // Iterate through all strategies for a collection of all possible item types
        foreach (var strategy in itemLauncherScriptableObject.strategies)
        {
            foreach (var itemBank in strategy.possibleItemBanks)
            {
                foreach (var itemPrefab in itemBank.itemPrefabs)
                {
                    var scaleItem = itemPrefab.GetComponent<ScaleItem>();
                    if (scaleItem && !_objectPools.ContainsKey(scaleItem.type))
                    {
                        _objectPools[scaleItem.type] = new List<GameObject>();
                        for (var i = 0; i < PoolSize; i++)
                        {
                            var item = Instantiate(itemPrefab, transform);
                            item.SetActive(false);
                            _objectPools[scaleItem.type].Add(item);
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        if (!isLaunching) return;
        _timeSinceLastLaunch += Time.deltaTime;
        if (_timeSinceLastLaunch >= launchInterval)
        {
            _timeSinceLastLaunch = 0.0f;
            LaunchItem();
        }
    }

    private GameObject GetPooledGameObject(ScaleItemSO type)
    {
        List<GameObject> pool = _objectPools[type];
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }

    private void LaunchItem()
    {
        Transform playerTransform = arenaOrchestrator.player.transform;
        Transform platformPosXPosZ = arenaOrchestrator.platform.cornerPosXPosZ;
        Transform platformNegXNegZ = arenaOrchestrator.platform.cornerNegXNegZ;

        ItemLaunchStrategySO strategy = itemLauncherScriptableObject.strategies[Random.Range(0, itemLauncherScriptableObject.strategies.Length)];
        GameObject[] itemPrefabs = strategy.PickItems();
        foreach (var itemPrefab in itemPrefabs)
        {
            if (itemPrefab.TryGetComponent<ScaleItem>(out ScaleItem scaleItem))
            {
                var item = GetPooledGameObject(scaleItem.type);
                if (item)
                {
                    float[] launchLocation = strategy.locationStrategy.GenerateLaunchLocation(platformPosXPosZ, platformNegXNegZ, playerTransform);
                    // Floats can be less than 0 or greater than 1, so we need to calculate the position ourselves
                    // i.e. a min of 1 and a max of 2, with a given float value of 0.5 should return 1.5
                    // a min of 1 and a max of 2, with a given float value of -0.5 should return 0.5
                    // a min of 1 and a max of 2, with a given float value of 2.0 should return 3.0
                    // a min of 1 and a max of 3, with a given float value of 3.0 should return 7.0
                    float x = platformNegXNegZ.position.x + (platformPosXPosZ.position.x - platformNegXNegZ.position.x) * launchLocation[0];
                    float z = platformNegXNegZ.position.z + (platformPosXPosZ.position.z - platformNegXNegZ.position.z) * launchLocation[1];
                    item.transform.position = new Vector3(x, yLevel, z);
                    Rigidbody rb = item.GetComponent<Rigidbody>();
                    rb.velocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                    item.SetActive(true);
                    Debug.Log("Launched item " + scaleItem.type.name + " at " + item.transform.position + " using strategy " + strategy.name + " with location strategy " + strategy.locationStrategy);
                }
            }
        }
    }
}