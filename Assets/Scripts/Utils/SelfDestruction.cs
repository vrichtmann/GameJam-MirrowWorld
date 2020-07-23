using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour{

    void Start(){}

    // Update is called once per frame
    public void selfDestruction(){
        Destroy(this.gameObject);
    }
}
