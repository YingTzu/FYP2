using UnityEngine;
using System.Collections;

public class cloudScript : MonoBehaviour {

	public Sprite thunderClouds;    
	public Sprite darkClouds;

	public float interval = 0.5f; 

	private bool Thunder = true;    
	private float timeUntilNextToggle;


	// Use this for initialization
	void Start () 
	{
		timeUntilNextToggle = interval;
	}
	
	// Update is called once per frame
	void Update () 
	{

		timeUntilNextToggle -= Time.fixedDeltaTime;

		if (timeUntilNextToggle <= 0) 
		{
			Thunder = !Thunder;

			GetComponent<Collider2D>().enabled = Thunder;

			SpriteRenderer spriteRenderer = ((SpriteRenderer)this.GetComponent<Renderer>());
			if (Thunder)
			{
				spriteRenderer.sprite = thunderClouds;
			}
			else
			{
				spriteRenderer.sprite = darkClouds;
			}

			timeUntilNextToggle = interval;
		}

	}
}
