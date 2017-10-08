using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
public enum DataType
{
    Dialog,
    Content,
    Choice
}
public struct Dialog
{//对话
    public string Name;//姓名
    public string TextContent;//说话内容
}
public struct Content
{//描写
    public string TextContent;
}
public struct Choice
{//选择支
    public List<string> choiceName;//选择名字
}

[Serializable]
public class TextData
{
    public int charNum;//章节数
    public int id;//唯一序号
    public DataType dataType;//文字类型
    public string Name;
    public string TextContent;
}

public class SaveDataController{
	public string savePath=Application.dataPath+"/";
	public string saveName="Game.data";
	public string settingName="config.data";
	public XmlDocument scriptDoc;//剧情脚本
	public SettingData setData=new SettingData();
	public List<KeyValuePair<int,TextData>> textDataList=new List<KeyValuePair<int, TextData>>();//剧情存档
	public static SaveDataController Instance{
		get{ 
			if(_instance==null) {
				_instance = new SaveDataController();
			} 
			return _instance;
		}
	}
	private static SaveDataController _instance;
	[Serializable]
	public class SettingData{
		public bool isFull = false;
		public bool isAuto = false;
		public float musicValue=1;
		public float soundValue=1;
	}
    
	public void SaveSetting(){
		FileStream fileStream = new FileStream (savePath + settingName, FileMode.OpenOrCreate);
		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (fileStream, setData);
		Debug.Log ("是否全屏："+setData.isFull);
		Debug.Log ("是否自动："+setData.isAuto);
		Debug.Log ("音乐：" + setData.musicValue);
		Debug.Log ("音效：" + setData.musicValue);
		fileStream.Close ();
	}
	public void LoadSetting(){
		if (File.Exists (savePath + settingName)) {
			FileStream fileStream = new FileStream (savePath + settingName, FileMode.Open,FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter ();
			setData = bf.Deserialize (fileStream) as SettingData;
			GlobalValue.isAuto = setData.isAuto;
			GlobalValue.isFullScreen = setData.isFull;
			GlobalValue.BGMSoundValue = setData.musicValue;
			GlobalValue.VoiceSoundValue = setData.soundValue;
//			Debug.Log ("是否全屏："+setData.isFull);
//			Debug.Log ("是否自动："+setData.isAuto);
//			Debug.Log ("音乐：" + setData.musicValue);
//			Debug.Log ("音效：" + setData.musicValue);
			fileStream.Close ();
		}
	}
    public void SaveData() {

    }
	public void SaveText()
	{
		FileStream fileStream = new FileStream (savePath + saveName, FileMode.OpenOrCreate);
		BinaryFormatter bf = new BinaryFormatter ();
		bf.Serialize (fileStream, textDataList);//剧情列表
		fileStream.Close ();
	}
	public void LoadText()
	{
		if (File.Exists (savePath + saveName)) {
			FileStream fileStream = new FileStream (savePath + saveName, FileMode.Open,FileAccess.Read);
			BinaryFormatter bf = new BinaryFormatter ();
			textDataList = bf.Deserialize (fileStream) as List<KeyValuePair<int,TextData>>;

			fileStream.Close ();
		}
	}
}
