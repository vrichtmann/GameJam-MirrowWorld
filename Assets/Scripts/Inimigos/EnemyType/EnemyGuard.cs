using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : EnemyControl{

    private EnemyMoviment enemyMoviment;

    [Space]
    [Header("Enemy Attributes")]//Variáveis do Inimigo

    public GameObject initArea;

    [Space]
    public bool returnInitPos = true;
    private Vector3 initPos;
    private Vector3 newTargetPosition;

    private void Awake(){
        initPos = this.transform.position;

        enemyMoviment = this.GetComponent<EnemyMoviment>();
        base.setRandomSpeed();
    }

    void FixedUpdate(){
        randomNearPos();
        enemyMoviment.followTarget();
        checkBackInitArea();
        isArrivedNewInitPos();
    }

    private void randomNearPos(){
        float randomPosX = Random.Range(-base.randomRageVal.x, base.randomRageVal.x);
        float randomPosY = Random.Range(-base.randomRageVal.y, base.randomRageVal.y);
        base.RndPlayerFolowPos = new Vector2(randomPosX, randomPosY);
    }

    private void checkBackInitArea(){

        if (base.enemyMovimentType == EnemyMovimentType.enemiesMovimentType.Player){
            var difAreaX = (this.transform.position.x - initArea.transform.position.x);
            var difAreaY = (this.transform.position.y - initArea.transform.position.y);
            var areaRadius = initArea.GetComponent<CircleCollider2D>().radius;

            if (difAreaX > areaRadius || difAreaY > areaRadius)
            {
                base.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.BackToBase;
                float randomNumberX = Random.Range((initArea.transform.position.x - (areaRadius / 2)), (initArea.transform.position.x + (areaRadius / 2)));
                float randomNumberY = Random.Range((initArea.transform.position.y - (areaRadius / 2)), (initArea.transform.position.y + (areaRadius / 2)));

                newTargetPosition = new Vector3(randomNumberX, randomNumberY, initArea.transform.position.z);
            }
        }else if (base.enemyMovimentType == EnemyMovimentType.enemiesMovimentType.BackToBase){
            if (returnInitPos){
                enemyMoviment.followTarget(initPos);
            }else{
                enemyMoviment.followTarget(newTargetPosition);
            }
        }
        
    }

    private void isArrivedNewInitPos(){
        //var difAreaX = (this.transform.position.x - initArea.transform.position.x);
        //var difAreaY = (this.transform.position.y - initArea.transform.position.y);

        //if (difAreaX < 1 || difAreaY < 1 && base.enemyMovimentType == EnemyMovimentType.enemiesMovimentType.BackToBase)
        //{
        //   // base.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.Waiting;
        //    //Debug.Log("AKI : ");
        //}
    }
}
