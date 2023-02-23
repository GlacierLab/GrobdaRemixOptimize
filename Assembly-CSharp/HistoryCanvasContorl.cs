using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class HistoryCanvasContorl : UIGameObject
{
	// Token: 0x060003A3 RID: 931 RVA: 0x0000C979 File Offset: 0x0000AD79
	private void Awake()
	{
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x0000C97B File Offset: 0x0000AD7B
	private void Start()
	{
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x0000C980 File Offset: 0x0000AD80
	public override void Show()
	{
		base.Show();
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.UIPAUSE);
		this.canvasGeoup.alpha = 0f;
		this.canvasGeoup.DOFade(1f, 1f);
		this.historyControlScript.InitAllItem();
		this.textShow = Singleton<UIManager>.Instance.GetUiStatus("text");
		Singleton<UIManager>.Instance.HideUi("text");
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x0000C9F3 File Offset: 0x0000ADF3
	public override void Hide()
	{
		Singleton<AVGManager>.Instance.LoadStatus();
		Singleton<UIManager>.Instance.SetUiStatus("text", this.textShow);
		this.Back();
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x0000CA1A File Offset: 0x0000AE1A
	private void Update()
	{
		if (Input.GetMouseButtonUp(1))
		{
			this.Hide();
		}
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0000CA2D File Offset: 0x0000AE2D
	private void Back()
	{
		this.canvasGeoup.DOFade(0f, 1f).OnComplete(new TweenCallback(this.dismiss));
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x0000CA56 File Offset: 0x0000AE56
	private void dismiss()
	{
		base.gameObject.SetActive(false);
	}

	// Token: 0x04000241 RID: 577
	public CanvasGroup canvasGeoup;

	// Token: 0x04000242 RID: 578
	public HistoryControlScript historyControlScript;

	// Token: 0x04000243 RID: 579
	private bool textShow;
}
