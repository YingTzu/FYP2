using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerControl : MonoBehaviour 
{
	public Image Heart;
	public Image Heart2;

	public AudioClip[] SFXclip;

	void Start ()
	{
		Heart.fillAmount = 1;
		if(Application.loadedLevelName == "TwoPlayer")
			Heart2.fillAmount = 1;
	}

	void Update ()
	{
		//player's higest limit
		if(Application.loadedLevelName == "Endless")
		{
			if(this.gameObject.name == "player")
			{
				Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
				pos.y = Mathf.Clamp(pos.y, 0.0f, 0.78f);
				this.gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
			}

			if(Heart.fillAmount == 0)
			{
				PlayerMovement.playerSpeed = 0;
				Application.LoadLevel(2);
			}
		}

		if(Application.loadedLevelName == "TwoPlayer")
		{
			if(this.gameObject.name == "player")
			{
				Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

				pos.y = Mathf.Clamp(pos.y, -0.1f, 0.7f);
				this.gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
			}

			if(this.gameObject.name == "player2")
			{
				Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
				pos.y = Mathf.Clamp(pos.y, 1.25f, 2.5f);
				this.gameObject.transform.position = Camera.main.ViewportToWorldPoint(pos);
			}

			if(Heart.fillAmount == 0)
			{
				//player 2 win
			}
			if(Heart2.fillAmount == 0)
			{
				//player 1 win
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name == "BottomBorder")
		{
			if(this.gameObject.name == "player")
				Heart.fillAmount = 0;
			if(this.gameObject.name == "player2")
				Heart2.fillAmount = 0;
		}
		if (coll.gameObject.tag == "obstacles")
		{
			PlaySound(0);

			Heart.fillAmount -= 1.0f/3.0f;
			if(Application.loadedLevelName == "TwoPlayer")
				Heart2.fillAmount -= 1.0f/3.0f;

			Destroy(coll.gameObject);
		}
	}

	void PlaySound(int clip)
	{
		GetComponent<AudioSource> ().clip = SFXclip [clip];
		GetComponent<AudioSource> ().Play ();
	} 
}
