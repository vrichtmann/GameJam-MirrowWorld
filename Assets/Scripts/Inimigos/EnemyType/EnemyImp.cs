using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImp : EnemyControl{

    private EnemyMoviment enemyMoviment;
    private EnemyControl enemyControler;

    private void Awake(){
        enemyMoviment = this.GetComponent<EnemyMoviment>();
        enemyControler = this.GetComponent<EnemyControl>();
        base.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.Player;

        base.setRandomSpeed();
    }

    void FixedUpdate(){
        enemyMoviment.followTarget(base.RndPlayerFolowPos);
    }
}
