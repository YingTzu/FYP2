using UnityEngine;
using System.Collections;

public class aeroplaneScript : MonoBehaviour {
	
	public static float movementSpeed = -10.0f;
	
	public Sprite dangerWarning; 
	public Sprite danger;
	private GameObject warningSign;
	
	private float interval = 0.2f; 
	
	private bool WARNING = true;
	private float timeUntilNextToggle;
	private float destroyTime = 2.0f;
	private float distanceBetween;
	
	private GameObject Cam;
	
	// Use this for initialization
	void Start () {
		
		timeUntilNextToggle = interval;
		
		warningSign = GameObject.Find ("DANGER");
		Cam = GameObject.Find ("Main Camera");
		
		distanceBetween = this.gameObject.transform.position.x - warningSign.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newVelocity = rigidbody2D.velocity;
		newVelocity.x = movementSpeed;
		rigidbody2D.velocity = newVelocity;
		
		displayDanger ();
		
	}
	
	void displayDanger()
	{
		timeUntilNextToggle -= Time.fixedDeltaTime;
		
		if (timeUntilNextToggle <= 0) {
			WARNING = !WARNING;
			
			SpriteRenderer spriteRenderer = ((SpriteRenderer)warningSign.renderer);
			if (WARNING) {
				spriteRenderer.sprite = dangerWarning;
			} else {
				spriteRenderer.sprite = danger;
			}
			
			float SignX = warningSign.transform.position.x;
			
			Vector2 newPlanePosition = this.gameObject.transform.position;
			newPlanePosition.x =  SignX + distanceBetween;
			this.gameObject.transform.position = newPlanePosition;
			
			timeUntilNextToggle = interval;
		} 
		else 
		{
			Destroy(warningSign, destroyTime); // try not to destroy
		}
		
	}
	
}
