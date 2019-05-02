using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
	public string enemyName;
	public float life;
	public float damage;
	public int startAttackDelay;
	public int attackDelay;
    [Range(0, 1)]
    public float dropLifeRate;
    [Range(0, 1)]
    public float dropAmmoRate;
    public int value;
    protected Animator animator;
    protected GameObject target;
    public GameObject LifeItem, AmmoItem;
    private float waitTime;    

    public abstract void setAttributes();
    public abstract void Attack();

    public float WaitTime
    {
        get {return waitTime;}
        set {this.waitTime = value;}
    }

    protected void Drop()
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

    protected void Die()
    {
        Destroy(gameObject);
        Drop();
        PlayerStats.GrowPoints(value);
    }    
}
