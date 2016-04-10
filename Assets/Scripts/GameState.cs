using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{
    private bool running;
    private static GameState m_instance;
    public static GameState instance { get { if (m_instance == null) m_instance = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameState>(); return m_instance; } }
	
    public bool isRunning()
    {
        return running;
    }

    public void SetRunning(bool running)
    {
        this.running = running;
    }
}
