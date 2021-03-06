﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour{

    void Update(){
        if (Input.GetKeyDown(KeyCode.E)) {
            checkTeleport();
        }
    }

    public void checkTeleport(){

        PlayerMove playerMove = this.GetComponent<PlayerMove>();
        MagicCircleCollision magcCircCol = playerMove.ColMagicCircle.GetComponent<MagicCircleCollision>();
        bool onPortal = magcCircCol.inMagicCircle;

        if (onPortal){
            MagicCircle magicCircle = magcCircCol.targetPortal.GetComponent<MagicCircle>();
            playerMove.isDead = !playerMove.isDead;
            magicCircle.teleport(this.gameObject);
        }else if(playerMove.cooldownAtack == 0){
            Debug.Log("Attack");
            playerMove.playerAnim.GetComponent<Animator>().SetBool("beAttacking", true);
            playerMove.Speed = 0;
            playerMove.cooldownAtack = playerMove.cooldownAtackTimer;
        }
    }
}
