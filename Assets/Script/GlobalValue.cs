using UnityEngine;
using System.Collections;
using System;
public static class GlobalValue{
	//全局变量。要在多个场景使用。
	public static bool isFullScreen{
		get{ 
			return _isFull;
		}set{ 
			_isFull = value;
			SaveDataController.Instance.setData.isFull = value;
		}
	}
	private static bool _isFull=true;

	public static bool isAuto{
		get{ 
			return _isAuto;
		}set{ 
			_isAuto = value;
			SaveDataController.Instance.setData.isAuto = value;
		}
	}
	private static bool _isAuto=true;
	public static float BGMSoundValue{
		get{ 
			return _bgmValue;
		}set{ 
			MusicPlayer.Instance.audioPlayer.volume = value;
			SaveDataController.Instance.setData.musicValue = value;
			_bgmValue = value;
		}
	}
	private static float _bgmValue=1;
	public static float VoiceSoundValue{
		get{ 
			return _voiceValue;
		}set{ 
			SoundPlayer.Instance.audioPlayer.volume = value;
			SaveDataController.Instance.setData.soundValue = value;
			_voiceValue = value;
		}
	}
	private static float _voiceValue=1;
	public static float TextSpeed=0;
}
