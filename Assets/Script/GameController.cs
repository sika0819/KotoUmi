using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {
	#region 开始界面
	public Button startBtn;
	public Button loadBtn;
	public Button setBtn;
	public Button exitBtn;
	#endregion
	#region 设置界面
	public GameObject setMenu;
	Animator setAnim;
	public Toggle screenToggle;
	public Toggle autoModeToggle;
	public Slider musicSlider;
	public Slider soundSlider;
	public Button setCloseBtn;
	public Button cgGalleryBtn;
	public Button musicGalleryBtn;
	#endregion
	/// <summary>
	/// 注册一系列按钮事件
	/// </summary>
	void Awake(){
		SaveDataController.Instance.LoadSetting();
		screenToggle.isOn = SaveDataController.Instance.setData.isFull;
		autoModeToggle.isOn = SaveDataController.Instance.setData.isAuto;
		musicSlider.value = SaveDataController.Instance.setData.musicValue;
		soundSlider.value = SaveDataController.Instance.setData.soundValue;
		if (setMenu != null)
			setMenu.SetActive (false);
		//界面按钮
		startBtn.onClick.AddListener (OnStartBtn);
		setBtn.onClick.AddListener (OnSet);
		exitBtn.onClick.AddListener (OnExit);
		setCloseBtn.onClick.AddListener (OnCloseSet);
		//设置功能
		screenToggle.onValueChanged.AddListener (OnFullScreenToggle);
		autoModeToggle.onValueChanged.AddListener (OnAutoToggle);
		musicSlider.onValueChanged.AddListener (OnBGMValue);
		soundSlider.onValueChanged.AddListener (OnSoundValue);
		MusicPlayer.Instance.audioPlayer.Play ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnStartBtn()
	{
		SceneManager.LoadScene ("Game");
	}
	void OnSet()
	{
		if (setMenu != null) {
			setMenu.SetActive (true);
		}

	}
	void OnExit()
	{
		Application.Quit ();
	}
	void OnLoad()
	{
		
	}
	void OnCloseSet()
	{
		SaveDataController.Instance.SaveSetting ();
		if (setMenu != null)
			setMenu.SetActive (false);
	}
	void OnFullScreenToggle(bool isFullScreen)
	{
		GlobalValue.isFullScreen = isFullScreen;
		Screen.fullScreen = isFullScreen;
	}
	void OnAutoToggle(bool isAuto)
	{
		Debug.Log (isAuto);
		GlobalValue.isAuto = isAuto;
	}
	void OnBGMValue(float soundValue)
	{
		GlobalValue.BGMSoundValue = soundValue;
	}
	void OnSoundValue(float soundValue)
	{
		GlobalValue.VoiceSoundValue = soundValue;
		SoundPlayer.Instance.audioPlayer.Play ();
	}
	void OnApplicationQuit()
	{
		SaveDataController.Instance.SaveSetting ();
	}
}
