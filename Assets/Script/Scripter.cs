using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]
public class Scripter : Singleton<Scripter> {
    string DBName = "avg";
	void Awake()
	{
        DontDestroyOnLoad(gameObject);
        string path = "URI=file:" + Application.streamingAssetsPath + "/" + DBName + ".db";
        DB.Instance.Open(path);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   
}
