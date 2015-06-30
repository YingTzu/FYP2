using UnityEngine;
using System.Collections;

public class exitGame : MonoBehaviour {
	// detect if quit menu is showing or not
	public static bool exitScreen = false;
	
	void OnEnable()
	{
		exitScreen = true;
	}
	
	void OnDisable()
	{
		exitScreen = false;
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
		{
			if (hit.collider.tag == "Yes" )
			{
				Application.Quit();
			}
			
//			else if (hit.collider.tag == "No")
//			{
//				Destroy( this.gameObject );
//				
//				if (PauseButton != null)
//				{
//					if ( PauseButton.m_PauseGame == false )
//						Time.timeScale = PauseButton.m_timeScaleTracker;
//				}
//			}
		}
	}
}
