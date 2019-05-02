using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    public Text ammo;
    public Text life;
    public Text points;
    public Text time;
    public Text countDown;
    private SceneChanger sceneChanger;

    public GameObject finalPanel;
    public GameObject pausePanel;
    public Text finalPoints;
    public Text reward;
    public Text timePassed;

    private bool lockFinalPanel = false;
    private bool lockPausePanel = false;

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

        if (PlayerStats.finalPanel == true && lockFinalPanel == false)
        {
            lockFinalPanel = true;
            ActiveFinalPanel();
        }

        if (Input.GetButtonDown("Cancel") && lockPausePanel == false && lockPausePanel == false)
        {
            ActivePausePanel();
        }
    }

    public void GoToScene(string scene)
    {
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneChanger>();
        sceneChanger.GoToScene(scene);
        Debug.Log("changing scene");
    }

    private void Pausegame()
    {
        Time.timeScale = 0;
        Screen.lockCursor = false;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        Screen.lockCursor = true;
    }

    public void ActivePausePanel()
    {
        lockPausePanel = true;
        Pausegame();
        pausePanel.SetActive(true);
        PlayerStats.gamePaused = true;
    }

    public void DisablePausePanel()
    {
        lockPausePanel = false;
        ResumeGame();
        pausePanel.SetActive(false);
        PlayerStats.gamePaused = false;
    }

    public void ActiveFinalPanel()
    {
        finalPanel.GetComponent<Animator>().SetBool("active", true);
        points.text = "Points : " + PlayerStats.points.ToString();
        reward.text = "Reward : test";
        timePassed.text = "Total Time : " + PlayerStats.totalTime.ToString("0.0");
    }

    public void DisableFinalPanel()
    {
        finalPanel.GetComponent<Animator>().SetBool("active", true);
    }
}
