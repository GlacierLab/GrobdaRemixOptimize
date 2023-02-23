using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000CB RID: 203
public class MusicCanvasControlScript : UIGameObject
{
	// Token: 0x06000474 RID: 1140 RVA: 0x0000EF60 File Offset: 0x0000D360
	public override void Show()
	{
		base.Show();
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.UIPAUSE);
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 1f);
		this.Dialog.SetActive(false);
		this.musicPanelControlScript.InitAllItemGroup();
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0000EFBB File Offset: 0x0000D3BB
	public override void Hide()
	{
		this.musicPanelControlScript.DeleteUnUseful();
		this.Back();
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0000EFD0 File Offset: 0x0000D3D0
	public void Back()
	{
		if ("Luna Rhapsody" != Singleton<BGMManager>.Instance.GetNowPlayBGM())
		{
			Singleton<BGMManager>.Instance.PlayTestBgm();
		}
		this.canvasGroup.DOFade(0f, 1f).OnComplete(new TweenCallback(this.dismiss));
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0000F027 File Offset: 0x0000D427
	private void dismiss()
	{
		base.gameObject.SetActive(false);
		Singleton<AVGManager>.Instance.LoadStatus();
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0000F045 File Offset: 0x0000D445
	private void Update()
	{
	}

	// Token: 0x040002A6 RID: 678
	public CanvasGroup canvasGroup;

	// Token: 0x040002A7 RID: 679
	public GameObject Dialog;

	// Token: 0x040002A8 RID: 680
	public MusicPanelControlScript musicPanelControlScript;
}
