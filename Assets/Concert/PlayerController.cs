using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D body;
    public float speed;

    private static PlayerController instance;
    public static PlayerController Instance { get { if (instance == null) instance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); return instance; } }

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
	
	}


	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") * speed;
		float moveVertical = Input.GetAxis ("Vertical") * speed;

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        body.AddForce(movement);
    }
}
