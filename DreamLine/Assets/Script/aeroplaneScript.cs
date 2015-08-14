using UnityEngine;
using System.Collections;

public class aeroplaneScript : MonoBehaviour {
	
	public static float movementSpeed = -10.0f;

	private GameObject warningSign;
	private float distanceBetween;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 newVelocity = GetComponent<Rigidbody2D> ().velocity;
		newVelocity.x = movementSpeed;
		GetComponent<Rigidbody2D>().velocity = newVelocity;
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name == "Clouds") 
		{
			gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
		}
	}
}
