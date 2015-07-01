using UnityEngine;
using System.Collections;

public class menuButtons : MonoBehaviour {

	private GameObject start, exit;
	private bool mousedown = false;

	// Use this for initialization
	void Start () 
	{
		start = GameObject.Find("startButton");
		exit = GameObject.Find("endButton");
	}
	
	// Update is called once per frame
	void Update () 
	{
		#if UNITY_EDITOR
		MouseInput();
		#else
		Touch();
		#endif
	}

	void MouseInput()
	{
		if (mousedown == false)
		{
			if (Input.GetMouseButton(0) == true)
			{
				if (start.GetComponent<GUITexture>().HitTest(Input.mousePosition) == true)
				{
					//start.GetComponent<Animator>().Play("SelectStart");
					Application.LoadLevel(1);
				}
				
				if (exit.GetComponent<GUITexture>().HitTest(Input.mousePosition) == true)
				{
					Application.Quit();
				}
			}
			
			mousedown = true;
		}
		
		if (Input.GetMouseButton(0) == false && mousedown == true)
		{
			mousedown = false;
		}
	}

	void Touch()
	{
		if (Input.touchCount > 0 && mousedown == false) 
		{
			foreach (Touch touch in Input.touches)
			{
				if (start.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					Application.LoadLevel(1);
					//start.GetComponent<Animator>().Play("SelectStart");
				}
								
				if (exit.GetComponent<GUITexture>().HitTest(touch.position) == true)
				{
					Application.Quit();
				}
			}
		}
	}
}
