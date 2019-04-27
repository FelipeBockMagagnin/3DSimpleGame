using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static float life;
    public static float points;
    public static float ammo;

    private void Start()
    {
        life = 50;
        points = 0;
        ammo = 10;
    }

    public static void DoDamage(float damage)
    {
        life -= damage;
    }

    public static void GrowPoints(int amount)
    {
        points += amount;
    }

    public static void PickAmmo(int amount)
    {
        ammo += amount;
    }
}
