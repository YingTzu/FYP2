using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class generateMaps : MonoBehaviour {

	// for maps
	public GameObject[] availableMaps;

	public GameObject[] availableObjects;

	private float screenWidthInPoints;

	// for objects
	public List<GameObject> currentMap;
	public List<GameObject> objects;
	
	public float objectsMinDistance = 5.0f;    
	public float objectsMaxDistance = 10.0f;
	
	public float objectsMinY = -1.4f;
	public float objectsMaxY = 1.4f;

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
		GenerateObjectsIfRequired ();
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

	void AddObject(float lastObjectX)
	{
		int randomIndex = Random.Range(0,availableObjects.Length);

		GameObject obj = (GameObject)Instantiate(availableObjects[randomIndex]);

		float objectPositionX = lastObjectX + Random.Range(objectsMinDistance, objectsMaxDistance);
		float randomY = Random.Range(objectsMinY, objectsMaxY);
		obj.transform.position = new Vector3(objectPositionX,randomY,0); 

		objects.Add(obj);
	}

	void GenerateObjectsIfRequired()
	{
		float playerX = transform.position.x;        
		float removeObjectsX = playerX - screenWidthInPoints;
		float addObjectX = playerX + screenWidthInPoints;
		float furthestObjectX = 0;

		List<GameObject> objectsToRemove = new List<GameObject>();
		
		foreach (var obj in objects)
		{
			float objX = obj.transform.position.x;

			furthestObjectX = Mathf.Max(furthestObjectX, objX);

			if (objX < removeObjectsX)            
				objectsToRemove.Add(obj);
		}

		foreach (var obj in objectsToRemove)
		{
			objects.Remove(obj);
			Destroy(obj);
		}

		if (furthestObjectX < addObjectX)
			AddObject(furthestObjectX);
	}

}
