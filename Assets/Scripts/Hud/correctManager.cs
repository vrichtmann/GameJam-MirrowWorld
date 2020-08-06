using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class correctManager : MonoBehaviour{
    [SerializeField]private GameObject[] correctManagers;
    [SerializeField] private GameObject masterKey;

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

        Debug.Log("SHOW CORRRECT RESPONSE");

        masterKey.GetComponent<Transform>().DOMove(new Vector3(correctManagers[correctManagers.Length - contCorrect].transform.position.x, correctManagers[correctManagers.Length - contCorrect].transform.position.y, -6), 2).SetEase(Ease.InOutCubic).SetDelay(0.4f);
    }

}
