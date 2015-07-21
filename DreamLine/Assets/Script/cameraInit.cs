using UnityEngine;
using System.Collections;

public class cameraInit : MonoBehaviour 
{
	void Start () 
	{
		this.GetComponent<Camera>().aspect = 1280f / 800f;
	}

	void Update () {}
}