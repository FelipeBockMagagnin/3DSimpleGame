using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Melee {

    private Animator animator;
    private bool isColliding = false;

    private void Awake()
    {
        EnemyName = "King";
        Life = 30;
        Damage = 5;
        StartAttackDelay = 2;
        AttackDelay = 3;
        MoveSpeed = 1.5f;
        animator = this.GetComponent<Animator>();
        Follow(target.transform);
    }

    public override void Follow(Transform _target)
    {
        animator.SetBool("Walking", true);
    }

    private void FixedUpdate()
    {
        transform.LookAt(target.transform);
        Move();
    }

    public void Hit()
    {
        MoveSpeed = 2f;
        Follow(target.transform);
        if (isColliding == true)
        {
            PlayerStats.DoDamage(this.Damage);
            Debug.Log("Player life: " + PlayerStats.life);
            Attack();
        }
    }

    public override void Move()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
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
