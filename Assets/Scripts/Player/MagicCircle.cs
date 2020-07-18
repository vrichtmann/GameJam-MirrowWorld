using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("COLIDINDO");
        if (collision.gameObject.CompareTag("MagicCircle")){
            Debug.Log("ENTER");
            this.GetComponentInParent<PlayerMove>().Message.active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("MagicCircle")){
            Debug.Log("Exit");
            this.GetComponentInParent<PlayerMove>().Message.active = false;
        }
    }
}
