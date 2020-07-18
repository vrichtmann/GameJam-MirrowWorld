﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour{

    [SerializeField] private bool inMagicCircle;
    [SerializeField] private GameObject targetPortal;

    public void teleport(GameObject _targetTeleported){
        _targetTeleported.transform.position = targetPortal.transform.position;
    }
}
