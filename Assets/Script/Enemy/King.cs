using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Melee {

    private bool isColliding = false;

    private void Awake()
    {
        setAttributes();
        target = GameObject.Find("MainChar");
    }

    public override void setAttributes()
    {
        EnemyName = "King";
        Life = 30;
        Damage = 5;
        StartAttackDelay = 2;
        AttackDelay = 3;
        MoveSpeed = 1.5f;
        animator = this.GetComponent<Animator>();
        animator.SetBool("Walking", true);
        WaitTime = StartAttackDelay;
        Value = 15;
    }

    public override void Follow(Transform _target)
    {        
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        animator.SetBool("Walking", true);
        MoveSpeed = 2;
        if(isColliding)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        transform.LookAt(target.transform);
        WaitTime -= Time.deltaTime;
        if (WaitTime < 0)
        {
            Follow(target.transform);
        }
    }

    public void Hit()
    {
        MoveSpeed = 0;
        animator.SetBool("Walking", false);
        if (isColliding == true)
        {
            PlayerStats.DoDamage(this.Damage);
            Debug.Log("Player life: " + PlayerStats.life);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        PlayerStats.GrowPoints(Value);
    }

    public override void Attack()
    {
        MoveSpeed = 0;
        animator.SetTrigger("Attack");
        animator.SetBool("Walking", false);
        WaitTime = AttackDelay;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }

        if (other.CompareTag("PlayerShoot"))
        {
            Life -= 10;
            Destroy(other.gameObject);
            if (Life <= 0)
            {
                Die();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveSpeed = 0;
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Walking", true);
            MoveSpeed = 2;
            isColliding = false;
        }
    }
}
