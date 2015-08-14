using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PotionManager : MonoBehaviour {
	
	public GameObject p1, p2, p3, p4, p5, p6;
	public GameObject p1Clone, p2Clone, p3Clone, p4Clone, p5Clone, p6Clone;
	public GameObject player;
	public GameObject player2;

	public Button healUI;
	public Button speedUpUI;
	public Button invisibleUI;

	public Button healUI2;
	public Button speedUpUI2;
	public Button invisibleUI2;

	public Image Heart;
	public Image Heart2;
	
	public int type;
	public float spawnTime;
	public float powerUpTime;

	private float playerSpeed;
	private float playerSpeed2;
	
	public bool isHeal;
	public bool isSpeedUp;
	public bool isInvisible;
	public bool isTiming;
	public bool isHealSpawn;
	public bool isSpeedUpSpawn;
	public bool isInvisibleSpawn;

	void Start () 
	{
		isHeal = false;
		isSpeedUp = false;
		isInvisible = false;
		isHealSpawn = false;
		isSpeedUpSpawn = false;
		isInvisibleSpawn = false;
	
		type = 1;

		spawnTime = 15;
		powerUpTime = 5;

		playerSpeed = PlayerMovement.playerSpeed;
		playerSpeed = PlayerMovement.playerSpeed2;

		healUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		speedUpUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		invisibleUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);

		if(Application.loadedLevelName == "TwoPlayer")
		{
			healUI2.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
			speedUpUI2.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
			invisibleUI2.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		}
	}

	void Update () {
		TouchPotions ();
		spawnPotions ();
		beginTimer ();
		destoryPotions ();
	}

	void spawnPotions()
	{
		spawnTime -= Time.deltaTime;
		
		if (spawnTime <= 0) 
		{
			spawnTime = 15;
			type = Random.Range (1, 4);
			potionType();
		}
	}

	void potionType() //random spawn potion
	{
		if(Application.loadedLevelName == "Endless")
		{
			float x = Random.Range (0.8f, 1f);
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
		else if(Application.loadedLevelName == "TwoPlayer")
		{
			float x = Random.Range (0.8f, 1f);
			float y = Random.Range (0.1f, 0.5f);
			float y2 = Random.Range (1.2f, 2.0f);

			Vector3 pos = new Vector3 (x, y, 10);
			pos = Camera.main.ViewportToWorldPoint (pos);

			Vector3 pos2 = new Vector3 (x, y2, 10);
			pos2 = Camera.main.ViewportToWorldPoint (pos2);

			switch(type)
			{
			case 1:
				p1Clone = Instantiate(p1, pos, Quaternion.identity)as GameObject;
				p4Clone = Instantiate(p4, pos2, Quaternion.identity)as GameObject;
				isHealSpawn = true;
				break;
			case 2:
				p2Clone = Instantiate(p2, pos, Quaternion.identity)as GameObject;
				p5Clone = Instantiate(p5, pos2, Quaternion.identity)as GameObject;
				isSpeedUpSpawn = true;
				break;
			case 3:
				p3Clone = Instantiate(p3, pos, Quaternion.identity)as GameObject;
				p6Clone = Instantiate(p6, pos2, Quaternion.identity)as GameObject;
				isInvisibleSpawn = true;
				break;
			}
		}
	}

	void TouchPotions()
	{	
		for(int i = 0; i < Input.touchCount; i++)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			RaycastHit2D hit = Physics2D.Raycast(wp, -Vector2.up, Mathf.Infinity);
			if (hit.collider != null)
			{
				if(hit.collider.name == "Heal(Clone)")
				{
					if(isHeal == false)
					{
						healUI.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p1Clone);
						Destroy(p4Clone);
						isHeal = true;
						isHealSpawn = false;
					}
				}
				if(hit.collider.name == "2PHeal(Clone)")
				{
					if(isHeal == false)
					{
						healUI2.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p1Clone);
						Destroy(p4Clone);
						isHeal = true;
						isHealSpawn = false;
					}
				}
				if(hit.collider.name == "SpeedUp(Clone)")
				{
					if(isSpeedUp == false)
					{
						speedUpUI.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p2Clone);
						Destroy(p5Clone);
						isSpeedUp = true;
						isSpeedUpSpawn = false;
					}
				}
				if(hit.collider.name == "2PSpeedUp(Clone)")
				{
					if(isSpeedUp == false)
					{
						speedUpUI2.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p2Clone);
						Destroy(p5Clone);
						isSpeedUp = true;
						isSpeedUpSpawn = false;
					}
				}
				if(hit.collider.name == "Invisible(Clone)")
				{
					if(isInvisible == false)
					{
						invisibleUI.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p3Clone);
						Destroy(p6Clone);
						isInvisible = true;
						isInvisibleSpawn = false;
					}
				}
				if(hit.collider.name == "2PInvisible(Clone)")
				{
					if(isInvisible == false)
					{
						invisibleUI2.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
						Destroy(p3Clone);
						Destroy(p6Clone);
						isInvisible = true;
						isInvisibleSpawn = false;
					}
				}
			}
		}
	}

	public void heal()
	{
		if(isHeal == true && healUI.GetComponent<CanvasRenderer>().GetAlpha() == 1.0f)
		{
			Heart.fillAmount += 1.0f/3.0f;
			healUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
			isHeal = false;
		}
		if(Application.loadedLevelName == "TwoPlayer")
		{
			if(isHeal == true && healUI2.GetComponent<CanvasRenderer>().GetAlpha() == 1.0f)
			{
				Heart2.fillAmount += 1.0f/3.0f;
				healUI2.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
				isHeal = false;
			}
		}
	}

	public void speedUp()
	{
		if(isSpeedUp == true && speedUpUI.GetComponent<CanvasRenderer>().GetAlpha() == 1.0f)
		{
			isTiming = true;
			playerSpeed = 6.0f;
			PlayerMovement.playerSpeed = playerSpeed;
			speedUpUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		}
		if(Application.loadedLevelName == "TwoPlayer")
		{
			if(isSpeedUp == true && speedUpUI2.GetComponent<CanvasRenderer>().GetAlpha() == 1.0f)
			{
				isTiming = true;
				playerSpeed2 = 6.0f;
				PlayerMovement.playerSpeed2 = playerSpeed2;
				speedUpUI2.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
			}
		}
	}

	public void invisible()
	{
		if(isInvisible == true && invisibleUI.GetComponent<CanvasRenderer>().GetAlpha() == 1.0f)
		{
			isTiming = true;
			player.GetComponent<BoxCollider2D>().isTrigger = true;
			player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
			invisibleUI.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
		}
		if(Application.loadedLevelName == "TwoPlayer")
		{
			if(isInvisible == true && invisibleUI2.GetComponent<CanvasRenderer>().GetAlpha() == 1.0f)
			{
				isTiming = true;
				player2.GetComponent<BoxCollider2D>().isTrigger = true;
				player2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
				invisibleUI2.GetComponent<CanvasRenderer>().SetAlpha(0.3f);
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
			isSpeedUp = false;
			isInvisible = false;

			powerUpTime = 5;
			playerSpeed = 3.0f;
			PlayerMovement.playerSpeed = playerSpeed;
			player.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
			player.GetComponent<BoxCollider2D>().isTrigger = false;

			if(Application.loadedLevelName == "TwoPlayer")
			{
				playerSpeed2 = 3.0f;
				PlayerMovement.playerSpeed2 = playerSpeed2;
				player2.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
				player2.GetComponent<BoxCollider2D>().isTrigger = false;
			}
		}
	}

	void destoryPotions()
	{
		if(isHealSpawn == true)
		{
			if(player.transform.position.x - GameObject.Find("Heal(Clone)").transform.position.x > 10)
			{
				Destroy(GameObject.Find("Heal(Clone)"));
				isHealSpawn = false;
			}

			if(player2.transform.position.x - GameObject.Find("2PHeal(Clone)").transform.position.x > 10)
			{
				Destroy(GameObject.Find("2PHeal(Clone)"));
				isHealSpawn = false;
			}

		}
		if(isSpeedUpSpawn == true)
		{
			if(player.transform.position.x - GameObject.Find("SpeedUp(Clone)").transform.position.x > 10)
			{
				Destroy(GameObject.Find("SpeedUp(Clone)"));
				isSpeedUpSpawn = false;
			}
			if(player2.transform.position.x - GameObject.Find("2PSpeedUp(Clone)").transform.position.x > 10)
			{
				Destroy(GameObject.Find("2PSpeedUp(Clone)"));
				isSpeedUpSpawn = false;
			}

		}
		if(isInvisibleSpawn == true)
		{
			if(player.transform.position.x - GameObject.Find("Invisible(Clone)").transform.position.x > 10)
			{
				Destroy(GameObject.Find("Invisible(Clone)"));
				isInvisibleSpawn = false;
			}
			if(player2.transform.position.x - GameObject.Find("2PInvisible(Clone)").transform.position.x > 10)
			{
				Destroy(GameObject.Find("2PInvisible(Clone)"));
				isInvisibleSpawn = false;
			}

		}
	}
}
