using UnityEngine;
using System.Collections;

public class followCamera : MonoBehaviour {

	public GameObject target;
	private float distanceToTarget;

	// Use this for initialization
	void Start () {

		distanceToTarget = transform.position.x - target.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float targetObjectX = target.transform.position.x;
		
		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;    	
	}
}
