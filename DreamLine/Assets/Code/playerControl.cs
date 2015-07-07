using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public static float movementSpeed = 3.0f;
	public int live = 1;
	public GUITexture heart;

	public GUIText debug;

	public GameObject deadZone;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.x = movementSpeed;
		rigidbody2D.velocity = newVelocity;
		debug.text = "live" + live;

		if (live <= 0)
		{
			Destroy (heart);
			live = 0;
			movementSpeed = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name == "BottomBorder")
		{
			live -= 1;
			//Destroy(coll.gameObject);
		}
	}
}
