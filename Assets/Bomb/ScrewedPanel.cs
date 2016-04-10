using UnityEngine;
using System.Collections;

public class ScrewedPanel : MonoBehaviour
{
    public Screw[] screws;
    private bool dead = false;
    public float gravity = 30;
    private float fallSpeed;

    public void OnScrewRemoved()
    {
        bool areAllRemoved = true;
        foreach(var screw in screws)
        {
            if (screw != null && !screw.isDead)
                areAllRemoved = false;
        }
        if (areAllRemoved)
            dead = true;
    }

    public void Update()
    {
        if(dead)
        {
            print("DEAD");
            fallSpeed += Time.deltaTime * gravity;
            transform.position += (Vector3)Vector2.down * Time.deltaTime * fallSpeed;
        }
    }
}
