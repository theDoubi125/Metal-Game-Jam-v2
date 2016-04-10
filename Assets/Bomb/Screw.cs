using UnityEngine;
using System.Collections;

public class Screw : MonoBehaviour
{
    public float stepDuration, stepAngle;
    public int stepsToRemove;
    public float gravity;
    public int currentStep;
    public float currentTime;
    private bool dead;
    private float fallSpeed;
    public ScrewedPanel parentPanel;

    public bool isDead { get { return dead; } }

	void Start ()
    {
	
	}
	
	void Update ()
    {
	    if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            transform.localRotation *= Quaternion.AngleAxis(stepAngle * Time.deltaTime / stepDuration, new Vector3(0, 0, 1));
        }
        if (currentTime <= 0 && currentStep >= stepsToRemove)
        {
            dead = true;
            if(parentPanel != null)
                parentPanel.OnScrewRemoved();
        }
        if(dead)
        {
            fallSpeed += gravity * Time.deltaTime;
            transform.position += (Vector3)(fallSpeed * Time.deltaTime * Vector2.down);
            if (transform.position.y < -600)
                Destroy(gameObject);
        }


    }

    public void Turn()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().currentWeapon != EnumWeapons.WeaponId.Tournevis)
            return;
        if(currentTime <= 0)
        {
            currentTime = stepDuration;
            currentStep++;
        }
    }
}
