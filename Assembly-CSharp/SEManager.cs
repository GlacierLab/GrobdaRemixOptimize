using System;
using System.IO;
using UnityEngine;

// Token: 0x02000088 RID: 136
public class SEManager : Singleton<SEManager>
{
	// Token: 0x060002BC RID: 700 RVA: 0x0000A009 File Offset: 0x00008409
	protected SEManager()
	{
	}

	// Token: 0x060002BD RID: 701 RVA: 0x0000A01C File Offset: 0x0000841C
	private void Start()
	{
		this.se_group = new GameObject("se_group");
		this.se_group.gameObject.transform.SetParent(base.transform);
		this.InitAllSource();
	}

	// Token: 0x060002BE RID: 702 RVA: 0x0000A050 File Offset: 0x00008450
	private void InitAllSource()
	{
		this.MaxSourceNum = 4;
		this.se_sources = new AudioSource[this.MaxSourceNum];
		for (int i = 0; i < this.MaxSourceNum; i++)
		{
			GameObject gameObject = new GameObject(i.ToString());
			this.se_sources[i] = gameObject.AddComponent<AudioSource>();
			gameObject.transform.SetParent(this.se_group.transform);
		}
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0000A0C3 File Offset: 0x000084C3
	private AudioSource selectAudioSource()
	{
		this.nowSelectNum++;
		if (this.nowSelectNum == this.MaxSourceNum)
		{
			this.nowSelectNum = 0;
		}
		return this.se_sources[this.nowSelectNum];
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0000A0F8 File Offset: 0x000084F8
	public override void InitResource()
	{
		this.LoadResourceFromAB();
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x0000A100 File Offset: 0x00008500
	private void LoadResourceFromAB()
	{
		string text = Application.dataPath + "/data/se";
		string text2 = ((!File.Exists(Application.dataPath + "/data/soundpatch")) ? null : (Application.dataPath + "/data/soundpatch"));
		this.assetBundle = AssetBundle.LoadFromFile(text);
		this.patchAssetBundle = ((text2 == null) ? null : AssetBundle.LoadFromFile(text2));
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0000A170 File Offset: 0x00008570
	public void PlaySe(string name, bool loop)
	{
		AudioSource audioSource = this.selectAudioSource();
		AudioClip audioClip = ((!this.patchAssetBundle) ? null : this.patchAssetBundle.LoadAsset<AudioClip>(name));
		if (audioClip == null)
		{
			audioClip = this.assetBundle.LoadAsset<AudioClip>(name);
		}
		if (audioClip == null)
		{
			Debug.LogError("can't load se:" + name);
			return;
		}
		audioSource.volume = Singleton<GameConfigManager>.Instance.config.SEVolume;
		audioSource.clip = audioClip;
		audioSource.loop = loop;
		audioSource.Play();
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0000A208 File Offset: 0x00008608
	public void SetVolume(float v)
	{
		for (int i = 0; i < this.MaxSourceNum; i++)
		{
			if (this.se_sources[i] != null)
			{
				this.se_sources[i].volume = v;
			}
		}
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0000A250 File Offset: 0x00008650
	public void StopSE()
	{
		for (int i = 0; i < this.MaxSourceNum; i++)
		{
			if (this.se_sources[i] != null)
			{
				this.se_sources[i].Stop();
			}
		}
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x0000A294 File Offset: 0x00008694
	public void SetMute()
	{
		for (int i = 0; i < this.MaxSourceNum; i++)
		{
			if (this.se_sources[i] != null)
			{
				this.se_sources[i].mute = !this.se_sources[i].mute;
			}
		}
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0000A2E8 File Offset: 0x000086E8
	public void PlayTestBgm()
	{
		this.PlaySe(this.testName, false);
	}

	// Token: 0x040001D3 RID: 467
	private AudioSource[] se_sources;

	// Token: 0x040001D4 RID: 468
	private AssetBundle assetBundle;

	// Token: 0x040001D5 RID: 469
	private AssetBundle patchAssetBundle;

	// Token: 0x040001D6 RID: 470
	private GameObject se_group;

	// Token: 0x040001D7 RID: 471
	private int MaxSourceNum;

	// Token: 0x040001D8 RID: 472
	private string testName = "bass";

	// Token: 0x040001D9 RID: 473
	private int nowSelectNum;
}
