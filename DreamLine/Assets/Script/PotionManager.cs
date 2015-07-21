using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionManager : MonoBehaviour {

	public GameObject screenCanves;
	public GameObject p1, p2, p3;
	public GameObject p1Clone, p2Clone, p3Clone;

	public Button healUI;
	public Button speedUpUI;
	public Button invisibleUI;

	public Image Heart;

	public int type;
	public float spawnTime;
	public float powerUpTime;

	public bool isHeal;
	public bool isSpeedUp;
	public bool isInvisible;
	public bool isTiming;

	void Start () {
		isHeal = false;
		isSpeedUp = false;
		isInvisible = false;
		type = 1;
		spawnTime = 10;
		powerUpTime = 3;
		healUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		speedUpUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		invisibleUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
	}

	void Update () {
		TouchPotions ();
		spawnPotions ();
	}

	void TouchPotions()
	{
		//do a check when only potion appears;
		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			RaycastHit2D hit = Physics2D.Raycast(wp, Vector2.zero);
			if (hit.collider != null)
			{
				if(hit.collider.name == "Heal(Clone)")
				{
					if(isHeal == false)
					{
						healUI.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p1Clone);
						isHeal = true;
					}
				}
				else if(hit.collider.name == "SpeedUp(Clone)")
				{
					if(isSpeedUp == false)
					{
						speedUpUI.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p2Clone);
						isSpeedUp = true;
					}
				}
				else if(hit.collider.name == "Invisible(Clone)")
				{
					if(isInvisible == false)
					{
						invisibleUI.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p3Clone);
						isInvisible = true;
					}
				}
			}
		}
	}

	void beginTimer()
	{
		if(isTiming)
		{
			powerUpTime -= Time.deltaTime;
		}
		if(powerUpTime <= 0)
		{
			isTiming = false;
			powerUpTime = 10;
		}
	}

	public void heal()
	{
		if(isHeal == true)
		{
			Heart.fillAmount += (1/3f);
			healUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		}
		isHeal = false;
	}

	public void speedUp()
	{
		if(isSpeedUp == true)
		{
			//player speed increase
			speedUpUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		}
		isSpeedUp = false;
	}

	public void invisible()
	{
		if(isInvisible == true)
		{
			//player no collision
			invisibleUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		}
		isInvisible = false;
	}

	void spawnPotions()
	{
		spawnTime -= Time.deltaTime;

		if (spawnTime <= 0) 
		{
			spawnTime = 10;
			type = Random.Range (1, 4);
			potionType();
		}
	}

	void potionType()
	{
		float x = Random.Range (0.5f, 1f);
		float y = Random.Range (0.1f, 0.5f);
		Vector3 pos = new Vector3 (x, y, 10);
		pos = Camera.main.ViewportToWorldPoint (pos);
		switch(type)
		{
			case 1:
				p1Clone = Instantiate(p1, pos, Quaternion.identity)as GameObject;
				break;
			case 2:
				p2Clone = Instantiate(p2, pos, Quaternion.identity)as GameObject;
				break;
			case 3:
				p3Clone = Instantiate(p3, pos, Quaternion.identity)as GameObject;
				break;
		}
	}
}
