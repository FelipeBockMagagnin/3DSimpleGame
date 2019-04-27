using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {
	private string enemyName;
	private float life;
	private float damage;
	private int startAttackDelay;
	private int attackDelay;
	public Transform target;

	public string EnemyName
	{
		get {return enemyName;}
		set {this.enemyName = value;}
	}

	public float Life
	{
		get{return this.life;}
		set{this.life = value;}
	}

	public float Damage
	{
		get{return this.damage;}
		set{this.damage = value;}
	}

	public int StartAttackDelay
	{
		get{return this.startAttackDelay;}
		set{this.startAttackDelay = value;}
	}

	public int AttackDelay
	{
		get{return this.attackDelay;}
		set{this.attackDelay = value;}
	}

	public abstract void Atack();
}
