using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    [Header("Spawns")]
    public GameObject musicNote;
    public int number = 7;
    private int currNumber;
    public float spawnCooldown = .25f;
    void Start()
    {
        currNumber = number;
        SpawnObject();
    }

    private void SpawnObject()
    {
        Instantiate(musicNote, transform.position, transform.rotation, transform);
        if(--currNumber > 0)
        {
            Invoke(nameof(SpawnObject), spawnCooldown);
        }
    }
}
