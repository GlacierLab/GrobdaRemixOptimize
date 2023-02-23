using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000C5 RID: 197
public class ExtraMovieCanvasControlScript : UIGameObject
{
	// Token: 0x06000456 RID: 1110 RVA: 0x0000E980 File Offset: 0x0000CD80
	public override void Show()
	{
		base.Show();
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.UIPAUSE);
		this.canvasGroup.alpha = 0f;
		this.canvasGroup.DOFade(1f, 1f);
		this.Dialog.SetActive(false);
		this.extraPanelControlScript.InitAllItemGroup();
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x0000E9DB File Offset: 0x0000CDDB
	public override void Hide()
	{
		Singleton<BGMManager>.Instance.PlayBGM("Luna Rhapsody", false);
		this.extraPanelControlScript.DeleteUnUseful();
		this.Back();
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0000E9FE File Offset: 0x0000CDFE
	public void Back()
	{
		this.canvasGroup.DOFade(0f, 1f).OnComplete(new TweenCallback(this.dismiss));
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x0000EA27 File Offset: 0x0000CE27
	private void dismiss()
	{
		base.gameObject.SetActive(false);
		Singleton<AVGManager>.Instance.LoadStatus();
		Resources.UnloadUnusedAssets();
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x0000EA45 File Offset: 0x0000CE45
	private void Update()
	{
		if (Input.GetMouseButtonUp(1))
		{
			if (this.Dialog.activeSelf)
			{
				this.Dialog.SetActive(false);
			}
			else
			{
				this.Hide();
			}
		}
	}

	// Token: 0x04000295 RID: 661
	public CanvasGroup canvasGroup;

	// Token: 0x04000296 RID: 662
	public GameObject Dialog;

	// Token: 0x04000297 RID: 663
	public ExtraMoviePanelControlScript extraPanelControlScript;
}
