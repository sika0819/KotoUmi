using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Text))]
[AddComponentMenu("GameObject/UI/Effect/TypeWriter")]
public class TypeWriterEffect : MonoBehaviour {
	public UnityEvent FinishEvent;//结束回调事件
	public int charsPerSecond = 5;//每秒字符数
	private Text showTextBox;//文字显示框
	private string showWords;//需要显示的文字
	private bool isActive=false;//是否激活
	private float Timer;//计时器
	// Use this for initialization
	void Start () {
		if (FinishEvent == null) {
			FinishEvent = new UnityEvent ();
		}
		showTextBox = GetComponent<Text> ();
		showWords = showTextBox.text;
		showTextBox.text = string.Empty;
		charsPerSecond = Mathf.Max (1, charsPerSecond);
		isActive = true;
	}
	void ReloadText(){
		isActive = true;
		showWords = showTextBox.text;
	}
	// Update is called once per frame
	void Update () {
		OnStartWriter ();
	}
	public void OnStart()
	{
		ReloadText ();
		isActive = true;
	}
	public void OnStartWriter()
	{
		if (isActive) {
			int readLength = (int)(charsPerSecond * Timer);
			Timer+=Time.deltaTime;
			if (readLength <= showWords.Length) {
				showTextBox.text = showWords.Substring (0, readLength);
			} else {
				OnFinish ();
			}
		}
	}

	public void OnFinish()
	{
		isActive = false;
		Timer = 0;
		showTextBox.text = showWords;
		try{
			FinishEvent.Invoke();
		}catch(Exception e) {
			Debug.Log ("出问题了！:"+e.ToString());
		}
	}

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("点击");
        OnFinish();
    }
}
