using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    [Space]
    [Header("Enemy Moviment")]//Variáveis de movimentação
    [SerializeField] private EnemyType.enemiesType enemyType;
    public EnemyMovimentType.enemiesMovimentType enemyMovimentType;

    [Space]
    [Header("Enemy Atributes")] //Atributos
    [SerializeField] private int hp = 1;
    [SerializeField] private int damage = 1;
    public float speed = 1;
    public bool isDead = false;
    [HideInInspector] public bool onFocusPlayer = false;


    public Vector2 speedVar = new Vector2(0.5f, 2);
    [HideInInspector] public Vector2 RndPlayerFolowPos = new Vector3(0, 0);
    public Vector2 randomRageVal = new Vector2(5, 5);
    public Vector2 collsionWall = new Vector2(0, 0);

    [Space]
    [Header("References")]//Referencias
    public GameObject myAnimator;
    public Transform playerPos;
    public EnemiesManager EnemiesManager;

    public void setRandomSpeed(){
        speed = Random.Range(speedVar.x, speedVar.y);

        float randomPosX = Random.Range(-randomRageVal.x, randomRageVal.x);
        float randomPosY = Random.Range(-randomRageVal.y, randomRageVal.y);

        RndPlayerFolowPos = new Vector2(randomPosX, randomPosY);
    }

    public void Die(){
        //EnemiesManager.removeAllEnemiesList(this.gameObject);
        Destroy(this.gameObject);
    }
}
