using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class ConfigButtonScript : UIGameObject
{
	// Token: 0x06000355 RID: 853 RVA: 0x0000BCD3 File Offset: 0x0000A0D3
	private void Awake()
	{
		this.titleDialog.SetActive(false);
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0000BCE1 File Offset: 0x0000A0E1
	private void Start()
	{
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0000BCE4 File Offset: 0x0000A0E4
	public override void Show()
	{
		base.Show();
		this.titleDialog.SetActive(false);
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.UIPAUSE);
		this.systemPanel.Init();
		this.textPanel.Init();
		this.soundPanel.Init();
		this.headSoundPanel.Init();
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 1f);
		if (this.isFirst)
		{
			this.textPanel.SetActive(false);
			this.soundPanel.SetActive(false);
			this.headSoundPanel.SetActive(false);
			this.isFirst = false;
		}
	}

	// Token: 0x06000358 RID: 856 RVA: 0x0000BD96 File Offset: 0x0000A196
	public override void Hide()
	{
		this.Back();
	}

	// Token: 0x06000359 RID: 857 RVA: 0x0000BD9E File Offset: 0x0000A19E
	private void OnDisable()
	{
		Singleton<BGMManager>.Instance.actionForRestoreBgm();
		Singleton<BGMManager>.Instance.cleanRestoreBgm();
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0000BDB4 File Offset: 0x0000A1B4
	private void Update()
	{
		if (Input.GetMouseButtonUp(1))
		{
			Singleton<SystemSoundManager>.Instance.PlaySound2();
			GameObject gameObject = GameObject.Find("exit_dialog");
			if (this.titleDialog.activeSelf)
			{
				this.titleDialog.SetActive(false);
			}
			else if (gameObject != null)
			{
				UnityEngine.Object.Destroy(gameObject);
			}
			else
			{
				this.Hide();
			}
		}
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0000BE1F File Offset: 0x0000A21F
	public void ShowSystemConfig()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.systemPanel.SetActive(true);
		this.textPanel.SetActive(false);
		this.soundPanel.SetActive(false);
		this.headSoundPanel.SetActive(false);
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0000BE5B File Offset: 0x0000A25B
	public void ShowTextConfig()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.systemPanel.SetActive(false);
		this.textPanel.SetActive(true);
		this.soundPanel.SetActive(false);
		this.headSoundPanel.SetActive(false);
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0000BE97 File Offset: 0x0000A297
	public void ShowSoundConfig()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.systemPanel.SetActive(false);
		this.textPanel.SetActive(false);
		this.soundPanel.SetActive(true);
		this.headSoundPanel.SetActive(false);
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0000BED3 File Offset: 0x0000A2D3
	public void ShowHeadSoundConfig()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.systemPanel.SetActive(false);
		this.textPanel.SetActive(false);
		this.soundPanel.SetActive(false);
		this.headSoundPanel.SetActive(true);
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0000BF0F File Offset: 0x0000A30F
	public void ShowTitleDialog()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.titleDialog.SetActive(true);
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0000BF27 File Offset: 0x0000A327
	public void HideTitleDialog()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.titleDialog.SetActive(false);
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0000BF3F File Offset: 0x0000A33F
	public void ReturnToTitle()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<AVGManager>.Instance.ExitToMenu();
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0000BF55 File Offset: 0x0000A355
	public void ShowExitDialog()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Application.Quit();
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0000BF66 File Offset: 0x0000A366
	public void HideExitDialog()
	{
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0000BF68 File Offset: 0x0000A368
	public void ExitGame()
	{
	}

	// Token: 0x06000365 RID: 869 RVA: 0x0000BF6A File Offset: 0x0000A36A
	private void Back()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.SaveAllConfig();
		this.canvasGroup.DOFade(0f, 1f).OnComplete(new TweenCallback(this.dismiss));
	}

	// Token: 0x06000366 RID: 870 RVA: 0x0000BFA7 File Offset: 0x0000A3A7
	private void dismiss()
	{
		base.gameObject.SetActive(false);
		Singleton<AVGManager>.Instance.LoadStatus();
	}

	// Token: 0x04000224 RID: 548
	public SystemPanelControlScript systemPanel;

	// Token: 0x04000225 RID: 549
	public TextPanelControlScript textPanel;

	// Token: 0x04000226 RID: 550
	public SoundPanelControlScript soundPanel;

	// Token: 0x04000227 RID: 551
	public HeadSoundPanelControlScript headSoundPanel;

	// Token: 0x04000228 RID: 552
	public CanvasGroup canvasGroup;

	// Token: 0x04000229 RID: 553
	public GameObject titleDialog;

	// Token: 0x0400022A RID: 554
	private bool isFirst = true;
}
