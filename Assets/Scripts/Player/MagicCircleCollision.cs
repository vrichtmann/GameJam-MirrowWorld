using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircleCollision : MonoBehaviour{

    public GameObject targetPortal;
    public bool teste = false;

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("COLIDINDO");
        if (collision.gameObject.CompareTag("MagicCircle")){
            Debug.Log("ENTER");
            targetPortal = collision.gameObject;
            this.GetComponentInParent<PlayerMove>().Message.active = true;
            teste = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("MagicCircle")){
            Debug.Log("Exit");
            this.GetComponentInParent<PlayerMove>().Message.active = false;
            teste = false;
        }
    }
}
