using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour 
{
	void Start () {
	}
	void Update () {
	}

	public void startGame()
	{
		Application.LoadLevel(1);
	}

	public void loadMenu()
	{
		Application.LoadLevel (0);
	}
	public void exitGame()
	{
		Application.Quit();
	}
}
