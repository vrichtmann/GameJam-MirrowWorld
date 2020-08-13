using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class correctManager : MonoBehaviour{
    [SerializeField]private GameObject[] correctManagers;
    [SerializeField] private GameObject masterKey;
    [SerializeField] private GameObject lastPosition;

    [SerializeField] private GameObject[] hideObjects;
    [SerializeField] private GameObject[] disabledObjects;

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
        if(contCorrect < 3){
            masterKey.GetComponent<Transform>().DOMove(new Vector3(correctManagers[correctManagers.Length - contCorrect].transform.position.x, correctManagers[correctManagers.Length - contCorrect].transform.position.y, -6), 2).SetEase(Ease.InOutCubic).SetDelay(0.4f);
        }else{
            StartCoroutine(hideHud(1.4f));
            masterKey.GetComponent<Transform>().DOMove(new Vector3(lastPosition.transform.position.x, lastPosition.transform.position.y, -6), 2).SetEase(Ease.InOutCubic).SetDelay(0.4f);
        }
        
    }

    private IEnumerator hideHud(float waitTime){
        yield return new WaitForSeconds(waitTime);
        for(int i=0; i < hideObjects.Length; i++){
            Image currentImage = hideObjects[i].GetComponent<Image>();
            currentImage.CrossFadeAlpha(0, 0.5f, false);
        }

        for (int j = 0; j < disabledObjects.Length; j++){
            disabledObjects[j].gameObject.active = false;
        }
    }

}
