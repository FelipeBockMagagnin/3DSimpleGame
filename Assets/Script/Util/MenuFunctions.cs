using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctions : MonoBehaviour {

    public GameObject optionPanel;

	public void StartGame()
    {

    }

    public void OpenOption()
    {
        optionPanel.GetComponent<Animator>().SetBool("active", true);
    }

    public void CloseOption()
    {
        optionPanel.GetComponent<Animator>().SetBool("active", false);
    }
}
