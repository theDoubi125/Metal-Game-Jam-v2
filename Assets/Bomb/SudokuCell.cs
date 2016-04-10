using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SudokuCell : MonoBehaviour {
    int value;
    bool valueFixed;
    Text text;
    Image img;
    float delayBeforeBreak = 0.2f;
    int inputCountToBreak = 4;
    float breakTimer;
    int inputCount;
    public Sprite brokenKey;

	void Start ()
    {
        text = GetComponentInChildren<Text>();
	}
	
	void Update ()
    {
        breakTimer -= Time.deltaTime;
        if (breakTimer < 0)
            inputCount = 0;
	}

    public void Incr()
    {
        if(!valueFixed)
            value++;
        if (value > 9)
            value = 0;
        text.text = "" + value;
        if (value == 0)
            text.text = "-";
        inputCount++;
        breakTimer = delayBeforeBreak;
        if (inputCount >= inputCountToBreak)
        {
            GetComponent<Image>().sprite = brokenKey;
            GetComponent<Button>().enabled = false;
        }
    }

    public void SetValue(int value)
    {
        text = GetComponentInChildren<Text>();
        img = GetComponent<Image>();
        this.value = value;
        text.text = "" + value;
        if (value == 0)
            text.text = "-";
        else
        {
            valueFixed = true;
            img.color = Color.green;
        }
    }
}
