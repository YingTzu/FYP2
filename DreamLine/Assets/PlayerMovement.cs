using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float Up = 40.0f;
	public GameObject player;
	public GameObject player2;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(GameObject.FindWithTag("Player"))
				rigidbody2D.AddForce(new Vector2(0, Up));
		}
		//Touch myTouch = Input.GetTouch (0);
		foreach (Touch touch in Input.touches)
		{
			switch(touch.phase)
			{
				case TouchPhase.Began:
				{
					if(touch.position.y >= (Screen.height/2))
					{
						player.rigidbody2D.AddForce(new Vector2(0, Up));
					}
					else if((touch.position.y <= (Screen.height/2)))
					{
						player2.rigidbody2D.AddForce(new Vector2(0, Up));
					}
				}break;

				case TouchPhase.Ended:
				{
				}break;
			}
//				if (myTouch.position.y >= (Screen.height/2)) 
//				{
//					//player movement
//					temp.y += 1.0f;
//					if(GameObject.FindWithTag("Player"))
//					{
//						transform.position = temp;
//					}
//				}
//				else if (myTouch.position.y <= (Screen.height/2)) 
//				{
//					//player2 movement
//					temp.y += 1.0f;
//					if(GameObject.FindWithTag("Player2"))
//					{
//						transform.position = temp;
//					}
//				}
		}
	}
}
