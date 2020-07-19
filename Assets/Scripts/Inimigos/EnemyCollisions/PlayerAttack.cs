using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerMove playerMove = collision.gameObject.GetComponentInParent<PlayerMove>();
            EnemyControl enemyControl = this.GetComponentInParent<EnemyControl>();

            if (playerMove.isDead == enemyControl.isDead){
                EnemyControl enemyMoviment = this.GetComponentInParent<EnemyControl>();
                enemyMoviment.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.Attack;
                enemyControl.beAttacking = true;
                enemyControl.myAnimator.GetComponent<Animator>().SetBool("beAttacking", true);
            }

        }
    }
}
