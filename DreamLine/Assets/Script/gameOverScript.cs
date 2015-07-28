using UnityEngine;
using System.Collections;

public class gameOverScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void Restart()
	{
		Application.LoadLevel (1);
	}

	public void Menu()
	{
		Application.LoadLevel (0);
	}
}
