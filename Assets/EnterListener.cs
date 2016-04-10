using UnityEngine;
using System.Collections;

public class EnterListener : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyUp (KeyCode.Space) || Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.Mouse0)) 
		{
			Application.LoadLevel("FinalScene");
		}
	
	}
}
