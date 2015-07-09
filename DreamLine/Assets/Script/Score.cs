using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public int distance;
	public int latestDistance;
	public static int life;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		life = playerControl.life;
		if (life == 0) 
		{
			distance = 0;
		}
		else{
			distance++;
			this.gameObject.guiText.text = "Scroe: " + distance;
		}
	}
}
