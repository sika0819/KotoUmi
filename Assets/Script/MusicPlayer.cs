using UnityEngine;
using System.Collections;

public class MusicPlayer : Singleton<MusicPlayer>{
	public AudioPlayer audioPlayer;
	void Awake()
	{
		audioPlayer = new AudioPlayer (gameObject);
		audioPlayer.isLoop = true;
		audioPlayer.Stop ();
		DontDestroyOnLoad (gameObject);
	}
}
