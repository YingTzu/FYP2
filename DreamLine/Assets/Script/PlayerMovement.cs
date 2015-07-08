using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float Up = 10.0f;
	public GUIText debug;

	public GameObject player;
	public GameObject player2;
	public bool single, twoPlayer, fourthPlayer;

	public static int life;
	
	void Start () 
	{
		checkMode();
	}

	void Update () 
	{
		Touch();
	}

	void checkMode()
	{
		if(Application.loadedLevelName == "Endless")
		{
			single = true;
			twoPlayer = fourthPlayer = false;
		}
		if(Application.loadedLevelName == "twoPlayer")
		{
			twoPlayer = true;
			single = fourthPlayer = false;
		}
	}

	void Touch()
	{
		Touch[] myTouches = Input.touches;
		
		for(int i = 0; i < Input.touchCount; i++)
		{
			if(single == true)
			{
				player.rigidbody2D.AddForce(new Vector2(0, Up));
			}

			if(twoPlayer == true)
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
		}
	}
}
