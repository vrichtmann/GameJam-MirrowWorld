using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthManager : MonoBehaviour
{

    [SerializeField] private GameObject[] allElements;

    void Update(){
        for(int i= 0; i < allElements.Length; i++){
            allElements[i].GetComponentInChildren<SpriteRenderer>().sortingOrder = (int)(allElements[i].transform.position.y * -1) + 10;
        }
    }
}
