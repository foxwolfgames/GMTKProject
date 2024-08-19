using UnityEngine;

public class GlassSpawner : MonoBehaviour
{
    public float spawnRate = 2;

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnGlass();
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
            spawnGlass();
            timer = 0;
        }
    }

    private void spawnGlass()
    {
        GameObject glass = ObjectPool.SharedInstance.GetPooledObject();
        if (glass != null)
        {
            glass.transform.position = new Vector3(Random.Range(-18.0f, 18.0f), 30.0f, Random.Range(10.0f, -10.0f));
            glass.SetActive(true);
        }
    }
}