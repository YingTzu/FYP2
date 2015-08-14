using UnityEngine;
using System.Collections;

public class SFXmanager : MonoBehaviour {

	static SFXmanager instance;
	
	public AudioClip[] menuSFXlist, gameSFXlist;

	void Awake()
	{
		if(instance)
		{
			Destroy (gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playMenuEffects (int menuEffectsName)
	{
		GetComponent<AudioSource>().PlayOneShot(menuSFXlist[menuEffectsName]);
	}
	
	public void playGameEffects (int gameEffectsName)
	{
		GetComponent<AudioSource>().PlayOneShot(gameSFXlist[gameEffectsName]);
	}
}
