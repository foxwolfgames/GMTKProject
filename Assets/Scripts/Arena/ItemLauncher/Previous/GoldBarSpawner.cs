using UnityEngine;

public class GoldBarSpawner : MonoBehaviour
{
    public float spawnRate = 2;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnGoldBar();
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
            spawnGoldBar();
            timer = 0;
        }
    }

    private void spawnGoldBar()
    {
        GameObject goldBar = ObjectPool.SharedInstance.GetPooledObject();
        if (goldBar != null)
        {
            goldBar.transform.position = new Vector3(Random.Range(-18.0f, 18.0f), 30.0f, Random.Range(10.0f, -10.0f));
            goldBar.SetActive(true);
        }
    }
}