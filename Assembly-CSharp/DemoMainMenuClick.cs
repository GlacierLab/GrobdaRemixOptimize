using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x020000A3 RID: 163
public class DemoMainMenuClick : UIGameObject
{
	// Token: 0x06000368 RID: 872 RVA: 0x0000C020 File Offset: 0x0000A420
	private void Start()
	{
		this.Show();
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0000C028 File Offset: 0x0000A428
	public Sprite GetBgByTime()
	{
		int num = 0;
		int hour = DateTime.Now.Hour;
		if (hour >= 6 && hour <= 15)
		{
			num = this.random.Next(0, 5);
			num = this.morning[num];
		}
		else if (hour > 15 && hour < 19)
		{
			num = this.random.Next(0, 5);
			num = this.afternoon[num];
		}
		else if (hour >= 19 || hour < 6)
		{
			num = this.random.Next(0, 5);
			num = this.evening[num];
		}
		return Singleton<CGManager>.Instance.GetSpriteByName("bg" + num);
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0000C0DC File Offset: 0x0000A4DC
	public override void Show()
	{
		base.GetComponent<Canvas>().worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
		base.Show();
		if (this.random == null)
		{
			long ticks = DateTime.Now.Ticks;
			this.random = new System.Random((int)(ticks & (long)((ulong)(-1))) | (int)(ticks >> 32));
		}
		this.bg.sprite = this.GetBgByTime();
		this.animator.speed = 0.5f;
		this.animator.Play("new_main_menu");
		Camera component = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		component.backgroundColor = Color.black;
		Singleton<AVGManager>.Instance.CanControl = false;
		Singleton<BGMManager>.Instance.PlayBGM("Luna Rhapsody", false);
	}

	// Token: 0x0600036B RID: 875 RVA: 0x0000C19F File Offset: 0x0000A59F
	public void StartButtonClick()
	{
		this.animator.Stop();
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		this.FadeOutCanvas(new TweenCallback(this.StartGame));
	}

	// Token: 0x0600036C RID: 876 RVA: 0x0000C1C8 File Offset: 0x0000A5C8
	private void FadeOutCanvas(TweenCallback t)
	{
		Camera component = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		component.backgroundColor = Color.black;
		this.canvasGroup.DOFade(0f, 2f).OnComplete(t);
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0000C20C File Offset: 0x0000A60C
	private void StartGame()
	{
		Singleton<AVGManager>.Instance.SetPrepareStatus();
		LoadScriptConfig.SetConfig("xml/start", 0);
		SceneManager.LoadScene("logo");
	}

	// Token: 0x0600036E RID: 878 RVA: 0x0000C22D File Offset: 0x0000A62D
	public void ExitButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Application.Quit();
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0000C240 File Offset: 0x0000A640
	public void OpenUrl()
	{
		if (this.animator.GetCurrentAnimatorStateInfo(0).length < this.animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
		{
			return;
		}
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Process.Start("http://koto.orlaneworks.com/");
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0000C290 File Offset: 0x0000A690
	public void TestLoadButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		LoadScriptConfig.SetSaveData(SaveDataManager.GetInstance().GetSaveData(0));
		SceneManager.LoadScene("logo");
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0000C2B6 File Offset: 0x0000A6B6
	public void OpenLoad()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("load");
	}

	// Token: 0x06000372 RID: 882 RVA: 0x0000C2D1 File Offset: 0x0000A6D1
	public void OpenSetting()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("config");
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0000C2EC File Offset: 0x0000A6EC
	public void OpenExtra()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		this.mainIcons.SetActive(false);
		this.extraIcons.SetActive(true);
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0000C310 File Offset: 0x0000A710
	public void OpenGallery()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("extra_gallery");
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0000C32B File Offset: 0x0000A72B
	public void OpenMusic()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("extra_music");
	}

	// Token: 0x06000376 RID: 886 RVA: 0x0000C346 File Offset: 0x0000A746
	public void OpenMovie()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("extra_movie");
	}

	// Token: 0x06000377 RID: 887 RVA: 0x0000C361 File Offset: 0x0000A761
	public void BackToMainMenu()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		this.mainIcons.SetActive(true);
		this.extraIcons.SetActive(false);
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0000C388 File Offset: 0x0000A788
	public void ContinueButton()
	{
		this.animator.Stop();
		SaveData saveData = SaveDataManager.GetInstance().GetSaveData(0);
		if (saveData != null)
		{
			this.FadeOutCanvas(new TweenCallback(this.ContinueGame));
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0000C3C4 File Offset: 0x0000A7C4
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

	// Token: 0x0400022B RID: 555
	public CanvasGroup canvasGroup;

	// Token: 0x0400022C RID: 556
	public Animator animator;

	// Token: 0x0400022D RID: 557
	public Image bg;

	// Token: 0x0400022E RID: 558
	public GameObject mainIcons;

	// Token: 0x0400022F RID: 559
	public GameObject extraIcons;

	// Token: 0x04000230 RID: 560
	private System.Random random;

	// Token: 0x04000231 RID: 561
	private int[] morning = new int[] { 0, 3, 6, 9, 12 };

	// Token: 0x04000232 RID: 562
	private int[] afternoon = new int[] { 1, 4, 7, 10, 13 };

	// Token: 0x04000233 RID: 563
	private int[] evening = new int[] { 2, 5, 8, 11, 14 };
}
