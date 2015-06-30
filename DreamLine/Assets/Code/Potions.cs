using UnityEngine;
using System.Collections;

public class Potions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches)
		{
			switch(touch.phase)
			{
				case TouchPhase.Began:
				{
					if(this.GetComponent<GUITexture>().HitTest(touch.position) == true)
						this.GetComponent<GUITexture>().enabled = false;
				}break;
					
				case TouchPhase.Ended:
				{
				}break;
			}
		}
	}
}
