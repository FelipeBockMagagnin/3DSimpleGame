using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static float countdownTime;  
    public static float matchTime;
    public static float musicVolume;
    public static float sfxVolume;

    private static SaveManager instance;

    private void Start()
    {
        LoadData();
    }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public static void setData(float count, float matchduration, float music, float sfx)
    {
        countdownTime = count;
        matchTime = matchduration;
        musicVolume = music;
        sfxVolume = sfx;
        SaveData();
        Debug.Log("Salvando dentro do script...");
    }

    public static void SaveData()
    {
        PlayerPrefs.SetFloat("CountdownTime", countdownTime);
        PlayerPrefs.SetFloat("MatchTime", matchTime);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
    }

    public static void LoadData()
    {
        Debug.Log("Carregando dentro do script...");
        if (PlayerPrefs.HasKey("CountdownTime"))
        {
            countdownTime = PlayerPrefs.GetFloat("CountdownTime");
            Debug.Log(countdownTime);
            matchTime = PlayerPrefs.GetFloat("MatchTime");
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
            Debug.Log("Carregando(tem valores)...");
        }
        else
        {
            countdownTime = 1;
            matchTime = 160;
            musicVolume = 1;
            sfxVolume = 1;
            Debug.Log("Carregando(sem valores)...");
        }
    }
}
