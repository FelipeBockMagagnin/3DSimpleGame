using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Melee {

    private bool isColliding = false;

	private void Awake()
	{
        setAttributes();
    }	

    public override void setAttributes()
    {
        EnemyName = "Warrior";
        Life = 10;
        Damage = 2;
        StartAttackDelay = 2;
        AttackDelay = 3;
        MoveSpeed = 2f;
        animator = this.GetComponent<Animator>();
        animator.SetBool("Walking", true);
    }

	public override void Follow(Transform _target)
	{
        transform.LookAt(_target);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Follow(target.transform);           
    }

    public void Hit()
    {
        MoveSpeed = 2f;
        animator.SetBool("Walking", true);
        if (isColliding == true)
        {
            PlayerStats.DoDamage(this.Damage);
            Debug.Log("Player life: " + PlayerStats.life);
            Attack();
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
        if(other.CompareTag("Player"))
        {            
            Attack();
        }

        if(other.CompareTag("PlayerShoot"))
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
