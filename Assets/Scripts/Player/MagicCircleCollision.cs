using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleCollision : MonoBehaviour{

    public GameObject targetPortal;
    public bool inMagicCircle = false;

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("MagicCircle")){
            targetPortal = collision.gameObject;
            this.GetComponentInParent<PlayerMove>().Message.active = true;
            inMagicCircle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("MagicCircle")){
            this.GetComponentInParent<PlayerMove>().Message.active = false;
            inMagicCircle = false;
        }
    }
}
