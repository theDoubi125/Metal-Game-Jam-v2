using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerBehaviour : MonoBehaviour {

	float timeRemaining; //in seconds

	// Use this for initialization
	void Start () {

		timeRemaining = 300;
	
	}
	
	// Update is called once per frame
	void Update () {

		timeRemaining = timeRemaining - Time.deltaTime;
		UpdateTimer (Mathf.FloorToInt (timeRemaining));
	
		if (timeRemaining < 0) 
		{
			EndGame();
		}

	}

	private void UpdateTimer(int nbSecondsRemaining)
	{
		if (nbSecondsRemaining < 0) 
		{
			nbSecondsRemaining = 0;
		}

		GameObject timerLabel = GameObject.Find ("TimerLabel");
		Text text = timerLabel.GetComponent<Text> ();
		text.text = FormatTime (nbSecondsRemaining);
	}

	private string FormatTime(int nbSeconds)
	{
		int nbMinutes = nbSeconds / 60;
		int nbSecondsPerMin = nbSeconds % 60;
		string formattedNbSecondsPerMin = nbSecondsPerMin.ToString();
		if (nbSecondsPerMin < 10) 
		{
			formattedNbSecondsPerMin = "0" + formattedNbSecondsPerMin;
		}
		return nbMinutes.ToString() + ":" + formattedNbSecondsPerMin;
	}

	private void EndGame()
	{
		//make the bomb go kaboom
	}
}
