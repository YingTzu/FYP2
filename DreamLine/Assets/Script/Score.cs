using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
	public int distance;
	public int latestDistance;
	public static int life;
	void Start () {
	}

	void Update () {
		life = playerControl.life;
		if (life == 0) 
		{
			distance = 0;
		}
		else{
			distance++;
			this.gameObject.GetComponent<Text>().text = "Score: " + distance;
		}
	}
}
