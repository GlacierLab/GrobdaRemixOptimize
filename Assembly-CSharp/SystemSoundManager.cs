using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200008A RID: 138
public class SystemSoundManager : Singleton<SystemSoundManager>
{
	// Token: 0x060002CB RID: 715 RVA: 0x0000A350 File Offset: 0x00008750
	protected SystemSoundManager()
	{
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0000A363 File Offset: 0x00008763
	private void Awake()
	{
		this.se_source = base.gameObject.AddComponent<AudioSource>();
	}

	// Token: 0x060002CD RID: 717 RVA: 0x0000A376 File Offset: 0x00008776
	public override void InitResource()
	{
		this.LoadResourceFromAB();
	}

	// Token: 0x060002CE RID: 718 RVA: 0x0000A380 File Offset: 0x00008780
	private void LoadResourceFromAB()
	{
		string text = Application.dataPath + "/data/system";
		this.assetBundle = AssetBundle.LoadFromFile(text);
		AudioClip[] array = this.assetBundle.LoadAllAssets<AudioClip>();
		foreach (AudioClip audioClip in array)
		{
			this.soundDict.Add(audioClip.name, audioClip);
		}
	}

	// Token: 0x060002CF RID: 719 RVA: 0x0000A3E6 File Offset: 0x000087E6
	public void PlaySound1()
	{
		this.PlaySe(SystemSoundManager.SystemSound1, false);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x0000A3F4 File Offset: 0x000087F4
	public void PlaySound2()
	{
		this.PlaySe(SystemSoundManager.SystemSound2, false);
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x0000A404 File Offset: 0x00008804
	private void PlaySe(string name, bool loop = false)
	{
		if (this.soundDict.ContainsKey(name))
		{
			this.se_source.clip = this.soundDict[name];
			this.se_source.loop = loop;
			this.se_source.Play();
		}
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x0000A450 File Offset: 0x00008850
	public void SetVolume(float v)
	{
		this.se_source.volume = v;
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x0000A45E File Offset: 0x0000885E
	public void StopSE()
	{
		if (this.se_source != null)
		{
			this.se_source.Stop();
		}
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0000A47C File Offset: 0x0000887C
	public void SetMute()
	{
		this.se_source.mute = !this.se_source.mute;
	}

	// Token: 0x040001DC RID: 476
	private AssetBundle assetBundle;

	// Token: 0x040001DD RID: 477
	private Dictionary<string, AudioClip> soundDict = new Dictionary<string, AudioClip>();

	// Token: 0x040001DE RID: 478
	private AudioSource se_source;

	// Token: 0x040001DF RID: 479
	public static string SystemSound1 = "按键B";

	// Token: 0x040001E0 RID: 480
	public static string SystemSound2 = "按键C";
}
