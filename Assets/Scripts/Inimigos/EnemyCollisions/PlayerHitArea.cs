using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitArea : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player") ) {
            
            PlayerMove playerMove = collision.gameObject.GetComponentInParent<PlayerMove>();
            EnemyControl enemyControl = this.GetComponentInParent<EnemyControl>();

            if (!enemyControl.inteleport && playerMove.isDead == enemyControl.isDead && !enemyControl.beAttacking){
                EnemyControl enemyMoviment = this.GetComponentInParent<EnemyControl>();
                enemyMoviment.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.Player;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            PlayerMove playerMove = collision.gameObject.GetComponentInParent<PlayerMove>();
            EnemyControl enemyControl = this.GetComponentInParent<EnemyControl>();

            if (!enemyControl.inteleport && playerMove.isDead == enemyControl.isDead && !enemyControl.beAttacking){
                enemyControl.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.RandomMove;
                enemyControl.setRandomPos();
            }
        }
    }
}
