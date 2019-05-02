using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {
    public Text ammo;
    public Text life;
    public Text points;
    public Text time;
    public Text countDown;
    private SceneChanger sceneChanger;

    private void Update()
    {
        ammo.text = "Ammo : " + PlayerStats.ammo.ToString();
        life.text = "Life : " + PlayerStats.life.ToString();
        points.text = "Points : " + PlayerStats.points.ToString();
        time.text = "Time : " + PlayerStats.time.ToString("0");

        if(PlayerStats.countdown == 0 && countDown != null)
        {
            Destroy(countDown.gameObject);
        }

        if (countDown != null)
        {
            countDown.text = PlayerStats.countdown.ToString("0");
        }
    }

    public void GoToScene(string scene)
    {
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
        sceneChanger.GoToScene(scene);
        Debug.Log("Trocando cenas");
    }
}
