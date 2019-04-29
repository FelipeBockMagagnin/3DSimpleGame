using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Ranged {

    private void Awake()
    {
        setAttributes();
        target = GameObject.Find("MainChar");
    }

    public override void setAttributes()
    {
        EnemyName = "Mage";
        Life = 30;
        Damage = 5;
        StartAttackDelay = 2;
        AttackDelay = 10;
        animator = this.GetComponent<Animator>();
        WaitTime = StartAttackDelay;
        Value = 10;
    }

    private void FixedUpdate()
    {
        transform.LookAt(target.transform);
        WaitTime -= Time.deltaTime;
        if (WaitTime < 0)
        {
            Attack();
            WaitTime = AttackDelay;
        }
    }    

    public override void Attack()
    {        
        animator.SetTrigger("Attack");
        GameObject _bullet;
        _bullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(target.transform.position));
        _bullet.transform.LookAt(target.transform);
        Destroy(bullet, 5);
    }

    private void Die()
    {
        Destroy(gameObject);
        PlayerStats.GrowPoints(Value);
    }

    private void OnTriggerEnter(Collider other)
    {
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
}
