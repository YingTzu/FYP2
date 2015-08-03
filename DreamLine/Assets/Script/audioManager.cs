using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour {

	static audioManager instance;

	public AudioClip[] BGMlist;

	private bool soundPlaying = false;
	private string loadedLevelName_temp;

	enum songName
	{
		ClaudioTheWorm,
		DancingonGreenGrass,
		BubbleBath
	};

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
		loadedLevelName_temp = Application.loadedLevelName;
	}
	

	void Update () {
		if (loadedLevelName_temp != Application.loadedLevelName)
		{
			soundPlaying = false;
		}
		else
		{
			loadedLevelName_temp = Application.loadedLevelName;
		}

	

		if (!soundPlaying)
		{
			switch(Application.loadedLevelName)
			{
			case "Menu":
			{
				playSong((int)songName.ClaudioTheWorm);
			}
				break;

			case "Endless":
			{
				playSong((int)songName.DancingonGreenGrass);
			}
				break;

			case "TwoPlayer":
			{
				playSong((int)songName.DancingonGreenGrass);
			}
				break;

			case "Gameover":
			{
				playSong((int)songName.BubbleBath);
			}
				break;

			default:
				break;

			}
			soundPlaying = true;
		}
	
	}

	void playSong(int songName, bool isLooping = true)
	{
		if (GetComponent<AudioSource> ().clip != BGMlist [songName]) 
		{
			GetComponent<AudioSource>().clip = BGMlist[songName];
			GetComponent<AudioSource>().loop = isLooping;
			GetComponent<AudioSource>().Play ();
		}
	}


}
