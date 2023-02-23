using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000C7 RID: 199
public class GalleryCanvasControlScript : UIGameObject
{
	// Token: 0x06000461 RID: 1121 RVA: 0x0000EAB0 File Offset: 0x0000CEB0
	public override void Show()
	{
		base.Show();
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.UIPAUSE);
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 1f);
		this.Dialog.SetActive(false);
		this.galleryPanelControlScript.InitAllItemGroup();
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0000EB0B File Offset: 0x0000CF0B
	public override void Hide()
	{
		this.galleryPanelControlScript.DeleteUnUseful();
		this.Back();
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x0000EB1E File Offset: 0x0000CF1E
	public void Back()
	{
		this.canvasGroup.DOFade(0f, 1f).OnComplete(new TweenCallback(this.dismiss));
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x0000EB47 File Offset: 0x0000CF47
	private void dismiss()
	{
		base.gameObject.SetActive(false);
		Singleton<AVGManager>.Instance.LoadStatus();
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x0000EB65 File Offset: 0x0000CF65
	private void Update()
	{
	}

	// Token: 0x04000299 RID: 665
	public CanvasGroup canvasGroup;

	// Token: 0x0400029A RID: 666
	public GameObject Dialog;

	// Token: 0x0400029B RID: 667
	public GalleryPanelControlScript galleryPanelControlScript;
}
