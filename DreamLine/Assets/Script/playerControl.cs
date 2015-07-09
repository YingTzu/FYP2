using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public static float movementSpeed ;
	public static int life;
	public GUITexture heart;
	public GUIText displayLife;
	public GUIText debug;
	
	void Start () {
		life = 3;
		movementSpeed = 3.0f;
	}

	void Update () {
		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.x = movementSpeed;
		rigidbody2D.velocity = newVelocity;

		displayLife.text = "x" + life;;
		if (life <= 0)
		{
			Destroy (heart);
			Destroy(displayLife);
			life = 0;
			movementSpeed = 0;
			Application.LoadLevel(2);
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
