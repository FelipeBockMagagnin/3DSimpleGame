using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Ranged {

    private void Awake()
    {
        setAttributes();
        target = GameObject.Find("MainChar");
    }
    
    public override void setAttributes()
    {
        animator = this.GetComponent<Animator>();
        WaitTime = startAttackDelay;
    }

    private void FixedUpdate()
    {
        transform.LookAt(target.transform);
        WaitTime -= Time.deltaTime;
        if (WaitTime < 0)
        {
            Attack();
            WaitTime = attackDelay;
        }
    }    

    public override void Attack()
    {
        animator.SetTrigger("Attack");        
    }

    public void Shoot()
    {
        GameObject _bullet;        
        Vector3 spawnPos = transform.position;
        spawnPos.y += 2;
        _bullet = Instantiate(bullet, spawnPos, Quaternion.LookRotation(target.transform.position));
        _bullet.transform.LookAt(target.transform);
        Destroy(_bullet, 5);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShoot"))
        {
            life -= 10;
            Destroy(other.gameObject);
            if (life <= 0)
            {
                Die();
                foreach(GameObject g in popUps)
                {
                    Destroy(g);
                }
            }
            else 
            {
                popUpDamage(10);
            }
        }
    }
}
