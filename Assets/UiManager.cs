using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Text ammo;
    public Text life;
    public Text points;
    public Text time;

    private void Update()
    {
        ammo.text = "Ammo : " + PlayerStats.ammo.ToString();
        life.text = "Life : " + PlayerStats.life.ToString();
        points.text = "Points : " + PlayerStats.points.ToString();
        time.text = "Time : " + PlayerStats.time.ToString("0.0");
    }
}
