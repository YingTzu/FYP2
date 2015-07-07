﻿using UnityEngine;
using System.Collections;

public class backgroundScrolling : MonoBehaviour {

	public float speed = 0.2f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 offset = new Vector2 (Time.time * speed, 0);

		renderer.material.mainTextureOffset = offset;
	}
}
