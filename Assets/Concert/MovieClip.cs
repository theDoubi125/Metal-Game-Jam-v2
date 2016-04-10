using UnityEngine;
using System.Collections;

public class MovieClip : MonoBehaviour {

    private SpriteRenderer sprite;
    public Sprite[] sprites;
    private int spritesLength;
    public float currentTime;
    public int currentFrame;
    public float delayBetweenFrames = 0.2f;
    // Use this for initialization
    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        currentTime = 0;
        currentFrame = 0;
        spritesLength = sprites.Length - 1;
    }
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        if(currentTime > delayBetweenFrames)
        {
            NextFrame();
            currentTime = 0;
        }
    }

    void NextFrame()
    {
        currentFrame++;
        if (currentFrame > spritesLength) currentFrame = 0;
        sprite.sprite = sprites[currentFrame];
    }
}
