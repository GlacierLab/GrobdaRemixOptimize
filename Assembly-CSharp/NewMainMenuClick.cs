using System;
using System.Diagnostics;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000B0 RID: 176
public class NewMainMenuClick : UIGameObject
{
	// Token: 0x060003D5 RID: 981 RVA: 0x0000D303 File Offset: 0x0000B703
	private void Start()
	{
        Time.timeScale = 1f;
        this.Show();
		base.GetComponent<Canvas>().worldCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0000D328 File Offset: 0x0000B728
	public override void Show()
	{
		base.Show();
		this.canvasGroup.alpha = 1f;
		this.animator.Play("demo_main_menu");
		Camera component = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
		component.backgroundColor = Color.black;
		Singleton<AVGManager>.Instance.CanControl = false;
		Singleton<BGMManager>.Instance.PlayBGM("Luna Rhapsody", false);
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0000D391 File Offset: 0x0000B791
	public void StartButtonClick()
	{
		this.animator.Stop();
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		this.FadeOutCanvas(new TweenCallback(this.StartGame));
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0000D3BA File Offset: 0x0000B7BA
	private void FadeOutCanvas(TweenCallback t)
	{
		this.canvasGroup.DOFade(0f, 2f).OnComplete(t);
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0000D3D8 File Offset: 0x0000B7D8
	private void StartGame()
	{
		Singleton<AVGManager>.Instance.SetPrepareStatus();
		LoadScriptConfig.SetConfig("xml/testXml", 0);
		SceneManager.LoadScene("logo");
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0000D3F9 File Offset: 0x0000B7F9
	public void ExitButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Application.Quit();
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0000D40A File Offset: 0x0000B80A
	public void OpenUrl()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Process.Start("http://koto.orlaneworks.com/");
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0000D421 File Offset: 0x0000B821
	public void TestLoadButtonClick()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		LoadScriptConfig.SetSaveData(SaveDataManager.GetInstance().GetSaveData(0));
		SceneManager.LoadScene("logo");
	}

	// Token: 0x060003DD RID: 989 RVA: 0x0000D447 File Offset: 0x0000B847
	public void OpenLoad()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("load");
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0000D462 File Offset: 0x0000B862
	public void OpenSetting()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
		Singleton<UIManager>.Instance.ShowUi("config");
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0000D480 File Offset: 0x0000B880
	public void ContinueButton()
	{
		this.animator.Stop();
		SaveData saveData = SaveDataManager.GetInstance().GetSaveData(0);
		if (saveData != null)
		{
			this.FadeOutCanvas(new TweenCallback(this.ContinueGame));
		}
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0000D4BC File Offset: 0x0000B8BC
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

	// Token: 0x0400025D RID: 605
	public CanvasGroup canvasGroup;

	// Token: 0x0400025E RID: 606
	public Animator animator;
}
