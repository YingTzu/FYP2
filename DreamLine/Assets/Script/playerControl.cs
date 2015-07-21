using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerControl : MonoBehaviour {

	public static float movementSpeed ;
	public static int life;
	public GUIText debug;
	public Image Heart;

	public bool oneTime;
	void Start ()
	{
		oneTime = false;
		life = 3;
		movementSpeed = 3.0f;
	}

	void Update ()
	{
		Vector2 tempV = new Vector2 (movementSpeed, 0);
		this.GetComponent<Rigidbody2D>().velocity = tempV;
		if (life <= 0)
		{
			life = 0;
			movementSpeed = 0;
			Application.LoadLevel(2);
		}

		if(life == 2 && oneTime == false)
		{
			Heart.fillAmount = 0.5f;
			oneTime = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name == "BottomBorder")
		{
			life = 0;
		}
		if (coll.gameObject.tag == "obstacles")
		{
			life -= 1;
			Heart.fillAmount -= (1/3f);
			Destroy(coll.gameObject);
		}
	}
}
