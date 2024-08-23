using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    DialogueController dialogueController = new DialogueController();
    PlayerPickUp playerPickUp = new PlayerPickUp();

    [SerializeField] private GameObject part1;
    [SerializeField] private GameObject part2;
    [SerializeField] private GameObject part3;
    [SerializeField] private GameObject part4;
    [SerializeField] private GameObject part5;

    private bool part1Finish;
    private bool part2Finish;
    private bool part3Finish;
    private bool part4Finish;
    private bool part5Finish;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private void checkPart1Finish() {
        if (playerPickUp.checkThrown()){
            Debug.Log("tutorialthrown");
        }
    }
}
