using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour{
   
    public string enemyDir = "left";
    private SpriteRenderer sptRender;
    private EnemyControl enemyControl;

    private void Awake(){
        sptRender = this.GetComponent<SpriteRenderer>();
        enemyControl = this.GetComponentInParent<EnemyControl>();
    }

    public void updateEnemyAnimation(Vector2 _dir) {
        if (_dir.x < 0){
            enemyDir = "left";
            this.transform.localScale = new Vector3(1, 1, 1);
            //sptRender.flipX = false;
        }else{
            enemyDir = "rigth";
            this.transform.localScale = new Vector3(-1, 1, 1);
            //sptRender.flipX = true;
        }
    }

    public void checkPlayerDamage(){
        Debug.Log("PLAYER DAMAGE 0");
        if (enemyControl.playerDamage){
            Debug.Log("PLAYER DAMAGE 1");
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            float distX = this.transform.parent.transform.position.x - player.transform.parent.position.x;
            float distY = this.transform.parent.transform.position.y - player.transform.parent.position.y;
            Vector3 distPlayer = new Vector3(distX, distY, 0);
            //Vector3 distPlayerX = new Vector3(this.transform.parent.transform.position.x - player.transform.parent.position.x), this.transform.parent.transform.position.y - player.transform.parent.position.y), 0);

            player.GetComponentInParent<PlayerMove>().getDamage(distPlayer);
        }
    }

    public void stopAttack(){
        enemyControl.beAttacking = false;
        enemyControl.myAnimator.GetComponent<Animator>().SetBool("beAttacking", false);
    }
}
