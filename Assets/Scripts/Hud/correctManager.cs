using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class correctManager : MonoBehaviour{
    [SerializeField]private GameObject[] correctManagers;

    public int contCorrect = 0;

    private void Awake(){
       // hideCorrectResponse();
    }

    public void hideCorrectResponse(){
        for(int i = 0; i < correctManagers.Length; i++){
            correctManagers[i].SetActive(false);
        }
    }

    public void showCorrectResponse(){
        contCorrect++;
        for (int i = 0; i < contCorrect; i++){
            if(correctManagers[correctManagers.Length - contCorrect]) correctManagers[correctManagers.Length - contCorrect].SetActive(false);
        }
    }

}
