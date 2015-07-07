using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float Up = 10.0f;
	public GameObject player;
	public GameObject player2;
	public GUITexture potion1;
	public GUIText debug;
		
	private bool mousedown = false;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_EDITOR
		MouseInput();
		#else
		Touch();
		#endif


	}

	void MouseInput()
	{
		if (mousedown == false)
		{
			if (Input.GetMouseButton(0) == true)
			{
				//mouse input
			}
			
			mousedown = true;
		}
		
		if (Input.GetMouseButton(0) == false && mousedown == true)
		{
			mousedown = false;
		}

	}

	void Touch()
	{
		Touch[] myTouches = Input.touches;
		
		for(int i = 0; i < Input.touchCount; i++)
		{
			if(myTouches[i].position.y > (Screen.height)/2)
			{
				player.rigidbody2D.AddForce(new Vector2(0, Up));
			}
			if(myTouches[i].position.y < (Screen.height)/2)
			{
				player2.rigidbody2D.AddForce(new Vector2(0, Up));
			}
		}
		//		if (Input.touchCount > 0) 
		//		{
		//			Touch touch = Input.GetTouch(0);
		//			int tapCount = Input.touchCount;
		//			for(int i = 0; tapCount > i; i++) 
		//			{    
		//				if(i < 1) 
		//				{
		//					touch = Input.GetTouch(i);
		//				}
		//				if(touch.phase == TouchPhase.Stationary) 
		//				{
		//					if(potion1.GetComponent<GUITexture>().HitTest(touch.position) == true)
		//						debug.text = "powerUp";
		//					if(touch.position.y > (Screen.height)/2)
		//						player.rigidbody2D.AddForce(new Vector2(0, Up));
		//					else if(touch.position.y < (Screen.height)/2)
		//						player2.rigidbody2D.AddForce(new Vector2(0, Up));
		//				}
		//			}
		//		}

	}
}
