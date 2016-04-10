using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SparkRenderer : MonoBehaviour
{
    private Image img;
    public Sprite[] sprites;
    public float animSpeed = 0.2f;
    private float animTime;
    private int animFrame;
    public float duration = 5;
    private float time;
    public Image burnedMotherboard;
    private bool started = false;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!started)
            return;
        animTime += Time.deltaTime;
        time += Time.deltaTime;
        if(animTime > animSpeed)
        {
            animTime -= animSpeed;
            animFrame++;
            if (animFrame >= sprites.Length)
                animFrame = 0;
            img.sprite = sprites[animFrame];
        }
        burnedMotherboard.color = new Color(1, 1, 1, time / duration);
        if (time > duration)
            Destroy(gameObject);
    }

    public void Burn()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().currentWeapon != EnumWeapons.WeaponId.Biere)
            return;
        started = true;
        img.color = Color.white;
    }
}
