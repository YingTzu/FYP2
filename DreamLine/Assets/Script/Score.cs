using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
	public static int distance;
	public int latestDistance;
	public Image Heart;
	public Text playerScore;
	public Text highScore;
	void Start () 
	{
		if(Application.loadedLevelName == "Endless")
			distance = 0;
	}

	void Update () 
	{
		if(Application.loadedLevelName == "Endless")
		{
			if (Heart.fillAmount == 0) 
			{
				latestDistance = distance;
				if(distance > PlayerPrefs.GetInt("HighScore"))
					PlayerPrefs.SetInt("HighScore", latestDistance);
			}
			else{
				if(playerControl.movementSpeed == 3)
				{
					distance += 1;
				}
				else if(playerControl.movementSpeed == 6)
				{
					distance +=2;
				}
			}
			this.gameObject.GetComponent<Text>().text = "Score:" + distance;
		}


		if(Application.loadedLevelName == "Gameover")
		{
			playerScore.text = "Your Score: " + distance;
			highScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
		}
	}
}
