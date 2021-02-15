using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualStep : MonoBehaviour
{
    public BoxCollider stepCollider;
    public bool hasBeenStepped = false, isCorrectStep;
    public StepPuzzleMaster puzzleMaster;
    public Material stepMaterial;

    void Start()
    {
        stepCollider = this.GetComponent<BoxCollider>();       
    }

    void Update()
    {
        //Change la couleur des Steps pour donner du feedback au joueur
        if (puzzleMaster.playerHasSucceeded)
        {
            stepMaterial.color = Color.green;
        }
        else if (puzzleMaster.playerHasFailed)
        {
            stepMaterial.color = Color.red;
        }
        else
        {
            stepMaterial.color = Color.white;
        }

        //Reset le Puzzle pour que le joueur puisse reessayer
        if (!puzzleMaster.playesIsPresent && puzzleMaster.playerHasFailed)
        {
            hasBeenStepped = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenStepped && !puzzleMaster.puzzleHasBeenCompleted)
        {
            hasBeenStepped = true;
            StepCheck();
        }
    }

    void StepCheck()
    {
        if (isCorrectStep)
        {
            puzzleMaster.currentSteps ++;
            puzzleMaster.correctSteps++;
        }
        else
        {
            puzzleMaster.currentSteps ++;
        }
    }
}
