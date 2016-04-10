using UnityEngine;
using System.Collections;

public class BombSpot : MonoBehaviour
{

    private SpriteRenderer sprite;

    public SpriteRenderer spriteKeyToPress;

    private bool canInterract;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        spriteKeyToPress.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            canInterract = true;
            spriteKeyToPress.enabled = true;
        }

    }

    void Update()
    {
        if (canInterract)
        {
            if (Input.GetKeyDown("x"))
            {
                UIManager.instance.OpenBombMenu();
                hideKeySprite();
            }
        }
    }


    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            hideKeySprite();
        }
    }

    private void hideKeySprite()
    {
        canInterract = false;
        spriteKeyToPress.enabled = false;
    }
}