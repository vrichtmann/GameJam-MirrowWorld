using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleCollision : MonoBehaviour{

    public GameObject targetPortal;
    public bool inMagicCircle = false;

    private void OnTriggerStay2D(Collider2D collision){
        if (collision.gameObject.CompareTag("MagicCircle")){
            targetPortal = collision.gameObject;
            collision.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponentInParent<PlayerMove>().Message.active = true;
            inMagicCircle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("MagicCircle")){
            collision.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponentInParent<PlayerMove>().Message.active = false;
            inMagicCircle = false;
        }
    }
}
