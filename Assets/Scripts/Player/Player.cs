using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    [Space]
    [Header("Attrubutes")]//Atributos
    public int hp = 1;
    public int damage = 1;
    public float Speed = 0;
    public bool beAttacking = false;
    public int cooldownAtack = 0;
    public int cooldownAtackTimer = 50;
}
