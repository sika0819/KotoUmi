using UnityEngine;
using System.Collections;

public class AudioPlayer{
	public GameObject audioGameObject;
	public AudioSource MusicSource;//音乐
	public AudioPlayer(GameObject playObject)
	{
		audioGameObject = playObject;
		MusicSource = audioGameObject.GetComponent<AudioSource> ();
		if (!MusicSource) {
			audioGameObject.AddComponent<AudioSource> ();
		}
		MusicSource = audioGameObject.GetComponent<AudioSource> ();
	}
	public bool playOnAwake{
		get{ 
			return MusicSource.playOnAwake;
		}
		set{ 
			MusicSource.playOnAwake = value;
		}
	}
	public bool isLoop{
		get{ 
			return MusicSource.loop;
		}set{ 
			MusicSource.loop = value;
		}
	}
	public float volume{
		get{ 
			return MusicSource.volume;
		}set{ 
			MusicSource.volume = value;
		}
	}
	public bool isPausing
	{
		set{ 
			if (value) {
				Pause ();
			} else {
				UnPause ();
			}
		}
	}
	public void Play()
	{
		MusicSource.Play ();
	}
	void Pause()
	{
		MusicSource.Pause ();
	}
	void UnPause()
	{
		MusicSource.UnPause ();
	}
	public void Stop()
	{
		MusicSource.Stop ();
	}
}
