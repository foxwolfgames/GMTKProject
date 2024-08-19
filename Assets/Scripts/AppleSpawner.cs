using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public float spawnRate = 2;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnApple();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnApple();
            timer = 0;
        }
    }

    private void spawnApple()
    {
        GameObject apple = ObjectPool.SharedInstance.GetPooledObject();
        if(apple != null)
        {
            apple.transform.position = new Vector3(Random.Range(-18.0f, 18.0f), 30.0f, Random.Range(10.0f, -10.0f));
            apple.SetActive(true);
        }
    }
}
