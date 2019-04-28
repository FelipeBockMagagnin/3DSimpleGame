using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : Ranged {

    private float waitTime;

    private void Awake()
    {
        setAttributes();
    }

    public override void setAttributes()
    {
        EnemyName = "Mage";
        Life = 30;
        Damage = 5;
        StartAttackDelay = 2;
        AttackDelay = 10;
        animator = this.GetComponent<Animator>();
        waitTime = StartAttackDelay;
    }

    private void FixedUpdate()
    {
        transform.LookAt(target.transform);
        waitTime -= Time.deltaTime;
        if (waitTime < 0)
        {
            Attack();
            waitTime = AttackDelay;
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
}
