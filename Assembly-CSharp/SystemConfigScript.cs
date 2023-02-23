using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000BB RID: 187
public class SystemConfigScript : MonoBehaviour
{
	// Token: 0x0600041F RID: 1055 RVA: 0x0000E123 File Offset: 0x0000C523
	private void Start()
	{
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0000E125 File Offset: 0x0000C525
	private void Update()
	{
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x0000E127 File Offset: 0x0000C527
	public void Full()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Screen.fullScreen = true;
		Singleton<GameConfigManager>.Instance.config.ScreenMode = true;
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x0000E149 File Offset: 0x0000C549
	public void Windows()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Screen.fullScreen = false;
		Singleton<GameConfigManager>.Instance.config.ScreenMode = false;
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x0000E16B File Offset: 0x0000C56B
	public void RatioResource(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.ResourceMode = b;
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0000E187 File Offset: 0x0000C587
	public void HistoryMode(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.HisStoryMode = b;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0000E1A3 File Offset: 0x0000C5A3
	public void HideMouse(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.MouseHide = b;
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0000E1BF File Offset: 0x0000C5BF
	public void ChangeMouse(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.MouseChange = b;
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0000E1DB File Offset: 0x0000C5DB
	public void CTRLSkip(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.CtrlMode = b;
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x0000E1F7 File Offset: 0x0000C5F7
	public void MouseSkip(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.MouseSpeed = b;
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0000E213 File Offset: 0x0000C613
	public void ChangeRatio(int i)
	{
		i = this.DropdownItem.value;
		GameConfigManager.SetScreenRatio(i);
		Singleton<GameConfigManager>.Instance.config.ScreenRatio = i;
	}

	// Token: 0x0400027B RID: 635
	public Canvas ConfigCanvas;

	// Token: 0x0400027C RID: 636
	public Dropdown DropdownItem;
}
