using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollision : MonoBehaviour
{
    public int scaleItemLayer = 10;
    public BossMechanics bossScript;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == scaleItemLayer)
        {
            if(bossScript)
            {
                bossScript.TakeDamage();
            }
        }
    }
}
