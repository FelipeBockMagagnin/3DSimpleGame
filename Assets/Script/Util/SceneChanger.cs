using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SceneChanger : MonoBehaviour {

    private SceneChanger instance;
    private AsyncOperation _async;
    private Slider slider;

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

    /// <summary>
    /// Simple method to call the loading screen before go to the scene
    /// </summary>
    /// <param name="sceneName"></param>
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene("LoadingScreen");
        StartCoroutine(loadingScreen(sceneName));        
    }

    IEnumerator loadingScreen(string sceneName)
    {
        yield return new WaitForSeconds(1);

        try
        {
            slider = GameObject.Find("Slider").GetComponent<Slider>();
        }
        catch (NullReferenceException)
        {
            Debug.Log("Failed to get slider");
        }

        _async = SceneManager.LoadSceneAsync(sceneName);
        _async.allowSceneActivation = false;
        
        while (_async.isDone == false)
        {
            Debug.Log("loading: " + _async.progress);
            slider.value = _async.progress;
            if(_async.progress == 0.9f)
            {
                slider.value = 1;
                _async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
