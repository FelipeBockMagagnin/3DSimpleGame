using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Enemy : MonoBehaviour {
	public string enemyName;
	public float life;
	public float damage;
	public int startAttackDelay;
    public ParticleSystem blood;
	public int attackDelay;
    [Range(0, 1)]
    public float dropLifeRate;
    [Range(0, 1)]
    public float dropAmmoRate;
    public int value;
    public GameObject popUpObj;
    public List<GameObject> popUps;
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
        float drop = UnityEngine.Random.Range(0, 1.01f);
        if (drop <= dropLifeRate)
        {
            GameObject itemLife;
            itemLife = Instantiate(LifeItem, transform.position, Quaternion.identity);
            itemLife.GetComponent<Rigidbody>().AddForce(Vector3.up * 5);
            Destroy(itemLife, 20f);
        }

        drop = UnityEngine.Random.Range(0, 1.01f);
        if (drop <= dropAmmoRate)
        {
            GameObject itemAmmo;
            itemAmmo = Instantiate(AmmoItem, transform.position, Quaternion.identity);
            itemAmmo.GetComponent<Rigidbody>().AddForce(Vector3.up * 3);
            Destroy(itemAmmo, 20f);
        }
    }

    public void FootR()
    {

    }

    public void FootL()
    {

    }   

    public void InstatiateBlood()
    {
        Instantiate(blood, transform.position, Quaternion.identity);
    } 

    public void popUpDamage(float damage)
    {
        GameObject clone;
        clone = Instantiate(popUpObj, new Vector3(transform.position.x, transform.position.y+2, transform.position.z), Quaternion.identity);
        clone.GetComponent<TextMesh>().text = damage.ToString("0");
        popUps.Add(clone);
        waitPopUp(clone);
    }

    public IEnumerator waitPopUp(GameObject clone)
    {
        yield return new WaitForSeconds(.2f);
        popUps.Remove(clone);
        Destroy(clone);
    }

    public void Update()
    {
        foreach(GameObject g in popUps)
        {
            g.transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
 
            g.transform.GetComponent<TextMesh>().fontSize = g.transform.GetComponent<TextMesh>().fontSize - 1;
 
            g.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }
    }   

    protected void Die()
    {
        Destroy(gameObject);
        Drop();
        PlayerStats.GrowPoints(value);
        InstatiateBlood();
    }    
}
