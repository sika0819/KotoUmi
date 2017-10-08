using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[ExecuteInEditMode]
public class UIController : Singleton<UIController> {
	#region 对话框
	public GameObject Dialog;
    public Text NameTextBox;
    public Text ScriptTextBox;

	private string m_NameHndName="NameText";
	private string m_ScriptHndName= "ScriptTextBox";

	#endregion
	#region 长段描写或者历史记录。
	public GameObject LongText;//大段描写
    public Text LongTextBox;
    #endregion
    #region 选择
    public GameObject Choice;
    public GameObject ChoiceBtn;
    #endregion
    // Use this for initialization
    void Start () {
		if (GameObject.Find (m_NameHndName)) {
			NameTextBox = GameObject.Find (m_NameHndName).GetComponent<Text> ();
		}
		if (GameObject.Find (m_ScriptHndName)) {
			ScriptTextBox = GameObject.Find (m_ScriptHndName).GetComponent<Text> ();
		}
        if (LongText != null) {
            LongTextBox = LongText.GetComponentInChildren<Text>();
        }
	}
    public void ShowText(TextData textData)
    {
        switch (textData.dataType)
        {
            case DataType.Dialog:
                Dialog.SetActive(true);
                LongText.SetActive(false);
                Choice.SetActive(false);
                NameTextBox.text = textData.Name;
                ScriptTextBox.text = textData.TextContent;
                break;
            case DataType.Content:
                LongText.SetActive(true);
                Choice.SetActive(false);
                Dialog.SetActive(false);
                LongTextBox.text = textData.TextContent;
                GameObject[] choiceBtn = GameObject.FindGameObjectsWithTag("choice");
                for (int i = choiceBtn.Length-1; i >= 0; i--)
                {
                    Destroy(choiceBtn[i]);
                }
                break;
            case DataType.Choice:
                Choice.SetActive(true);
                LongText.SetActive(false);
                Dialog.SetActive(false);
                string[] choiceArray = textData.TextContent.Split('\n');
                for (int i = 0; i < choiceArray.Length; i++) {
                    GameObject tempChoice= Instantiate<GameObject>(ChoiceBtn);
                    tempChoice.GetComponentInChildren<Text>().text = choiceArray[i];
                }
                break;
        }
    }
}
