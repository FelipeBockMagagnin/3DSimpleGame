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
        GameObject _bullet;
        _bullet = Instantiate(bullet, transform.position, Quaternion.LookRotation(target.transform.position));
        _bullet.transform.LookAt(target.transform);
        Destroy(_bullet, 5);
    }

    private void Die()
    {
        Destroy(gameObject);
        drop();
        PlayerStats.GrowPoints(value);
    }

    public override void drop()
    {
        float drop = Random.Range(0, 1.01f);
        if (drop <= dropLifeRate)
        {
            GameObject itemLife;
            itemLife = Instantiate(LifeItem, transform.position, Quaternion.identity);
            itemLife.GetComponent<Rigidbody>().AddForce(Vector3.up * 5);
            Destroy(itemLife, 20f);
        }

        drop = Random.Range(0, 1.01f);
        if (drop <= dropAmmoRate)
        {
            GameObject itemAmmo;
            itemAmmo = Instantiate(AmmoItem, transform.position, Quaternion.identity);
            itemAmmo.GetComponent<Rigidbody>().AddForce(Vector3.up * 3);
            Destroy(itemAmmo, 20f);
        }
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
            }
        }
    }
}
