using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
    public void checkEnemyDamage(){
        this.GetComponent<Animator>().SetBool("beAttacking", false);
        this.GetComponentInParent<Player>().beAttacking = false;
        //if (enemyControl.playerDamage){
        //    Debug.Log("PLAYER DAMAGE 1");
        //    GameObject player = GameObject.FindGameObjectWithTag("Player");

        //    float distX = this.transform.parent.transform.position.x - player.transform.parent.position.x;
        //    float distY = this.transform.parent.transform.position.y - player.transform.parent.position.y;
        //    Vector3 distPlayer = new Vector3(distX, distY, 0);
        //    //Vector3 distPlayerX = new Vector3(this.transform.parent.transform.position.x - player.transform.parent.position.x), this.transform.parent.transform.position.y - player.transform.parent.position.y), 0);

        //    player.GetComponentInParent<PlayerMove>().getDamage(distPlayer);
        //}
    }
}
