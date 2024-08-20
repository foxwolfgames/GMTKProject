using UnityEngine;

public class AbacusSpawnScript : MonoBehaviour
{
    public GameObject abacus;
    public float spawnRate = 2;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnAbacus();
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
            spawnAbacus();
            timer = 0;
        }
    }

    void spawnAbacus()
    {
        Instantiate(abacus, new Vector3(Random.Range(-22.0f, 22.0f), 30.0f, Random.Range(15.0f, -28.0f)),
            transform.rotation);
    }
}