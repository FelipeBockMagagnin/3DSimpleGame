using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Melee {

    private void Awake()
    {
        setAttributes();
        target = GameObject.Find("MainChar");
    }

    public override void setAttributes()
    {
        startSpeed = moveSpeed;
        animator = this.GetComponent<Animator>();
        animator.SetBool("Walking", true);
        WaitTime = startAttackDelay;
    }

    public override void Follow(Transform _target)
    {        
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        animator.SetBool("Walking", true);
        moveSpeed = startSpeed;
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
        moveSpeed = 0;
        animator.SetBool("Walking", false);
        if (isColliding == true)
        {
            PlayerStats.DoDamage(damage);
            Debug.Log("Player life: " + PlayerStats.life);
        }
    }

    public override void Attack()
    {
        moveSpeed = 0;
        animator.SetTrigger("Attack");
        animator.SetBool("Walking", false);
        WaitTime = attackDelay;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Attack();
        }

        if (other.CompareTag("PlayerShoot"))
        {
            life -= 10;
            Destroy(other.gameObject);
            if (life <= 0)
            {
                Die();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moveSpeed = 0;
            isColliding = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("Walking", true);
            moveSpeed = startSpeed;
            isColliding = false;
        }
    }

    
}
