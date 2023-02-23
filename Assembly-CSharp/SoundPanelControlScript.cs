using System;
using UnityEngine;

// Token: 0x020000BA RID: 186
public class SoundPanelControlScript : MonoBehaviour
{
	// Token: 0x06000419 RID: 1049 RVA: 0x0000DF3C File Offset: 0x0000C33C
	public void reset()
	{
		this.bgm.Init(1f);
		this.se.Init(1f);
		this.system.Init(1f);
		this.movie.Init(1f);
		this.textStop.SetStatus(true);
		this.SkipStop.SetStatus(true);
		Singleton<GameConfigManager>.Instance.config.BgmVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.SEVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.SystemVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.MovieVolume = 1f;
		Singleton<GameConfigManager>.Instance.config.TextVoiceStop = true;
		Singleton<GameConfigManager>.Instance.config.SkipVoiceStop = true;
		Singleton<BGMManager>.Instance.SetVolume(1f);
		Singleton<SEManager>.Instance.SetVolume(1f);
		Singleton<SystemSoundManager>.Instance.SetVolume(1f);
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0000E040 File Offset: 0x0000C440
	public void Init()
	{
		this.bgm.Init(Singleton<GameConfigManager>.Instance.config.BgmVolume);
		this.se.Init(Singleton<GameConfigManager>.Instance.config.SEVolume);
		this.system.Init(Singleton<GameConfigManager>.Instance.config.SystemVolume);
		this.movie.Init(Singleton<GameConfigManager>.Instance.config.MovieVolume);
		this.textStop.SetStatus(Singleton<GameConfigManager>.Instance.config.TextVoiceStop);
		this.SkipStop.SetStatus(Singleton<GameConfigManager>.Instance.config.SkipVoiceStop);
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0000E0E9 File Offset: 0x0000C4E9
	public void SetActive(bool b)
	{
		base.gameObject.SetActive(b);
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0000E0F7 File Offset: 0x0000C4F7
	public void TextVoiceMode(bool b)
	{
		Singleton<GameConfigManager>.Instance.config.TextVoiceStop = b;
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0000E109 File Offset: 0x0000C509
	public void SkipVoiceMode(bool b)
	{
		Singleton<GameConfigManager>.Instance.config.SkipVoiceStop = b;
	}

	// Token: 0x04000275 RID: 629
	public BackGroundControlScript bgm;

	// Token: 0x04000276 RID: 630
	public SeControlScript se;

	// Token: 0x04000277 RID: 631
	public SystemSoundControlScript system;

	// Token: 0x04000278 RID: 632
	public MovieControlScript movie;

	// Token: 0x04000279 RID: 633
	public ToggleControlScript textStop;

	// Token: 0x0400027A RID: 634
	public ToggleControlScript SkipStop;
}
