using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class generateMaps : MonoBehaviour {

	public GameObject[] availableMaps;
	public List<GameObject> currentMap;

	private float screenWidthInPoints;

	// Use this for initialization
	void Start () 
	{
		float height = 2.0f * Camera.main.orthographicSize;
		screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void FixedUpdate()
	{
		GenerateMapIfRequired ();
	}

	void AddMap(float furthestMapEndX)
	{
		int randomMapIndex = Random.Range(0, availableMaps.Length);

		GameObject Map = (GameObject)Instantiate(availableMaps[randomMapIndex]);

		float mapWidth = Map.transform.FindChild("BottomBorder").localScale.x;

		float mapCenter = furthestMapEndX + mapWidth * 0.5f;

		Map.transform.position = new Vector3(mapCenter, 0, 0);

		currentMap.Add(Map);         
	}

	void GenerateMapIfRequired()
	{
		List<GameObject> mapsToRemove = new List<GameObject>();

		bool addMaps = true;        

		float playerX = transform.position.x;

		float removeMapX = playerX - screenWidthInPoints;        

		float addMapX = playerX + screenWidthInPoints;

		float furthestMapEndX = 0;
		
		foreach(var map in currentMap)
		{
			float mapWidth = map.transform.FindChild("BottomBorder").localScale.x;
			float mapStartX = map.transform.position.x - (mapWidth * 0.5f);    
			float mapEndX = mapStartX + mapWidth;                            

			if (mapStartX > addMapX)
			{
				addMaps = false;
			}

			if (mapEndX < removeMapX)
			{
				addMaps = true;
				mapsToRemove.Add(map);
			}

			furthestMapEndX = Mathf.Max(furthestMapEndX, mapEndX);
		}

		foreach(var map in mapsToRemove)
		{
			currentMap.Remove(map);
			Destroy(map);            
		}

		if (addMaps) 
		{
			AddMap (furthestMapEndX);
		}
	}
}
