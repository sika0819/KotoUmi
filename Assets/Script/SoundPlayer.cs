using UnityEngine;
using System.Collections;

public class SoundPlayer :Singleton<SoundPlayer>{
	public AudioPlayer audioPlayer;
	void Awake()
	{
		audioPlayer=new AudioPlayer(gameObject);
		audioPlayer.isLoop = false;
		audioPlayer.Stop ();
		DontDestroyOnLoad (gameObject);
	}
}
