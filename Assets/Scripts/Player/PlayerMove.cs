using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Player{

    [Space]
    [Header("References")]//Variáveis de Referencias
    public GameObject playerAnim;
    public GameObject ColMagicCircle;
    [SerializeField] private Animator MyAnimator;
    [SerializeField] private Rigidbody2D MyRigidBody;
    public GameObject Message;
    public GameObject heartManager;
    public bool isDead = false;

    [Space]
    [Header("Inputs")]//Inputs
    private float axisX, axisY;
    private Vector3 direction;
    private bool flipX;
    private Vector3 newScale;
    private bool isWalking;

    [Space]
    [Header("Damage")]//Damage
    private float invunerateTimer = 0;
    [SerializeField] private float invunerateStopTimer = 20;

    void Update(){
        axisY = Input.GetAxis("Vertical");
        axisX = Input.GetAxis("Horizontal");
        direction.x = axisX;
        direction.y = axisY;

        SetAnimation();
        CheckFlip();
        checkCoolDownAttack();
    }

    private void FixedUpdate(){
        Movement();
        invunerableTime();
    }

    private void Movement(){
        MyRigidBody.MovePosition(transform.position + Vector3.ClampMagnitude(direction, 1) * base.Speed * Time.fixedDeltaTime);
    }

    private void SetAnimation(){
        if (direction == Vector3.zero && isWalking){
            isWalking = false;

            MyAnimator.SetBool("walking", false);
        }

        if (direction != Vector3.zero && !isWalking){
            isWalking = true;

            MyAnimator.SetBool("walking", true);
        }
    }

    private void CheckFlip(){
        if (axisX > 0){
            if (flipX) Flip();
        }else if (axisX < 0){
            if (!flipX) Flip();
        }
    }

    private void Flip(){
        flipX = !flipX;
        newScale = playerAnim.transform.localScale;
        newScale.x *= -1;
        playerAnim.transform.localScale = newScale;
    }

    public void getDamage(Vector3 _enemyDir){    
        Debug.Log("Get Damage");
        base.hp -= 1;
        invunerateTimer = invunerateStopTimer;
        playerAnim.GetComponent<SpriteRenderer>().color = Color.red;
        MyRigidBody.AddForce(_enemyDir * -2000f);

        heartManager.GetComponent<HeartManager>().updateLife(base.hp);
    }

    private void invunerableTime(){
        if(invunerateTimer > 0){
            invunerateTimer--;
        }else{
            playerAnim.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    private void checkCoolDownAttack(){
        if (cooldownAtack > 0){
            cooldownAtack--;
        }
    }
}
