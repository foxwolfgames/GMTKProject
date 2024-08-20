using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieFromLava : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
