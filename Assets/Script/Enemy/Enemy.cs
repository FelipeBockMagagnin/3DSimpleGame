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

    public abstract void drop();

    public float WaitTime
    {
        get {return waitTime;}
        set {this.waitTime = value;}
    }

	public abstract void Attack();
}
