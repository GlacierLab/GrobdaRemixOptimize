using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000BC RID: 188
public class SystemPanelControlScript : MonoBehaviour
{
	// Token: 0x0600042B RID: 1067 RVA: 0x0000E240 File Offset: 0x0000C640
	public void reset()
	{
		this.screenMode.SetStatus(false);
		this.ratioMode.value = 0;
		this.history.SetStatus(true);
		this.hideMouse.SetStatus(false);
		this.Skip.SetStatus(false);
		Singleton<GameConfigManager>.Instance.config.ScreenMode = false;
		Singleton<GameConfigManager>.Instance.config.ScreenRatio = 0;
		Singleton<GameConfigManager>.Instance.config.ResourceMode = true;
		Singleton<GameConfigManager>.Instance.config.HisStoryMode = true;
		Singleton<GameConfigManager>.Instance.config.MouseHide = false;
		Singleton<GameConfigManager>.Instance.config.MouseChange = true;
		Singleton<GameConfigManager>.Instance.config.MouseSpeed = false;
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0000E2FC File Offset: 0x0000C6FC
	public void Init()
	{
		this.screenMode.SetStatus(Singleton<GameConfigManager>.Instance.config.ScreenMode);
		this.history.SetStatus(Singleton<GameConfigManager>.Instance.config.HisStoryMode);
		this.hideMouse.SetStatus(Singleton<GameConfigManager>.Instance.config.MouseHide);
		this.Skip.SetStatus(Singleton<GameConfigManager>.Instance.config.CtrlMode);
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0000E38B File Offset: 0x0000C78B
	public void SetActive(bool b)
	{
		base.gameObject.SetActive(b);
	}

	// Token: 0x0400027D RID: 637
	public ToggleControlScript screenMode;

	// Token: 0x0400027E RID: 638
	public Dropdown ratioMode;

	// Token: 0x0400027F RID: 639
	public ToggleControlScript history;

	// Token: 0x04000280 RID: 640
	public ToggleControlScript hideMouse;

	// Token: 0x04000281 RID: 641
	public ToggleControlScript Skip;
}
