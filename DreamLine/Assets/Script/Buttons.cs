using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour 
{
	public bool optionAppear;
	public Image options;

	void Start () 
	{
		optionAppear = false;
		if(Application.loadedLevelName == "Menu")
			options.enabled = false;
	}
	void Update () {
	}

	public void startGame()
	{
		if(optionAppear == false)
		{
			GetComponent<AudioSource> ().Play ();
			Application.LoadLevel(1);
		}
	}

	public void loadMenu()
	{
		GetComponent<AudioSource> ().Play ();
		Application.LoadLevel (0);
	}

	public void optionsPageOut()
	{
		if(optionAppear ==  false)
		{
			options.enabled = true;
			GetComponent<AudioSource> ().Play ();
			options.GetComponent<CanvasRenderer>().SetAlpha(0.9f);
			optionAppear = true;
		}

		else if (optionAppear == true)
		{
			optionAppear = false;
			options.enabled = false;
		}
	}

}
