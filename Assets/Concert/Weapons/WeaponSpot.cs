using UnityEngine;
using System.Collections;

public class WeaponSpot : MonoBehaviour {

    public EnumWeapons.WeaponId currentWeapon;
    private SpriteRenderer sprite;

    public SpriteRenderer spriteKeyToPress;

    private bool canChangeWeapon;
    private Collider2D currentCollider;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        updateSprite();
        spriteKeyToPress.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") // && currentWeapon != EnumWeapons.WeaponId.NO_WEAPON
        {
            canChangeWeapon = true;
            currentCollider = col;
            spriteKeyToPress.enabled = true;
        }

    }

    void Update()
    {
        if(canChangeWeapon)
        {
            WeaponManager weaponManager = currentCollider.gameObject.GetComponent<WeaponManager>();
            if (weaponManager && Input.GetKeyDown("x"))
            {
                EnumWeapons.WeaponId tmpWeapon = weaponManager.currentWeapon;
                weaponManager.setWeapon(currentWeapon);
                currentWeapon = tmpWeapon;
                updateSprite();
                hideKeySprite();
            }

        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            hideKeySprite();
            Debug.Log("Quit");
        }
    }

    private void hideKeySprite()
    {
        canChangeWeapon = false;
        currentCollider = null;
        spriteKeyToPress.enabled = false;
    }



    void updateSprite()
    {
        sprite.sprite = (Sprite)Resources.Load("Weapons/arme" + (int)currentWeapon, typeof(Sprite));
    }
}
