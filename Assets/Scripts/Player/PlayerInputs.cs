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
        bool onPortal = magcCircCol.teste;

        if (onPortal){
            MagicCircle magicCircle = magcCircCol.targetPortal.GetComponent<MagicCircle>();
            playerMove.isDead = !playerMove.isDead;
            magicCircle.teleport(this.gameObject);
        }
    }
}
