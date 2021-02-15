using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPuzzleMaster : MonoBehaviour
{
    public int stepsRequired;
    public int currentSteps = 0, correctSteps = 0;
    public bool playesIsPresent = false, playerHasFailed = false, playerHasSucceeded = false, puzzleHasBeenCompleted = false;

    void Update()
    {
        if(currentSteps == stepsRequired)
        {
            if(correctSteps >= stepsRequired && !puzzleHasBeenCompleted)
            {
                puzzleHasBeenCompleted = true;
                playerHasSucceeded = true;
                Debug.Log("The Player Has Succeeded");
                //Reward for the player
            }
            else if(correctSteps < stepsRequired)
            {
                playerHasFailed = true;
                correctSteps = 0;
                currentSteps = 0;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playesIsPresent = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playesIsPresent = false;
            playerHasFailed = false;
        }
    }
}
