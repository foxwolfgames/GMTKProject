using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool1;
    public GameObject objectToPool2;
    public GameObject objectToPool3;
    private GameObject temp;
    private int numItemsPooled = 3;

    public int amountToPool;

    //shouldExpand = object pool for this object can be extended automatically
    public bool shouldExpand = true;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            instantiateObjectToPool(objectToPool1);
            instantiateObjectToPool(objectToPool2);
            instantiateObjectToPool(objectToPool3);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool * numItemsPooled; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }

    public void instantiateObjectToPool(GameObject obj)
    {
        temp = Instantiate(obj);
        temp.SetActive(false);
        pooledObjects.Add(temp);
    }
}