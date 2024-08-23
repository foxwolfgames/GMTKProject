using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieFromLava : MonoBehaviour
{
    //public TextMesh gameOverMsg; 
    void Start()
    {
    }
    public void OnCollisionEnter(Collision collision)
    {
        //gameOverMsg.meshRend.enabled = true; 
        SceneManager.LoadScene("MainMenu");
    }
}
