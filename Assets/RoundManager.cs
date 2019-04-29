using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour {

    public GameObject finalPanel;
    public Text points;
    public Text reward;
    public Text timePassed;

    private bool lockPanel = false;

    public void ActiveFinalPanel()
    {
        finalPanel.GetComponent<Animator>().SetBool("active", true);
        points.text = "Points : " + PlayerStats.points.ToString();
        reward.text = "Reward : test";
        timePassed.text = "Total Time : " + PlayerStats.totalTime.ToString("0.0");
    }


    private void Update()
    {
        if (PlayerStats.finalPanel == true && lockPanel == false)
        {
            lockPanel = true;
            ActiveFinalPanel();
        }
    }

    public void DisableFinalPanel()
    {
        finalPanel.GetComponent<Animator>().SetBool("active", true);
    }
}
