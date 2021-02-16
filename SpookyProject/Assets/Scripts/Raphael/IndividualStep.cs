using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualStep : MonoBehaviour
{
    // Script qui g�re chaque dalle individuellement
    public bool hasBeenStepped = false; // Ce bool empeche que le joueur puisse r�utiliser une seule dalle � l'infinit
    public bool isCorrectStep; // Ce bool d�termine si cette dalle est correcte, comme �a j'ai pas besoin de faire un script pour chaque type de dalle
    public StepPuzzleMaster puzzleMaster; // R�ference au puzzle master
    public Material stepMaterial; // Je modifie le material juste pour avoir du feedback de test, pas besoin de le maintenir

    void Update()
    {
        //Change la couleur des Steps pour donner du feedback
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

    //D�tecte le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenStepped && !puzzleMaster.puzzleHasBeenCompleted)
        {
            hasBeenStepped = true;
            StepCheck();
        }
    }

    //Check quel type de dalle viens d'�tre activ� puis modifie les ints du puzzle master en accord
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
