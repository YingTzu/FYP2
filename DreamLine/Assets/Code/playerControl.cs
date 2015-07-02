using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {

	public float movementSpeed = 3.0f;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.x = movementSpeed;
		rigidbody2D.velocity = newVelocity;
	}
}
