using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

	public bool debuggerActive;
	public float matchDuration;
	public float countdownDuration;

	private void Awake()
	{
		if(debuggerActive == true)
		{
			PlayerStats.time = matchDuration;
			PlayerStats.countdown = countdownDuration;
		}
	}
}
