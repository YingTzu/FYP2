using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public float Up, Down;
	public float Gravity;
	public float Gravity2;
	public static float playerSpeed;
	public static float playerSpeed2;

	public GameObject player;
	public GameObject player2;
	public bool single, twoPlayer;

	void Start () 
	{
		Up = 1f;
		Gravity = -1f;
		Down = -1f;
		Gravity2 = 1f;

		playerSpeed = 3.0f;
		playerSpeed2 = 3.0f;
		checkMode();
	}

	void Update () 
	{
		if(Application.loadedLevelName == "Endless")
		{
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, Gravity);
		}

		if(Application.loadedLevelName == "TwoPlayer")
		{
			player.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, Gravity);
			player2.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed2, Gravity2);
		}
		Touch();
	}

	void checkMode()
	{
		if(Application.loadedLevelName == "Endless")
		{
			single = true;
			twoPlayer = false;
		}
		if(Application.loadedLevelName == "TwoPlayer")
		{
			twoPlayer = true;
			single = false;
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
				if(myTouches[i].position.y < (Screen.height)/2)
				{
					player.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, Up);
				}
				if(myTouches[i].position.y > (Screen.height)/2)
				{
					player2.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed2, Down);
				}
			}
		}
	}
}
