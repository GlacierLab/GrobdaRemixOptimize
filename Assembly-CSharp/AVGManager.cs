using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;

// Token: 0x0200007C RID: 124
public class AVGManager : Singleton<AVGManager>
{
	// Token: 0x06000243 RID: 579 RVA: 0x00007F48 File Offset: 0x00006348
	protected AVGManager()
	{
	}

	// Token: 0x06000244 RID: 580 RVA: 0x00007F9C File Offset: 0x0000639C
	public BlurOptimized GetBlur()
	{
		if (this.blur == null)
		{
			GameObject gameObject = GameObject.Find("Main Camera");
			this.blur = gameObject.GetComponent<BlurOptimized>();
			if (this.blur == null)
			{
				this.blur = gameObject.AddComponent<BlurOptimized>();
			}
		}
		return this.blur;
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00007FF4 File Offset: 0x000063F4
	public void LoadLogoScript()
	{
		this.avgstatus = AVGStatus.WAIT;
		this.LoadScript("xml/logo", true);
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0000800C File Offset: 0x0000640C
	public void LoadScriptInExtra(string name, bool needReset = true)
	{
		if (needReset)
		{
			Singleton<UIManager>.Instance.HideAllUi();
			this.CanControl = true;
			this.nowScript = null;
			this.nowAction = null;
			Singleton<CGManager>.Instance.UnloadSpriteAsset();
			this.DelectAllLayout();
			this.layoutManager.ResetAllLayout();
			Singleton<AddinManager>.Instance.HideAllAddin();
			Singleton<SEManager>.Instance.StopSE();
			this.lightManager.DestroyAll();
		}
		this.avgstatus = AVGStatus.WAIT;
		this.execute.LoadScriptFromResource(name);
		this.CanControl = true;
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00008092 File Offset: 0x00006492
	public void LoadScript(string name, bool needReset = true)
	{
		if (needReset)
		{
			this.ResetAllLayout();
		}
		this.avgstatus = AVGStatus.WAIT;
		this.execute.LoadScriptFromResource(name);
		this.CanControl = true;
	}

	// Token: 0x06000248 RID: 584 RVA: 0x000080BC File Offset: 0x000064BC
	public void LoadScript()
	{
		this.ResetAllLayout();
		if (!LoadScriptConfig.loadFromSaveData)
		{
			this.execute.LoadScriptFromResource(LoadScriptConfig.LoadPath, LoadScriptConfig.index);
			this.CanControl = true;
		}
		else
		{
			LoadScriptConfig.loadFromSaveData = false;
			this.LoadSaveData(LoadScriptConfig.saveDate);
			this.avgstatus = AVGStatus.WAIT;
		}
	}

	// Token: 0x06000249 RID: 585 RVA: 0x00008112 File Offset: 0x00006512
	public void CleanAllInExtra()
	{
		this.CanControl = false;
		this.DelectAllLayout();
		this.layoutManager.ResetAllLayout();
		this.avgstatus = AVGStatus.UIPAUSE;
		this.execute.ResetExecute();
	}

	// Token: 0x0600024A RID: 586 RVA: 0x0000813E File Offset: 0x0000653E
	public void ExitToMenu()
	{
		this.avgstatus = AVGStatus.PAUSE;
		this.execute.ResetExecute();
		this.ResetAllLayout();
		SceneManager.LoadScene("test");
	}

	// Token: 0x0600024B RID: 587 RVA: 0x00008164 File Offset: 0x00006564
	private void Update()
	{
		if (this.avgstatus == AVGStatus.Movie)
		{
			return;
		}
		if (this.IsPrepare)
		{
			return;
		}
		if (this.CanControl && (this.avgstatus == AVGStatus.ANIMATION || this.avgstatus == AVGStatus.WAIT || this.avgstatus == AVGStatus.PAUSE || this.avgstatus == AVGStatus.TextHide))
		{
			if (GameConfigManager.SkipMode && Input.anyKeyDown)
			{
				GameConfigManager.ChangeSkipMode();
			}
			if (this.IsAuto && Input.anyKeyDown)
			{
				this.IsAuto = false;
			}
			this.CanShowHistory();
			this.CtrlPressMode();
			this.CanHideText();
		}
		switch (this.avgstatus)
		{
		case AVGStatus.WAIT:
			this.waitStatusUpdate();
			break;
		case AVGStatus.PAUSE:
			this.pauseStatusUpdate();
			break;
		case AVGStatus.WAITTIME:
			this.waitTimeStatusUpdate();
			break;
		}
		if (this.avgstatus == AVGStatus.ANIMATION)
		{
			this.animationStatusUpdate();
		}
		if (this.avgstatus == AVGStatus.ANIMATION || this.avgstatus == AVGStatus.WAIT || this.avgstatus == AVGStatus.PAUSE)
		{
			this.layoutManager.UpdateActBgLayout();
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00008298 File Offset: 0x00006698
	private void CanHideText()
	{
		if (this.avgstatus == AVGStatus.TextHide)
		{
			if (Input.anyKeyDown)
			{
				Singleton<UIManager>.Instance.ShowUi("text");
				this.SetAvgStatus(AVGStatus.PAUSE);
			}
		}
		else if (Input.GetMouseButtonDown(1) && Singleton<UIManager>.Instance.UIStatus("text") == 1)
		{
			Singleton<UIManager>.Instance.HideUi("text");
			this.SetAvgStatus(AVGStatus.TextHide);
		}
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0000830C File Offset: 0x0000670C
	public void SetPrepareStatus()
	{
		this.IsPrepare = true;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x00008315 File Offset: 0x00006715
	public void SetStartStatus()
	{
		this.IsPrepare = false;
		this.avgstatus = AVGStatus.WAIT;
	}

	// Token: 0x0600024F RID: 591 RVA: 0x00008325 File Offset: 0x00006725
	private void waitTimeStatusUpdate()
	{
		this.autoTime += Time.deltaTime;
		if (this.autoTime > this.waitTime)
		{
			this.autoTime = 0f;
			this.configActionLayout();
		}
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0000835C File Offset: 0x0000675C
	private void animationStatusUpdate()
	{
		if (this.CanControl && this.CanDown() && this.textSkip)
		{
			TextLayoutManager.GetInstance().FinishAllLayout();
		}
		this.layoutManager.UpdateAllLayout();
		if (this.avgstatus == AVGStatus.ANIMATION && this.layoutManager.checkAllLayoutIsWaiting())
		{
			if (Singleton<GameConfigManager>.Instance.config.IsStepMode)
			{
				this.avgstatus = AVGStatus.PAUSE;
			}
			else
			{
				this.avgstatus = AVGStatus.WAIT;
			}
		}
		this.textSkip = true;
	}

	// Token: 0x06000251 RID: 593 RVA: 0x000083E8 File Offset: 0x000067E8
	private void waitStatusUpdate()
	{
		this.configActionLayout();
	}

	// Token: 0x06000252 RID: 594 RVA: 0x000083F0 File Offset: 0x000067F0
	private void pauseStatusUpdate()
	{
		if (this.IsAuto)
		{
			this.autoTime += Time.deltaTime;
			if (this.autoTime > Singleton<GameConfigManager>.Instance.config.AutoTime && !Singleton<VoiceManager>.Instance.GetPlayStatus())
			{
				this.autoTime = 0f;
				this.configActionLayout();
			}
		}
		else if (this.CanControl && this.CanDown())
		{
			this.configActionLayout();
		}
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00008475 File Offset: 0x00006875
	private void configAnimateLayout()
	{
		while (this.avgstatus == AVGStatus.WAIT)
		{
			this.configActionLayout();
		}
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00008490 File Offset: 0x00006890
	private void configActionLayout()
	{
		this.textSkip = false;
		if (this.nowAction != null)
		{
			this.nowAction.Dispose();
		}
		this.nowAction = this.GetNextAction();
		if (this.nowAction != null)
		{
			this.nowAction.Init();
		}
	}

	// Token: 0x06000255 RID: 597 RVA: 0x000084DC File Offset: 0x000068DC
	public BaseAction GetNextAction()
	{
		this.nowScript = this.execute.GetNextStruct();
		if (this.nowScript == null)
		{
			return null;
		}
		if (this.nowScript.kind == ScriptKind.Pause)
		{
			this.avgstatus = AVGStatus.PAUSE;
			return null;
		}
		return this.nowScript.CreateAction();
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0000852C File Offset: 0x0000692C
	public void HideObject(string name)
	{
		GameObject gameObject = GameObject.Find(name);
		if (gameObject == null)
		{
			return;
		}
		gameObject.SetActive(false);
		this.hides.Add(name, gameObject);
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00008564 File Offset: 0x00006964
	public void ShowObject(string name)
	{
		if (this.hides.ContainsKey(name))
		{
			GameObject gameObject = this.hides[name];
			gameObject.SetActive(true);
			this.hides.Remove(name);
		}
		else
		{
			CreateAction createAction = new CreateAction(name);
			createAction.FinishAction();
		}
	}

	// Token: 0x06000258 RID: 600 RVA: 0x000085B8 File Offset: 0x000069B8
	public SaveData CreateSaveData()
	{
		this.layoutManager.FinishAllLayout();
		SaveData saveData = new SaveData();
		Singleton<BGMManager>.Instance.ConfigSaveData(saveData);
		this.layoutManager.ConfigSaveData(saveData);
		saveData.time = TimeUtil.DateTimeToUnixTimestamp(DateTime.UtcNow);
		this.execute.ConfigSaveData(saveData);
		this.lightManager.CreateSaveData(saveData);
		Singleton<AddinManager>.Instance.ConfigSaveData(saveData);
		return saveData;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x00008624 File Offset: 0x00006A24
	public void LoadSaveData(SaveData data)
	{
		Singleton<BGMManager>.Instance.StopBgm();
		Singleton<SEManager>.Instance.StopSE();
		this.ResetAllLayout();
		Singleton<BGMManager>.Instance.LoadSaveData(data);
		this.execute.LoadSaveData(data);
		this.layoutManager.LoadSaveData(data);
		this.lightManager.LoadSaveData(data);
		Singleton<AddinManager>.Instance.LoadSaveData(data);
		this.execute.ClearHistory();
		this.avgstatus = AVGStatus.WAIT;
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00008697 File Offset: 0x00006A97
	public void SetWaitTimeStatus(float t)
	{
		this.waitTime = t;
		this.avgstatus = AVGStatus.WAITTIME;
	}

	// Token: 0x0600025B RID: 603 RVA: 0x000086A8 File Offset: 0x00006AA8
	public bool CanDown()
	{
		if (Input.GetMouseButtonUp(0))
		{
			return !(EventSystem.current.currentSelectedGameObject != null);
		}
		return Input.GetAxis("Mouse ScrollWheel") < 0f || (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp(KeyCode.KeypadEnter));
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0000870D File Offset: 0x00006B0D
	public void SetAvgStatus(AVGStatus s)
	{
		if (s != this.avgstatus)
		{
			this.SaveStatus();
		}
		this.avgstatus = s;
	}

	// Token: 0x0600025D RID: 605 RVA: 0x00008728 File Offset: 0x00006B28
	public void SaveStatus()
	{
		this.lastStatus = this.avgstatus;
	}

	// Token: 0x0600025E RID: 606 RVA: 0x00008736 File Offset: 0x00006B36
	public void LoadStatus()
	{
		this.avgstatus = this.lastStatus;
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00008744 File Offset: 0x00006B44
	public void ResetAllLayout()
	{
		Singleton<UIManager>.Instance.HideAllUi();
		this.CanControl = true;
		this.nowScript = null;
		this.nowAction = null;
		Singleton<CGManager>.Instance.UnloadSpriteAsset();
		this.DelectAllLayout();
		this.layoutManager.ResetAllLayout();
		Singleton<AddinManager>.Instance.HideAllAddin();
		Singleton<BGMManager>.Instance.StopBgm();
		Singleton<SEManager>.Instance.StopSE();
		this.lightManager.DestroyAll();
	}

	// Token: 0x06000260 RID: 608 RVA: 0x000087B4 File Offset: 0x00006BB4
	private void DelectAllLayout()
	{
		this.layoutManager.DestroyAllLayout();
		this.hides.Clear();
	}

	// Token: 0x06000261 RID: 609 RVA: 0x000087CC File Offset: 0x00006BCC
	private void CanShowHistory()
	{
		if (Singleton<UIManager>.Instance.GetUiStatus("history"))
		{
			return;
		}
		if (Input.GetAxis("Mouse ScrollWheel") > 0f && this.avgstatus != AVGStatus.UIPAUSE)
		{
			Singleton<UIManager>.Instance.ShowUi("history");
			Debug.Log("show history");
		}
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00008828 File Offset: 0x00006C28
	private void CtrlPressMode()
	{
		if (!Singleton<GameConfigManager>.Instance.config.CtrlMode)
		{
			return;
		}
		if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
		{
			Debug.Log("ctrl down");
			GameConfigManager.ChangeSkipMode(true);
		}
		if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
		{
			Debug.Log("ctrl up");
			GameConfigManager.ChangeSkipMode(false);
		}
	}

	// Token: 0x04000197 RID: 407
	public ScriptExecute execute = ScriptExecute.GetInstance();

	// Token: 0x04000198 RID: 408
	private LayoutManager layoutManager = LayoutManager.GetInstance();

	// Token: 0x04000199 RID: 409
	private LightManager lightManager = LightManager.GetInstance();

	// Token: 0x0400019A RID: 410
	public AVGStatus avgstatus = AVGStatus.WAIT;

	// Token: 0x0400019B RID: 411
	public Dictionary<string, GameObject> hides = new Dictionary<string, GameObject>();

	// Token: 0x0400019C RID: 412
	public ScriptStruct nowScript;

	// Token: 0x0400019D RID: 413
	public BaseAction nowAction;

	// Token: 0x0400019E RID: 414
	public bool IsAuto;

	// Token: 0x0400019F RID: 415
	public bool CanControl = true;

	// Token: 0x040001A0 RID: 416
	public int LiveTime;

	// Token: 0x040001A1 RID: 417
	public float autoTime;

	// Token: 0x040001A2 RID: 418
	public bool IsPrepare = true;

	// Token: 0x040001A3 RID: 419
	public float waitTime;

	// Token: 0x040001A4 RID: 420
	public bool CanMenu;

	// Token: 0x040001A5 RID: 421
	private AVGStatus lastStatus;

	// Token: 0x040001A6 RID: 422
	private bool textSkip;

	// Token: 0x040001A7 RID: 423
	[SerializeField]
	private BlurOptimized blur;
}
