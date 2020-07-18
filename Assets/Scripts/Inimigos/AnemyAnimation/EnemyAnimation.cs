using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour{
   
    public string enemyDir = "left";
    private SpriteRenderer sptRender;

    private void Awake(){
        sptRender = this.GetComponent<SpriteRenderer>();
    }

    public void updateEnemyAnimation(Vector2 _dir) {
        if (_dir.x < 0){
            enemyDir = "left";
            sptRender.flipX = false;
        }else{
            enemyDir = "rigth";
            sptRender.flipX = true;
        }
    }
}
