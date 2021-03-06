﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Buttons : MonoBehaviour 
{
	public bool optionAppear;
	public bool backButtonAppear;

	public Image optionsPage;
	public Image optionsBack;

	public Button optionsBackButton;

	private GameObject BGMusic;
	private GameObject SFXeffects;

	private GameObject SFXAudio;


	void Start () 
	{
		BGMusic = GameObject.Find ("BGM");
		SFXeffects = GameObject.Find ("SFX");
		
		SFXAudio = GameObject.Find ("SFXaudio");

		optionAppear = false;
		backButtonAppear = false;

		if(Application.loadedLevelName == "Menu")
		{
			optionsPage.enabled = false;
			optionsBack.enabled = false;
			optionsBackButton.enabled = false;

			BGMusic.SetActive(false);
			SFXeffects.SetActive(false);
		}

	}
	void Update () {
	}

	public void startGame()
	{
		if(optionAppear == false && backButtonAppear == false)
		{
			//GetComponent<AudioSource> ().Play ();
			SFXAudio.GetComponent<SFXmanager>().playMenuEffects(0);
			Application.LoadLevel("ModeSelect");
		}
	}

	public void singlePlayer()
	{
		SFXAudio.GetComponent<SFXmanager>().playMenuEffects(0);
		Application.LoadLevel("Endless");
	}

	public void twoPlayer()
	{
		SFXAudio.GetComponent<SFXmanager>().playMenuEffects(0);
		Application.LoadLevel("TwoPlayer");
	}

	public void loadMenu()
	{
		//GetComponent<AudioSource> ().Play ();
		SFXAudio.GetComponent<SFXmanager>().playMenuEffects(0);
		Application.LoadLevel ("Menu");
	}

	public void optionsPageOut()
	{
		if(optionAppear ==  false && backButtonAppear == false)// when button is clicked
		{
			optionsPage.enabled = true;
			optionsBack.enabled = true;
			optionsBackButton.enabled = true;
			//GetComponent<AudioSource> ().Play ();
			SFXAudio.GetComponent<SFXmanager>().playMenuEffects(0);
			optionsPage.GetComponent<CanvasRenderer>().SetAlpha(0.9f);
			optionAppear = true;
			backButtonAppear = true;

			BGMusic.SetActive(true);
			SFXeffects.SetActive(true);
		}

		else if (optionAppear == true)
		{
			optionAppear = false;
			backButtonAppear = false;
			optionsPage.enabled = false;
			optionsBack.enabled = false;
			optionsBackButton.enabled = false;

			BGMusic.SetActive(false);
			SFXeffects.SetActive(false);
		}
	}

	public void optionsPageClose()
	{
		optionAppear = false;
		backButtonAppear = false;
		optionsPage.enabled = false;
		optionsBack.enabled = false;
		optionsBackButton.enabled = false;

		BGMusic.SetActive(false);
		SFXeffects.SetActive(false);

		//GetComponent<AudioSource> ().Play ();
		SFXAudio.GetComponent<SFXmanager>().playMenuEffects(0);
	}

}
