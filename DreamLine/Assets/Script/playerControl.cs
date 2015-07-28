using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerControl : MonoBehaviour {

	public static float movementSpeed;
	public GUIText debug;
	public Image Heart;
	
	void Start ()
	{
		movementSpeed = 3.0f;
		Heart.fillAmount = 1;
	}

	void Update ()
	{
		Vector2 tempV = new Vector2 (movementSpeed, 0);
		this.GetComponent<Rigidbody2D>().velocity = tempV;

		if(Heart.fillAmount == 0)
		{
			movementSpeed = 0;
			Application.LoadLevel(2);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name == "BottomBorder")
		{
			Heart.fillAmount = 0;
		}
		if (coll.gameObject.tag == "obstacles")
		{
			Heart.fillAmount -= 1.0f/3.0f;
			Destroy(coll.gameObject);
		}
	}
}
