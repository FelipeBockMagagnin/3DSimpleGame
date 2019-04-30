using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Melee : Enemy {
	
	private float moveSpeed;
    protected float startSpeed;

    public override void Attack(){}

	public float MoveSpeed
	{
		get{return this.moveSpeed;}
		set{this.moveSpeed = value;}
	}	

	public abstract void Follow(Transform _target);
}
