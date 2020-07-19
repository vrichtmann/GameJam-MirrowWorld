using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
    public void checkEnemyDamage(){
        this.GetComponentInParent<Player>().beAttacking = true;
    }

    public void backNormalState(){

        Player player = this.GetComponentInParent<Player>();

        this.GetComponent<Animator>().SetBool("beAttacking", false);
        player.beAttacking = false;
        player.Speed = 5;
    }
}
