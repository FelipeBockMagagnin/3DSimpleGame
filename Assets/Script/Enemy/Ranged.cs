using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ranged : Enemy {
    
	private float rangeDistance;
	
	public override void Attack()
    {
        throw new System.NotImplementedException();
    }

	public float RangeDistance
	{
		get {return this.rangeDistance;}
		set {this.rangeDistance = value;}
	}    
}
