using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanics : MonoBehaviour
{
    public int healthPoints = 10;
    public int phase2Threshold = 6;
    public int phase3Threshold = 3;
    public Transform heartTransform;
    public int scaleItemLayer = 10;
    public BossItemSpawn bossItemSpawnScript;
    void Start()
    {
        
    }

    void Update()
    {

    }

    public void TakeDamage()
    {
        healthPoints--;
        print(healthPoints);
        if (healthPoints <= phase2Threshold)
        {
            new BossAdvanceEvent().Invoke();
            if (bossItemSpawnScript)
            {
                bossItemSpawnScript.spawnInterval = 4f;
            }

        }
        else if (healthPoints <= phase3Threshold)
        {
            new BossAdvanceEvent().Invoke();
            if (bossItemSpawnScript)
            {
                bossItemSpawnScript.spawnInterval = 3f;
            }
        }
        else if (healthPoints <= 0)
        {
            new BossAdvanceEvent().Invoke();
        }
    }
}
