using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200008C RID: 140
public class UIManager : Singleton<UIManager>
{
	// Token: 0x060002DF RID: 735 RVA: 0x0000A5D8 File Offset: 0x000089D8
	private void Awake()
	{
		this.addUI("main", "main_menu");
		this.addUI("config", "ConfigUi");
		this.addUI("history", "history");
		this.addUI("load", "LoadCanvas");
		this.addUI("save", "SaveCanvas");
		this.addUI("text", "text_ui");
		this.addUI("select", "select_ui");
		this.addUI("extra_movie", "MovieUI");
		this.addUI("extra_gallery", "GalleryUI");
		this.addUI("extra_music", "MusicUI");
		this.addUI("new_main", "demo_main_menu");
		TextLayoutManager.GetInstance().InitAllTextLayout();
		SelectLayoutManager.GetInstance().InitAllSelectLayout();
		this.GetTextIcon();
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0000A6B0 File Offset: 0x00008AB0
	private void Start()
	{
		foreach (KeyValuePair<string, UIGameObject> keyValuePair in this.dict)
		{
			keyValuePair.Value.gameObject.SetActive(false);
		}
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0000A718 File Offset: 0x00008B18
	private void GetTextIcon()
	{
		this.textIcon = this.GetUi("text").GetComponent<GameButtonClick>().icon;
		this.textIcon.SetActive(false);
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0000A741 File Offset: 0x00008B41
	public void ShowTextIcon()
	{
		this.textIcon.SetActive(true);
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0000A74F File Offset: 0x00008B4F
	public void HideTextIcon()
	{
		this.textIcon.SetActive(false);
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0000A760 File Offset: 0x00008B60
	public void HideAllUi()
	{
		this.restorUIDict.Clear();
		foreach (KeyValuePair<string, UIGameObject> keyValuePair in this.dict)
		{
			this.restorUIDict.Add(keyValuePair.Key, keyValuePair.Value.gameObject.activeSelf);
			keyValuePair.Value.gameObject.SetActive(false);
		}
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x0000A7F8 File Offset: 0x00008BF8
	public void RestoreUi()
	{
		foreach (KeyValuePair<string, UIGameObject> keyValuePair in this.dict)
		{
			keyValuePair.Value.gameObject.SetActive(this.restorUIDict[keyValuePair.Key]);
		}
		this.restorUIDict.Clear();
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x0000A87C File Offset: 0x00008C7C
	public UIGameObject GetUi(string name)
	{
		if (this.dict.ContainsKey(name))
		{
			return this.dict[name];
		}
		return null;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x0000A8A0 File Offset: 0x00008CA0
	private void addUI(string name, string path)
	{
		UIGameObject uigameObject = UnityEngine.Object.Instantiate<UIGameObject>(Resources.Load<UIGameObject>("prefab/" + path));
		uigameObject.gameObject.transform.SetParent(base.gameObject.transform, false);
		this.dict.Add(name, uigameObject);
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x0000A8EC File Offset: 0x00008CEC
	public void SetItem(string name, UIGameObject o)
	{
		o.gameObject.transform.SetParent(base.gameObject.transform, false);
		if (this.dict.ContainsKey(name))
		{
			this.dict[name] = o;
		}
		else
		{
			this.dict.Add(name, o);
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x0000A948 File Offset: 0x00008D48
	public void NeedShowUi(string str)
	{
		if (this.dict.ContainsKey(str))
		{
			UIGameObject uigameObject = this.dict[str];
			if (!uigameObject.gameObject.activeSelf)
			{
				uigameObject.Show();
			}
		}
	}

	// Token: 0x060002EA RID: 746 RVA: 0x0000A989 File Offset: 0x00008D89
	public void ShowUi(string str)
	{
		if (str == "text")
		{
			Debug.Log("Text show UI");
		}
		if (this.dict.ContainsKey(str))
		{
			this.dict[str].Show();
		}
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0000A9C7 File Offset: 0x00008DC7
	public void HideUi(string str)
	{
		if (this.dict.ContainsKey(str))
		{
			this.dict[str].Hide();
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0000A9EB File Offset: 0x00008DEB
	public int UIStatus(string str)
	{
		if (this.dict.ContainsKey(str))
		{
			return (!this.dict[str].isActive()) ? 0 : 1;
		}
		return -1;
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0000AA1D File Offset: 0x00008E1D
	public void SetFlag(bool flag)
	{
		this.allowQuitting = flag;
	}

	// Token: 0x060002EE RID: 750 RVA: 0x0000AA26 File Offset: 0x00008E26
	public bool GetUiStatus(string str)
	{
		return this.dict.ContainsKey(str) && this.dict[str].gameObject.activeSelf;
	}

	// Token: 0x060002EF RID: 751 RVA: 0x0000AA51 File Offset: 0x00008E51
	public void SetUiStatus(string str, bool b)
	{
		if (this.dict.ContainsKey(str))
		{
			this.dict[str].gameObject.SetActive(b);
		}
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x0000AA7C File Offset: 0x00008E7C
	private void OnApplicationQuit()
	{
		CGSaveDataManager.GetInstance().Serializer();
		BgmSaveDataManager.GetInstance().Serializer();
		MovieSaveDataManager.GetInstance().Serializer();
		DataSaveManager.GetInstance().SaveAllDataToFile();
		if (!this.allowQuitting)
		{
			Application.CancelQuit();
		}
		if (GameObject.Find("exit_dialog") == null)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("prefab/exit_game"));
			gameObject.name = "exit_dialog";
		}
	}

	// Token: 0x040001E2 RID: 482
	private bool allowQuitting;

	// Token: 0x040001E3 RID: 483
	private Dictionary<string, UIGameObject> dict = new Dictionary<string, UIGameObject>();

	// Token: 0x040001E4 RID: 484
	private Dictionary<string, bool> restorUIDict = new Dictionary<string, bool>();

	// Token: 0x040001E5 RID: 485
	private GameObject textIcon;
}
