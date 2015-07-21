using UnityEngine;
using System.Collections;


public class Potions : MonoBehaviour
{
	private GameObject p1p1, p1p2, p1p3, p2p1, p2p2, p2p3;
	//public GUIText debug;
	private float playerSpeed;

	private float powerUpTime = 10.0f;

	private bool isHealth;
	private bool isSpeedUp;
	private bool isInvisible;
	private bool isTiming = false;

	void Start ()
	{
		playerSpeed = playerControl.movementSpeed;

		p1p1 = GameObject.Find("player1Potion1");
		p1p2 = GameObject.Find("player1Potion2");
		p1p3 = GameObject.Find("player1Potion3");

		p2p1 = GameObject.Find("player2Potion1");
		p2p2 = GameObject.Find("player2Potion2");
		p2p3 = GameObject.Find("player2Potion3");
	}

	// Update is called once per frame
	void Update () 
	{
		usePostion ();
		beginTimer ();
	}

	void usePostion()
	{
		if (Input.touchCount > 0) 
		{
			foreach (Touch touch in Input.touches)
			{
				if (p1p1.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					checkPotion();
				}
				else if (p1p2.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					checkPotion();
				}
				else if (p1p3.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					checkPotion();
				}

				if (p1p1.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					checkPotion();
				}
				else if (p1p2.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					checkPotion();
				}
				else if (p1p3.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					checkPotion();
				}
			}
		}
	}

	void checkPotion()
	{
		isTiming = true;
		if (GameObject.FindWithTag ("Invisible")) 
		{
			//debug.text = "invisible";
		}
		else if(GameObject.FindWithTag("health"))
		{
			//debug.text = "hearth";
		}
		else if (GameObject.FindWithTag ("speedUp")) 
		{
			//debug.text = "speed"+playerSpeed;
			//playerSpeed = 5.0f;
			//playerControl.movementSpeed = playerSpeed;
		}
	}

	void beginTimer()
	{
		if(isTiming)
		{
			powerUpTime -= Time.deltaTime;
			//debug.text = "time"+powerUpTime;
		}
		if(powerUpTime <= 0)
		{
			isTiming = false;
			powerUpTime = 10;
		}
	}
}
