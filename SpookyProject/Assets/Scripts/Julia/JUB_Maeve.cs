using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_Maeve : MonoBehaviour
{
    //collisions
    public JUB_MaeveCollisionDetector left, right, top, bottom;
    public bool collisionLeft, collisionRight, collisionTop, collisionBottom;

    Rigidbody2D rigidBody;
    Controller controller;
    public float speed, rollSpeed, rollDuration, rollRecover, crouchSpeed, xVelocity, yVelocity, accelerationTime, immunityTime;
    Vector2 rStick, lStick, lStickNormalised, lastDirection, rollDirection, targetSpeed, currentSpeed;

    [SerializeField]
    bool isInRoll, isCrouching, isInRecoil, isInImmunity, isInRecover;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        controller = new Controller();
        controller.Enable();

        controller.MainController.Roll.performed += ctx => Roll();
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
        Move();
    }

    void Inputs()
    {
        lStick = controller.MainController.Move.ReadValue<Vector2>();
        lStickNormalised = lStick.normalized;

        if(lStick != Vector2.zero)
        {
            lastDirection = lStickNormalised;
            //animation movement on
        }
        else
        {
            //animation movement off
        }

        if(!isInRoll)
        {
            rollDirection = lastDirection;
        }
    }

    void Move()
    {
        if(!isInRoll)
        {
            if(!isCrouching)
            {
                targetSpeed = Vector2.ClampMagnitude(lStick,1) * speed;
            }
            else
            {
                targetSpeed = Vector2.ClampMagnitude(lStick, 1) * crouchSpeed;
            }
        }

        collisionLeft = left.isCollision;
        collisionRight = right.isCollision;
        collisionTop = top.isCollision;
        collisionBottom = bottom.isCollision;

        if(!isInRecoil)
        {
            currentSpeed.x = Mathf.SmoothDamp(currentSpeed.x, targetSpeed.x, ref xVelocity, accelerationTime);
            currentSpeed.y = Mathf.SmoothDamp(currentSpeed.y, targetSpeed.y, ref yVelocity, accelerationTime);

        }

        if (collisionLeft && currentSpeed.x < 0)
        {
            currentSpeed.x = 0;
        }
        if (collisionRight && currentSpeed.x > 0)
        {
            currentSpeed.x = 0;
        }
        if (collisionTop && currentSpeed.y > 0)
        {
            currentSpeed.y = 0;
        }
        if (collisionBottom && currentSpeed.y < 0)
        {
            currentSpeed.y = 0;
        }

        rigidBody.velocity = currentSpeed;

    }

    void Roll()
    {
        if (!isInRecover)
        {
            isInRoll = true;
            isInImmunity = true;
            isInRecover = true;
            StartCoroutine(RollCoroutine());
        }
    }

    IEnumerator RollCoroutine()
    {
        targetSpeed = rollDirection * rollSpeed;
        //anim roulade
        yield return new WaitForSeconds(rollDuration);
        isInRoll = false;
        isInImmunity = false;
        yield return new WaitForSeconds(rollRecover);
        isInRecover = false;
    }
       
    public void Damage(int dmg)
    {
        if(!isInImmunity)
        {
            //inflict damages
            //anim dégats
            StartCoroutine(ImmunityCoroutine());
        }
    }

    IEnumerator ImmunityCoroutine()
    {
        isInImmunity = true;
        //clignotement/anim immunité
        yield return new WaitForSeconds(immunityTime);
        isInImmunity = false;
    }
}
