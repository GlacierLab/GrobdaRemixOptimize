using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C1 RID: 193
public class TextPanelControlScript : MonoBehaviour
{
	// Token: 0x06000441 RID: 1089 RVA: 0x0000E590 File Offset: 0x0000C990
	public void reset()
	{
		this.textSpeed.value = this.textSpeed.maxValue / 2f;
		this.autoSpeed.value = this.autoSpeed.maxValue / 2f;
		this.textColor.value = 0.5f;
		this.textFont.value = 0;
		this.readSkipMode.SetStatus(true);
		this.autoStopMode.SetStatus(true);
		this.skipStopMode.SetStatus(true);
		Singleton<GameConfigManager>.Instance.config.TextSpeed = (int)this.textSpeed.value;
		Singleton<GameConfigManager>.Instance.config.AutoTime = this.autoSpeed.value;
		Singleton<GameConfigManager>.Instance.config.FontKind = this.textFont.value;
		Singleton<GameConfigManager>.Instance.config.CtrlMode = true;
		Singleton<GameConfigManager>.Instance.config.AutoStopMode = true;
		Singleton<GameConfigManager>.Instance.config.CtrlStopMode = true;
		Singleton<UIManager>.Instance.GetUi("text").GetComponent<GameButtonClick>().ChangeAlpha(0.5f);
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0000E6B4 File Offset: 0x0000CAB4
	public void Init()
	{
		this.textSpeed.value = (float)Singleton<GameConfigManager>.Instance.config.TextSpeed;
		this.autoSpeed.value = Singleton<GameConfigManager>.Instance.config.AutoTime;
		this.textColor.value = Singleton<GameConfigManager>.Instance.config.textAlpha;
		this.textFont.value = 0;
		this.readSkipMode.SetStatus(Singleton<GameConfigManager>.Instance.config.CtrlMode);
		this.autoStopMode.SetStatus(Singleton<GameConfigManager>.Instance.config.AutoStopMode);
		this.skipStopMode.SetStatus(Singleton<GameConfigManager>.Instance.config.CtrlStopMode);
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0000E76A File Offset: 0x0000CB6A
	public void SetActive(bool b)
	{
		base.gameObject.SetActive(b);
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0000E778 File Offset: 0x0000CB78
	public void SkipMode(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.CtrlMode = b;
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0000E794 File Offset: 0x0000CB94
	public void AutoStopMode(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.AutoStopMode = b;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0000E7B0 File Offset: 0x0000CBB0
	public void SkipStopMode(bool b)
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		Singleton<GameConfigManager>.Instance.config.CtrlStopMode = b;
	}

	// Token: 0x04000288 RID: 648
	public Slider textSpeed;

	// Token: 0x04000289 RID: 649
	public Slider autoSpeed;

	// Token: 0x0400028A RID: 650
	public Slider textColor;

	// Token: 0x0400028B RID: 651
	public Dropdown textFont;

	// Token: 0x0400028C RID: 652
	public ToggleControlScript readSkipMode;

	// Token: 0x0400028D RID: 653
	public ToggleControlScript autoStopMode;

	// Token: 0x0400028E RID: 654
	public ToggleControlScript skipStopMode;
}
