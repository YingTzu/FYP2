using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
	public int distance;
	public int latestDistance;
	public Image Heart;
	void Start () {
	}

	void Update () {
		if (Heart.fillAmount == 0) 
		{
			latestDistance = distance;
		}
		else{
			distance++;
			this.gameObject.GetComponent<Text>().text = "Score: " + distance;
		}
	}
}
