using UnityEngine;
using System.Collections;

public class ShakingUI : MonoBehaviour {
    public float amplitude, freq;
    public float duration;
    private Vector2 initPos;
    private float time;

	void Start ()
    {
        initPos = transform.position;
	}

    public void Init(float amplitude, float freq, float duration)
    {
        this.amplitude = amplitude;
        this.freq = freq;
        this.duration = duration;
    }
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        if(time > duration)
        {
            transform.position = initPos;
            Destroy(this);
        }
        else
        {
            transform.position = initPos + Vector2.right * Mathf.Sin(freq * time * 2 * Mathf.PI) * amplitude;
        }
	}
}
