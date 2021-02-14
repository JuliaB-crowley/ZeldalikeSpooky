using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class JUB_Maeve : MonoBehaviour
{
    //collisions
    public JUB_MaeveCollisionDetector left, right, top, bottom;
    public bool collisionLeft, collisionRight, collisionTop, collisionBottom;

    //mouvements
    Rigidbody2D rigidBody;
    Controller controller;
    public float speed, rollSpeed, rollDuration, rollRecover, crouchSpeed, xVelocity, yVelocity, accelerationTime, immunityTime;
    Vector2 rStick, lStick, lStickNormalised, lastDirection, rollDirection, targetSpeed, currentSpeed;

    [SerializeField]
    bool isInRoll, isCrouching, isInRecoil, isInImmunity, isInRecover;
    [SerializeField]
    bool attackMaintained, isInBuildup, isInAttack;

    //combat
    public Transform attackPoint;
    public float attackRange, attackTime, attackAngle;
    public Vector2 quickAtkZone, heavyAtkZone;
    public LayerMask ennemies, breakableObjects;
    public int attackDamage;
    public bool ennemyWasHitOnce;
    List<Collider2D> ennemiesHitLastTime;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        controller = new Controller();
        controller.Enable();

        AttackProfile quickAttack = new AttackProfile(1, new Vector2(1, 1),0.1f, 0.2f);
        AttackProfile heavyAttack = new AttackProfile(3, new Vector2(2, 1),0, 0.8f);

        controller.MainController.Roll.performed += ctx => Roll();
        controller.MainController.Attack.performed += ctx => Attack(quickAttack);// Attack();
        controller.MainController.HeavyAttack.performed += ctx => Attack(heavyAttack);
        //controller.MainController.Crouch.performed += ctx => isCrouching = !isCrouching;
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

    void Attack(AttackProfile attackProfile)
    {
        if (!isInRecover && !isInBuildup && !isInRoll && !isCrouching)
        {
            ennemiesHitLastTime.Clear();
            isInBuildup = true;
            StartCoroutine(Buildup(attackProfile));
        }
    }

    IEnumerator Buildup(AttackProfile attackProfile)
    {
        yield return new WaitForSeconds(attackProfile.atkBuildup);
        isInBuildup = false;
        isInRecover = true;
        StartCoroutine(Hit(attackProfile));
    }
    IEnumerator Hit(AttackProfile attackProfile)
    { 
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(transform.position, attackProfile.atkZone.x, ennemies);
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(attackPoint.position, attackProfile.atkZone.x, breakableObjects);

        
        if(!ennemyWasHitOnce)
        {
            foreach(Collider2D ennemy in hitEnnemies)
            {
                if (!ennemiesHitLastTime.Contains(ennemy))
                {
                    ennemy.GetComponent<JUB_EnnemyDamage>().TakeDamage(attackProfile.atkDamage);
                    Debug.Log("attack was performed");
                    ennemyWasHitOnce = true;
                    ennemiesHitLastTime.Add(ennemy);
                }
            }

        }

        foreach(Collider2D breakableObject in hitObjects)
        {

        }

        yield return new WaitForSeconds(attackProfile.atkRecover);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, quickAtkZone.x);
        Vector3 attackLength;
        attackLength = new Vector3(quickAtkZone.x, 0);
        attackLength = Quaternion.Euler(0, 0, quickAtkZone.y) * attackLength;
        Gizmos.DrawLine(transform.position, transform.position + attackLength);
        attackLength = Quaternion.Euler(0, 0, -2 * quickAtkZone.y) * attackLength;
        Gizmos.DrawLine(transform.position, transform.position + attackLength);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, heavyAtkZone.x);
        attackLength = new Vector3(heavyAtkZone.x, 0);
        attackLength = Quaternion.Euler(0, 0, heavyAtkZone.y) * attackLength;
        Gizmos.DrawLine(transform.position, transform.position + attackLength);
        attackLength = Quaternion.Euler(0, 0, -2 * heavyAtkZone.y) * attackLength;
        Gizmos.DrawLine(transform.position, transform.position + attackLength);
    }

    class AttackProfile
    {
        public AttackProfile(float damage, Vector2 zone, float buildup, float recover)
        {
            atkDamage = damage;
            atkZone = zone;
            atkRecover = recover;
            atkBuildup = buildup;
        }

        public float atkDamage, atkRecover, atkBuildup;
        public Vector2 atkZone;

        public void ChangeDamage(float changeAmount)
        {
            atkDamage += changeAmount;
        }

        public void NewDamage(float newDamageValue)
        {
            atkDamage = newDamageValue;
        }
    }

}
