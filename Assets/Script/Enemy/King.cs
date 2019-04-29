﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Melee {

    private bool isColliding = false;

    private void Awake()
    {
        setAttributes();
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
    }

    public override void Follow(Transform _target)
    {        
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        animator.SetBool("Walking", true);
        MoveSpeed = 2;
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
        WaitTime = AttackDelay;
        if (isColliding == true)
        {
            PlayerStats.DoDamage(this.Damage);
            Debug.Log("Player life: " + PlayerStats.life);
        }
    }

    public override void Attack()
    {
        MoveSpeed = 0;
        animator.SetTrigger("Attack");
        animator.SetBool("Walking", false);
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
                Destroy(gameObject);
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
