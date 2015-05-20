using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	public GameObject player;
	public GameObject player2;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 temp = transform.position;
		Touch myTouch = Input.GetTouch (0);
		if (myTouch.position.y >= (Screen.height/2)) 
		{
			//player movement
			temp.y += 1.0f;
			player.transform.position = temp;
		}
		else if (myTouch.position.y <= (Screen.height/2)) 
		{
			//player2 movement
			temp.y += 1.0f;
			player2.transform.position = temp;
		}
		else
		{
			temp.y -= 1.0f;
			player.transform.position = temp;
			player2.transform.position = temp;
		}
	}
}
