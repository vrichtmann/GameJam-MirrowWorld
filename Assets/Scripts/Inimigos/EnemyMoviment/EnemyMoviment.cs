using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour{

    private EnemyControl enemyControler;
    private EnemyAnimation enemyAnimation;

    private void Awake(){
        enemyControler = this.GetComponent<EnemyControl>();
        enemyAnimation = this.GetComponent<EnemyAnimation>();
    }

    public void followTarget(Vector3 target = default(Vector3)){

        if (enemyControler.enemyMovimentType.ToString() == "Player" || target != default(Vector3))
        {
            if (enemyControler.enemyMovimentType.ToString() == "Player"){//Follow Player
                target = enemyControler.RndPlayerFolowPos;

                Vector3 playerNearPosition = new Vector3(enemyControler.playerPos.position.x + target.x + enemyControler.collsionWall.x, enemyControler.playerPos.position.y + target.y + enemyControler.collsionWall.y, enemyControler.playerPos.position.z);
                Vector3 playerPosition = enemyControler.playerPos.position;
                Vector3 EnemyFinalDir = new Vector3(0, 0, 0);

                EnemyFinalDir = enemyControler.onFocusPlayer ? playerPosition : playerNearPosition;//Se ele esta focado no inimigo ou se ele está andando perto

                transform.position = Vector2.MoveTowards(transform.position, EnemyFinalDir, (enemyControler.speed) * Time.deltaTime);
                Vector2 playerDif = new Vector2(transform.position.x - EnemyFinalDir.x, transform.position.y - EnemyFinalDir.y);
                playerDif = playerDif.normalized;

                EnemyAnimation enemyAnimation = enemyControler.myAnimator.GetComponent<EnemyAnimation>();
                enemyAnimation.updateEnemyAnimation(playerDif);
            }else if (enemyControler.enemyMovimentType.ToString() == "RandomMove"){//Follow Player
                target = enemyControler.randomTargetPos;

                transform.position = Vector2.MoveTowards(transform.position, target, (enemyControler.speed) * Time.deltaTime);
                Vector2 playerDif = new Vector2(transform.position.x - target.x, transform.position.y - target.y);
                playerDif = playerDif.normalized;

                EnemyAnimation enemyAnimation = enemyControler.myAnimator.GetComponent<EnemyAnimation>();
                enemyAnimation.updateEnemyAnimation(playerDif); // UPDATE ANIMATION

                if (Mathf.Abs(playerDif.x) < 0.1f || Mathf.Abs(playerDif.y) < 0.1f)
                {
                    enemyControler.setRandomPos();
                }

            }
            //else if (target != default(Vector3)){//Voltando para a Base 
            //    transform.position = Vector2.MoveTowards(transform.position, target, (enemyControler.speed) * Time.deltaTime);

            //    Vector2 playerDif = new Vector2(transform.position.x - target.x, transform.position.y - target.y);
            //    playerDif = playerDif.normalized;

            //    enemyAnimation.updateEnemyAnimation(playerDif); // UPDATE ANIMATION
            //}
        }
    }

    public void setCurrentEnemy(string _targetState)
    {
        Debug.Log("AKII");
        //enemyControler.enemyMovimentType = _targetState;
    }
}
