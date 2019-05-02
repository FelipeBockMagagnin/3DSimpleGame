using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFunctions : MonoBehaviour {

    public GameObject optionPanel;
    public Text musicVolume;
    public Text sfxVolume;
    public Text matchDuration;
    public Text startCountdown;

    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider matchDurationSlider;
    public Slider startCountdownSlider;

    public void Start()
    {
        setSlidersValues();
    }

    private void Update()
    {
        musicVolume.text = "Music Volume : " + musicVolumeSlider.value.ToString("0.0");
        sfxVolume.text = "SFX Volume : " + sfxVolumeSlider.value.ToString("0.0");
        matchDuration.text = "Match Duration : " + matchDurationSlider.value.ToString("0.0");
        startCountdown.text = "Start Countdown : " + startCountdownSlider.value.ToString("0.0");
    }

    private void setSlidersValues()
    {
        musicVolumeSlider.value = SaveManager.musicVolume;
        sfxVolumeSlider.value = SaveManager.sfxVolume;
        matchDurationSlider.value = SaveManager.matchTime;
        startCountdownSlider.value = SaveManager.countdownTime;
        Debug.Log("Setando sliders...");
        Debug.Log("Valor musica: " + SaveManager.musicVolume);
        Debug.Log("Valor tempo: " + SaveManager.matchTime);
    }

    public void Save()
    {
        SaveManager.setData(startCountdownSlider.value, matchDurationSlider.value, musicVolumeSlider.value, sfxVolumeSlider.value);
        Debug.Log("Salvando...");
    }

    public void OpenOption()
    {
        optionPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void CloseOption()
    {
        optionPanel.GetComponent<Animator>().SetBool("active", false);
    }

    public void PlayGame()
    {
        GameObject.Find("SceneChanger").GetComponent<SceneChanger>().GoToScene("Arena");
    }

    public void ExitGame()
    {
        Debug.Log("game exit");
    }
}
