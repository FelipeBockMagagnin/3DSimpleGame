using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static float life;                       //life of player
    public static float points;                     //total points of player
    public static float ammo;                       //ammo of player
    public static float time;                       //time of the match
    public static int enemyKilled;                  //number of enemys killed
    public static float countdown;                  //start countdown
    public static float totalTime;                  //total match time
    public static bool finalPanel = false;          //if the final panel apears
    public static bool gamePaused = false;          //if the game is paused

    private void Awake()
    {
        finalPanel = false;
        life = 50;
        points = 0;
        ammo = 10;
        time = SaveManager.matchTime;
        countdown = SaveManager.countdownTime;
        enemyKilled = 0;
        totalTime = time;
    }

    private void FixedUpdate()
    {
        if(countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = 0;
        }

        if(time < 0 && finalPanel == false)
        {
            finalPanel = true;
            time = 0;
        }
        else if (time > 0 && finalPanel == false && countdown == 0)
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
