using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public GameObject bombUI, toolIconUI, bottomUI;

    public static UIManager instance;

	void Start () {
        instance = this;

    }
	
	void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            if (bombUI.activeSelf)
            {
                bombUI.SetActive(false);
                bottomUI.SetActive(false);
                toolIconUI.SetActive(false);
                GameState.instance.SetRunning(true);
            }
            else
            {

                bombUI.SetActive(true);
                bottomUI.SetActive(true);
                toolIconUI.SetActive(true);
                GameState.instance.SetRunning(false);
            } 
        }
    }

    public void OpenBombMenu()
    {
        GameState.instance.SetRunning(false);
        bombUI.SetActive(true);
        toolIconUI.SetActive(true);
    }
}
