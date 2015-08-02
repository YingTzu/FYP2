using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerControl : MonoBehaviour {

	public static float movementSpeed;
	public Image Heart;

	public AudioClip[] SFXclip;

	void Start ()
	{
		movementSpeed = 3.0f;
		Heart.fillAmount = 1;
	}

	void Update ()
	{
		Vector2 tempV = new Vector2 (movementSpeed, 0);
		this.GetComponent<Rigidbody2D>().velocity = tempV;

		//player's higest limit
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.y = Mathf.Clamp(pos.y, -0.1f, 0.78f);
		this.gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);

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
			PlaySound(0);
			Heart.fillAmount -= 1.0f/3.0f;
			Destroy(coll.gameObject);
		}
	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource> ().clip = SFXclip [clip];
		GetComponent<AudioSource> ().Play ();
	} 
}
