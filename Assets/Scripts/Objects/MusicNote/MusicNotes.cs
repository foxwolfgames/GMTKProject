using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNotes : MonoBehaviour
{
    [Header("Spawns")]
    public GameObject musicNote;
    public GameObject musicNoteShatter;
    public int number = 7;
    private int currNumber;
    public float spawnCooldown1 = .25f;
    public float spawnCooldown2 = .5f;
    void Start()
    {
        currNumber = number;
        SpawnObject1();
    }

    private void SpawnObject1()
    {
        Instantiate(musicNote, transform.position, transform.rotation, transform);
        if (--currNumber > 1)
        {
            Invoke(nameof(SpawnObject1), spawnCooldown1);
        }
        else if (--currNumber <= 0)
        {
            Invoke(nameof(SpawnObject2), spawnCooldown2);
        }
    }

    private void SpawnObject2()
    {
        Instantiate(musicNoteShatter, transform.position, transform.rotation, transform);
    }
}
