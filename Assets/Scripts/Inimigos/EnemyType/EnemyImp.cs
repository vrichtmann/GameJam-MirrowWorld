﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImp : EnemyControl{

    private EnemyMoviment enemyMoviment;
    private EnemyControl enemyControler;

    private void Awake(){
        enemyMoviment = this.GetComponent<EnemyMoviment>();
        enemyControler = this.GetComponent<EnemyControl>();

        base.myAnimator.GetComponent<Animator>().SetBool("isDeadWolrd", base.isDead);

        base.setRandomPos();
        base.enemyMovimentType = EnemyMovimentType.enemiesMovimentType.RandomMove;
        base.setRandomSpeed();
    }

    void FixedUpdate(){
        if (!base.inteleport)
        {
            enemyMoviment.followTarget(base.randomTargetPos);

            if (base.cooldownAttack > 0)
            {
                base.cooldownAttack--;
            }
        }
    }
}
