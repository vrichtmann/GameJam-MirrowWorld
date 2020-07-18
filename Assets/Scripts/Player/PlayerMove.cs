using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    [Space]
    [Header("References")]//Variáveis de Referencias
    [SerializeField] private Animator MyAnimator;
    [SerializeField] private Rigidbody2D MyRigidBody;
    [SerializeField] private GameObject Message;

    [Space]
    [Header("Attrubutes")]//Atributos
    [SerializeField] private int hp = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float Speed = 0;

    [Space]
    [Header("Inputs")]//Inputs
    private float axisX, axisY;
    private Vector3 direction;
    private bool flipX;
    private Vector3 newScale;
    private bool isWalking;


    void Update(){
        axisY = Input.GetAxis("Vertical");
        axisX = Input.GetAxis("Horizontal");
        direction.x = axisX;
        direction.y = axisY;

        SetAnimation();
        CheckFlip();
    }

    private void FixedUpdate(){
        Movement();
    }

    private void Movement(){
        MyRigidBody.MovePosition(transform.position + Vector3.ClampMagnitude(direction, 1) * Speed * Time.fixedDeltaTime);
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
        newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
