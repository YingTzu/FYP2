using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float Up;
	public float Gravity;
	private float playerSpeed;

	public GUIText debug;

	public GameObject player;
	public GameObject player2;
	public bool single, twoPlayer, fourthPlayer;

	public static int life;
	
	void Start () 
	{
		Up = 2f;
		Gravity = -1f;
		checkMode();
	}

	void Update () 
	{
		playerSpeed = playerControl.movementSpeed;
		player.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, Gravity);
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
				player.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, Up);
			}

			if(twoPlayer == true)
			{
				if(myTouches[i].position.y > (Screen.height)/2)
				{
					player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Up));
				}
				if(myTouches[i].position.y < (Screen.height)/2)
				{
					player2.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Up));
				}
			}
		}
	}
}
