using UnityEngine;
using UnityEditor;
using NUnit.Framework;

[CustomEditor(typeof(Scripter))]
[System.Serializable]
public class ScripterInspector:Editor {
	private static int m_ViewMode=0;
	private static string[] m_menuItem={"Actions","Edit Text","Xml"};
	public static TextAsset m_TxtAsset;//文本资源
	public static string m_NameDelimter="<";
	public static bool m_showAllToggle;
	private static MusicPlayer musicPlayer;//音乐播放器
	private static SoundPlayer soundPlayer;//音效播放器
	private static string[] m_BGMEntries;
	private static string[] m_SEEntries;
	private static string[] m_voiceEntries;
	public static string[] bgmEntries
	{
		get{ 
			return m_BGMEntries;
		}
	}
	public static string[] seEntries
	{
		get{ 
			return m_SEEntries;
		}
	}
	public static string[] voiceEntries
	{
		get{ 
			return m_voiceEntries;
		}
	}
	void OnEnable()
	{
		musicPlayer = MusicPlayer.Instance;
		soundPlayer = SoundPlayer.Instance;
	}
	public override void OnInspectorGUI ()
	{
		serializedObject.Update ();
		Scripter targetNode = target as Scripter;

	}
	public static void DrawNameField(string CharName)
	{
	
	}
}
