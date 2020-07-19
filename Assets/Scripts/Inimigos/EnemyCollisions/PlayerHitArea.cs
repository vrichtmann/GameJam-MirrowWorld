using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitArea : MonoBehaviour{

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            PlayerMove playerMove = collision.gameObject.GetComponentInParent<PlayerMove>();
            EnemyControl enemyControl = this.GetComponentInParent<EnemyControl>();

            Debug.Log("playerMove : " + playerMove);
            Debug.Log("enemyControl : " + enemyControl);

            if (playerMove.isDead == enemyControl.isDead){
                EnemyControl enemyMoviment = this.GetComponentInParent<EnemyControl>();
                enemyMoviment.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.Player;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            EnemyControl enemyMoviment = this.GetComponentInParent<EnemyControl>();
            enemyMoviment.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.RandomMove;
            enemyMoviment.setRandomPos();
            Debug.Log("SaiuPlayer Player");
        }
    }
}
