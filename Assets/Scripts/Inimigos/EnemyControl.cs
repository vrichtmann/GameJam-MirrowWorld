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
    public bool beAttacking = false;
    public bool playerDamage = false;

    public int cooldownAttack = 0;
    public int cooldownAttackTimer = 50;

    [HideInInspector] public bool onFocusPlayer = false;
    public Vector3 randomTargetPos = Vector3.zero;
    public Vector2 randomPosVal = new Vector2(5, 5);

    [Space]
    [Header("AreaStatus")] //Atributos
    public GameObject currentArea;
    public AreaType.areaType currentWorld;


    public Vector2 speedVar = new Vector2(0.5f, 2);
    [HideInInspector] public Vector2 RndPlayerFolowPos = new Vector3(0, 0);
    public Vector2 randomRageVal = new Vector2(5, 5);
    public Vector2 collsionWall = new Vector2(0, 0);
    

    [Space]
    [Header("References")]//Referencias
    public GameObject myAnimator;
    public Transform playerPos;
    public EnemiesManager EnemiesManager;


    public void setRandomPos(){
        float randomTargetX = 0;
        float randomTargetY = 0;

        randomTargetX = Random.Range(this.transform.position.x - randomPosVal.x, this.transform.position.x + (randomPosVal.x));
        randomTargetY = Random.Range(this.transform.position.y - randomPosVal.y, this.transform.position.y + (randomPosVal.y));


        BoxCollider2D areaBox = currentArea.GetComponent<BoxCollider2D>();
        float areaBoxX = areaBox.size.x;
        float areaBoxY = areaBox.size.y / 2;


        int intMaxContX = 100;
        int intMaxContY = 100;
        int contRepeatRandomX = 0;
        int contRepeatRandomY = 0;

        while ((randomTargetX > (currentArea.transform.position.x + areaBoxX) || randomTargetX < currentArea.transform.position.x) && contRepeatRandomX < intMaxContX){
            contRepeatRandomX++;

            //float minVal = 1;
            //float randomDir = randomTargetX > 0 ? Random.Range(this.transform.position.x - (randomPosVal.x), -minVal) : Random.Range(minVal, this.transform.position.x + (randomPosVal.x));
            //randomTargetX = randomDir;
            randomTargetX = Random.Range(this.transform.position.x - (randomPosVal.x), this.transform.position.x + (randomPosVal.x));
        }

        while ((randomTargetY < -areaBoxY || randomTargetY > areaBoxY) && contRepeatRandomY < intMaxContY){
            contRepeatRandomY++;

            //float minVal = 1;
            //float randomDir = randomTargetY < -areaBoxY ? Random.Range(this.transform.position.y - (randomPosVal.y), -minVal) : Random.Range(minVal, this.transform.position.y + (randomPosVal.y));
            //randomTargetY = randomDir;

            randomTargetY = Random.Range(this.transform.position.y - (randomPosVal.y), this.transform.position.y + (randomPosVal.y ));
        }

        randomTargetPos = new Vector3(randomTargetX, randomTargetY, 0);
    }

    public void setRandomSpeed(){
        speed = Random.Range(speedVar.x, speedVar.y);

        float randomPosX = Random.Range(-randomRageVal.x, randomRageVal.x);
        float randomPosY = Random.Range(-randomRageVal.y, randomRageVal.y);

        RndPlayerFolowPos = new Vector2(randomPosX, randomPosY);
    }

    public void changeWold(){
        enemyMovimentType = EnemyMovimentType.enemiesMovimentType.RandomMove;

        Debug.Log("CHANGE WORLD");
        //isDead = !isDead;

        if (currentWorld == AreaType.areaType.deadWorld){
            currentWorld = AreaType.areaType.world;
            currentArea = GameObject.FindGameObjectWithTag("woldArea");
            myAnimator.GetComponent<Animator>().SetBool("isDeadWolrd", false);
            isDead = false;
        }
        else{
            currentWorld = AreaType.areaType.deadWorld;
            currentArea = GameObject.FindGameObjectWithTag("deadWoldArea");
            myAnimator.GetComponent<Animator>().SetBool("isDeadWolrd", true);
            isDead = true;
        }
        playerDamage = false;

        this.transform.position = new Vector3((this.transform.position.x * -1), (this.transform.position.y), this.transform.position.z);
        setRandomPos();
    }

    public void Die(){
        //EnemiesManager.removeAllEnemiesList(this.gameObject);
        Destroy(this.gameObject);
    }
}
