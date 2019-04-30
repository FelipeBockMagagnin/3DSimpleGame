using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Melee : Enemy {
	
	public float moveSpeed;
    protected float startSpeed;
    protected bool isColliding = false;

    public override void Attack(){}

	public abstract void Follow(Transform _target);
}
