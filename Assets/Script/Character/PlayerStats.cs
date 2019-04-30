using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static float life;
    public static float points;
    public static float ammo;
    public static float time;
    public static int enemyKilled;

    public static float totalTime;

    public static bool finalPanel = false;

    private void Awake()
    {
        finalPanel = false;
        life = 50;
        points = 0;
        ammo = 10;
        time = 180;
        enemyKilled = 0;
        totalTime = time;
    }

    private void FixedUpdate()
    {        
        if(time < 0 && finalPanel == false)
        {
            finalPanel = true;
            time = 0;
        }
        else if (time > 0 && finalPanel == false)
        {
            time -= Time.deltaTime;
        }
    }

    public static void DoDamage(float damage)
    {
        life -= damage;
        if(life <= 0)
        {
            finalPanel = true;
        }
    }

    public static void Heal(float amount)
    {
        life += amount;
    }

    public static void GrowPoints(int amount)
    {
        points += amount;
        enemyKilled++;
    }

    public static void PickAmmo(int amount)
    {
        ammo += amount;
    }
}
