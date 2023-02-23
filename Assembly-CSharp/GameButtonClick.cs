using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A7 RID: 167
public class GameButtonClick : UIGameObject
{
	// Token: 0x0600038C RID: 908 RVA: 0x0000C54C File Offset: 0x0000A94C
	public void QuickSave()
	{
		Application.CaptureScreenshot(this.filepath + "/0.png", 0);
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		SaveDataManager.GetInstance().SaveDataToDisk(0, true);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x0000C57B File Offset: 0x0000A97B
	private void Start()
	{
		this.Show();
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0000C583 File Offset: 0x0000A983
	public override void Show()
	{
		base.Show();
		this.background.color = new Color(1f, 1f, 1f, Singleton<GameConfigManager>.Instance.config.textAlpha);
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0000C5B9 File Offset: 0x0000A9B9
	private void OnEnable()
	{
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 1f);
	}

	// Token: 0x06000390 RID: 912 RVA: 0x0000C5E1 File Offset: 0x0000A9E1
	public void VoiceRestart()
	{
		ScriptExecute.GetInstance().GetLastHistory().voiceScript.CreateAction().FinishAction();
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0000C5FC File Offset: 0x0000A9FC
	public void QuickLoad()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		SaveData saveData = SaveDataManager.GetInstance().GetSaveData(0);
		if (saveData != null)
		{
			Singleton<AVGManager>.Instance.LoadSaveData(saveData);
		}
	}

	// Token: 0x06000392 RID: 914 RVA: 0x0000C630 File Offset: 0x0000AA30
	public void ShowLoad()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("load");
	}

	// Token: 0x06000393 RID: 915 RVA: 0x0000C64B File Offset: 0x0000AA4B
	public void ShowSave()
	{
		Application.CaptureScreenshot(this.filepath + "/test.png", 0);
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("save");
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0000C67C File Offset: 0x0000AA7C
	public void ShowSetting()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("config");
	}

	// Token: 0x06000395 RID: 917 RVA: 0x0000C697 File Offset: 0x0000AA97
	public void ShowHistory()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("history");
	}

	// Token: 0x06000396 RID: 918 RVA: 0x0000C6B2 File Offset: 0x0000AAB2
	public void AutoButton()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<AVGManager>.Instance.IsAuto = true;
	}

	// Token: 0x06000397 RID: 919 RVA: 0x0000C6C9 File Offset: 0x0000AAC9
	public void SkipButton()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		GameConfigManager.ChangeSkipMode();
	}

	// Token: 0x06000398 RID: 920 RVA: 0x0000C6DA File Offset: 0x0000AADA
	public void MetaButton()
	{
		Singleton<BGMManager>.Instance.SetMute();
		Singleton<SEManager>.Instance.SetMute();
		Singleton<SystemSoundManager>.Instance.SetMute();
		Singleton<VoiceManager>.Instance.SetMute();
	}

	// Token: 0x06000399 RID: 921 RVA: 0x0000C704 File Offset: 0x0000AB04
	public void HideButton()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		this.ChangeActiveStatus();
	}

	// Token: 0x0600039A RID: 922 RVA: 0x0000C716 File Offset: 0x0000AB16
	public void HideText()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.TextHide);
		Singleton<UIManager>.Instance.HideUi("text");
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0000C732 File Offset: 0x0000AB32
	public bool GetStatus()
	{
		return base.gameObject.activeSelf;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x0000C73F File Offset: 0x0000AB3F
	public void ChangeActiveStatus()
	{
		base.gameObject.SetActive(!base.gameObject.activeSelf);
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0000C75A File Offset: 0x0000AB5A
	public void ChangeAlpha(float s)
	{
		this.background.color = new Color(1f, 1f, 1f, s);
		Singleton<GameConfigManager>.Instance.config.textAlpha = s;
	}

	// Token: 0x04000236 RID: 566
	public Image background;

	// Token: 0x04000237 RID: 567
	public CanvasGroup canvasGroup;

	// Token: 0x04000238 RID: 568
	private string filepath = Application.dataPath + "/save";

	// Token: 0x04000239 RID: 569
	public GameObject icon;
}
