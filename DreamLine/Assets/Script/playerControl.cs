using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public static float movementSpeed = 3.0f;
	public static int life = 3;
	public GUITexture heart;

	public GUIText debug;
	
	void Start () {
	}

	void Update () {
		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.x = movementSpeed;
		rigidbody2D.velocity = newVelocity;

		if (life <= 0)
		{
			Destroy (heart);
			life = 0;
			movementSpeed = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name == "BottomBorder")
		{
			life = 0;
		}
		if (coll.gameObject.tag == "obstacles")
		{
			life -= 1;
			Destroy(coll.gameObject);
		}
	}
}
