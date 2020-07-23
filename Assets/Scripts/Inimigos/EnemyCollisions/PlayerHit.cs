using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour{
   
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            EnemyControl enemyControl = this.GetComponentInParent<EnemyControl>();
            if(!enemyControl.inteleport && enemyControl.cooldownAttack == 0){
                enemyControl.playerDamage = true;
                enemyControl.cooldownAttack = enemyControl.cooldownAttackTimer;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            EnemyControl enemyControl = this.GetComponentInParent<EnemyControl>();

            if (!enemyControl.inteleport && enemyControl.cooldownAttack == 0){
                enemyControl.playerDamage = false;
            }
        }
    }

}
