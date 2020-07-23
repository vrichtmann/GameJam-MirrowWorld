using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour{

    private Animator myAnimator;

    private void Awake(){
        myAnimator = this.GetComponent<Animator>();
    }

    public void teleportEffect(){
        myAnimator.SetBool("teleport", true);
    }

    public void stopTeleportEffect(){
        Debug.Log("STOP TELEPORTING");
        myAnimator.SetBool("teleport", false);
    }

}
