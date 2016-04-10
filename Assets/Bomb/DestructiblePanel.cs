using UnityEngine;
using System.Collections;

public class DestructiblePanel : MonoBehaviour
{
    public int health;
    private float fallSpeed;
    public float gravity;
    private bool dead;

    public void Update()
    {
        if(dead)
        {
            fallSpeed += gravity * Time.deltaTime;
            transform.position += (Vector3)Vector2.down * fallSpeed * Time.deltaTime;
            if (transform.position.y < -600)
                Destroy(gameObject);
        }
    }

    public void Hit()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponManager>().currentWeapon != EnumWeapons.WeaponId.Marteau)
            return;
        health--;
        if (health <= 0)
            dead = true;
        else if (GetComponent<ShakingUI>() == null)
            gameObject.AddComponent<ShakingUI>().Init(5, 70, 1);
        
    }
}
