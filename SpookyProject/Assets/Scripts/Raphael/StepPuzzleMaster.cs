using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepPuzzleMaster : MonoBehaviour
{
    //Le script qui g�re le puzzle des dalles
    public int stepsRequired; // Combien de dalles le joueur doit bien activer pour r�ussir
    public int currentSteps = 0; // Combien de dalles le joueur � march�
    public int correctSteps = 0; // Combien de dalles correctes le joueur � march�
    public bool playesIsPresent = false, playerHasFailed = false, playerHasSucceeded = false, puzzleHasBeenCompleted = false; // des bools qui checkent la progr�ssion du joueur dans le niveau

    void Update()
    {
        if(currentSteps == stepsRequired) //Check de tentative du joueur
        {
            if(correctSteps >= stepsRequired && !puzzleHasBeenCompleted) //Le joueur � r�ussit
            {
                puzzleHasBeenCompleted = true;
                playerHasSucceeded = true;
                Debug.Log("The Player Has Succeeded");                
            }
            else if(correctSteps < stepsRequired) // Le joueur � �chou�. Il doit sortir des dalles pour les reset puis r�commencer
            {
                playerHasFailed = true;
                correctSteps = 0;
                currentSteps = 0;
            }

        }
    }

    //Check si le joueur est pr�sent
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playesIsPresent = true;
        }
        
    }

    //Check si le joueur n'est plus pr�sent
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ResetTiles());
        }
    }

    //J'ai besoin que les deux bools soyent oppos�s pendant quelques frames pour que je puisse reset les dalles
    IEnumerator ResetTiles()
    {
        playesIsPresent = false;
        yield return new WaitForSeconds(0.02f);
        playerHasFailed = false;
    }
}
