using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000AD RID: 173
public class MainMenuClick : UIGameObject
{
	// Token: 0x060003B9 RID: 953 RVA: 0x0000CCBD File Offset: 0x0000B0BD
	private void Start()
	{
        Time.timeScale = 1f;
        this.Show();
		base.GetComponent<Canvas>().worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0000CCE0 File Offset: 0x0000B0E0
	private void ShowAllPeople()
	{
		this.canvasGroup.alpha = 1f;
		this.CopyRectTransform.localPosition = new Vector3(810f, -288f, 0f);
		Graphic logoImage = this.LogoImage;
		Color color = new Color(1f, 1f, 1f, 0f);
		this.p4.color = color;
		color = color;
		this.p3.color = color;
		color = color;
		this.p2.color = color;
		color = color;
		this.p1.color = color;
		logoImage.color = color;
		this.logoLayout.localPosition = new Vector3(0f, 0f, 0f);
		this.p4.DOFade(1f, this.time).SetDelay(this.time * 0f);
		this.p3.DOFade(1f, this.time).SetDelay(this.time - this.time1);
		this.p1.DOFade(1f, this.time).SetDelay(this.time * 2f - this.time1 * 2f);
		this.p2.DOFade(1f, this.time).SetDelay(this.time * 3f - this.time1 * 3f).OnComplete(new TweenCallback(this.ShowLogo));
	}

	// Token: 0x060003BB RID: 955 RVA: 0x0000CE64 File Offset: 0x0000B264
	private void ShowBg()
	{
		this.bg.rectTransform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
		this.bg.rectTransform.DOScale(new Vector3(1f, 1f, 1f), this.time * 4f - this.time1 * 3f);
		this.ShowAllPeople();
	}

	// Token: 0x060003BC RID: 956 RVA: 0x0000CED9 File Offset: 0x0000B2D9
	private void ShowLogo()
	{
		this.LogoImage.DOFade(1f, 1f).OnComplete(new TweenCallback(this.LogoMove));
	}

	// Token: 0x060003BD RID: 957 RVA: 0x0000CF02 File Offset: 0x0000B302
	private void LogoMove()
	{
		this.logoLayout.DOLocalMoveY(106f, 1.5f, false).OnComplete(new TweenCallback(this.ShowCopyRight));
	}

	// Token: 0x060003BE RID: 958 RVA: 0x0000CF2C File Offset: 0x0000B32C
	private void ShowCopyRight()
	{
		this.CopyRectTransform.DOLocalMoveX(471f, 0.5f, false);
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0000CF48 File Offset: 0x0000B348
	public override void Show()
	{
		base.Show();
		Camera component = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		component.backgroundColor = Color.black;
		Singleton<AVGManager>.Instance.CanControl = false;
		if (this.IsDemo)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			UIGameObject uigameObject = UnityEngine.Object.Instantiate<UIGameObject>(Resources.Load<UIGameObject>("prefab/main_menu_1"));
			Singleton<UIManager>.Instance.SetItem("main", uigameObject);
		}
		Singleton<BGMManager>.Instance.PlayBGM("Luna Rhapsody", false);
		this.ShowBg();
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0000CFCD File Offset: 0x0000B3CD
	private void ButtonsAnimation()
	{
		this.ButtonsGroupRectTransform.DOLocalMoveY(-350f, 1f, false);
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0000CFE6 File Offset: 0x0000B3E6
	public void StartButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		this.FadeOutCanvas(new TweenCallback(this.StartGame));
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x0000D004 File Offset: 0x0000B404
	private void FadeOutCanvas(TweenCallback t)
	{
		this.canvasGroup.DOFade(0f, 2f).OnComplete(t);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x0000D022 File Offset: 0x0000B422
	private void StartGame()
	{
		Singleton<AVGManager>.Instance.SetPrepareStatus();
		LoadScriptConfig.SetConfig("xml/testXml", 0);
		SceneManager.LoadScene("logo");
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x0000D043 File Offset: 0x0000B443
	public void ExitButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Application.Quit();
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0000D054 File Offset: 0x0000B454
	public void OpenUrl()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Process.Start("http://koto.orlaneworks.com/");
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x0000D06B File Offset: 0x0000B46B
	public void TestLoadButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		LoadScriptConfig.SetSaveData(SaveDataManager.GetInstance().GetSaveData(0));
		SceneManager.LoadScene("logo");
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x0000D091 File Offset: 0x0000B491
	public void OpenLoad()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("load");
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x0000D0AC File Offset: 0x0000B4AC
	public void OpenSetting()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("config");
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x0000D0C8 File Offset: 0x0000B4C8
	public void ContinueButton()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		SaveData saveData = SaveDataManager.GetInstance().GetSaveData(0);
		if (saveData != null)
		{
			this.FadeOutCanvas(new TweenCallback(this.ContinueGame));
		}
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0000D104 File Offset: 0x0000B504
	private void ContinueGame()
	{
		SaveData saveData = SaveDataManager.GetInstance().GetSaveData(0);
		if (saveData != null)
		{
			Singleton<SystemSoundManager>.Instance.PlaySound1();
			LoadScriptConfig.SetSaveData(SaveDataManager.GetInstance().GetSaveData(0));
			SceneManager.LoadScene("logo");
		}
	}

	// Token: 0x0400024A RID: 586
	public Image LogoImage;

	// Token: 0x0400024B RID: 587
	public RectTransform ButtonsGroupRectTransform;

	// Token: 0x0400024C RID: 588
	public RectTransform CopyRectTransform;

	// Token: 0x0400024D RID: 589
	public CanvasGroup canvasGroup;

	// Token: 0x0400024E RID: 590
	public bool IsDemo;

	// Token: 0x0400024F RID: 591
	public RectTransform logoLayout;

	// Token: 0x04000250 RID: 592
	public Image p1;

	// Token: 0x04000251 RID: 593
	public Image p2;

	// Token: 0x04000252 RID: 594
	public Image p3;

	// Token: 0x04000253 RID: 595
	public Image p4;

	// Token: 0x04000254 RID: 596
	public Image bg;

	// Token: 0x04000255 RID: 597
	private float time = 0.5f;

	// Token: 0x04000256 RID: 598
	private float time1 = 0.1f;
}
