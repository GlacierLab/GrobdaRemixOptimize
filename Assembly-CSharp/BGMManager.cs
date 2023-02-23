using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x0200007F RID: 127
public class BGMManager : Singleton<BGMManager>
{
	// Token: 0x06000269 RID: 617 RVA: 0x00008A5C File Offset: 0x00006E5C
	protected BGMManager()
	{
	}

	// Token: 0x0600026A RID: 618 RVA: 0x00008A6F File Offset: 0x00006E6F
	private void Awake()
	{
		this.bgmsource = base.gameObject.AddComponent<AudioSource>();
		this.bgmsource.loop = true;
		this.status = BGMSTATUS.WAITING;
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00008A95 File Offset: 0x00006E95
	public void SetVolume(float v)
	{
		this.bgmsource.volume = v;
	}

	// Token: 0x0600026C RID: 620 RVA: 0x00008AA3 File Offset: 0x00006EA3
	public void SetVolumeSpeed(float v)
	{
		this.speed = v;
		this.status = BGMSTATUS.FADE;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00008AB3 File Offset: 0x00006EB3
	public override void InitResource()
	{
		this.InitResourceFromAb();
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00008ABC File Offset: 0x00006EBC
	public void InitResourceFromAb()
	{
		string text = Application.dataPath + "/data/bgm";
		string text2 = ((!File.Exists(Application.dataPath + "/data/soundpatch")) ? null : (Application.dataPath + "/data/soundpatch"));
		this.assetBundle = AssetBundle.LoadFromFile(text);
		this.patchAssetBundle = ((text2 == null) ? null : AssetBundle.LoadFromFile(text2));
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00008B2C File Offset: 0x00006F2C
	public Dictionary<string, AudioClip> GetAllBgm()
	{
		return new Dictionary<string, AudioClip>();
	}

	// Token: 0x06000270 RID: 624 RVA: 0x00008B34 File Offset: 0x00006F34
	private AudioClip findBGM(string name)
	{
		AudioClip audioClip = ((!this.patchAssetBundle) ? null : this.patchAssetBundle.LoadAsset<AudioClip>(name));
		if (audioClip == null)
		{
			audioClip = this.assetBundle.LoadAsset<AudioClip>(name);
		}
		if (audioClip == null)
		{
			Debug.LogError("can't find bgm:" + name);
		}
		return audioClip;
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00008B9A File Offset: 0x00006F9A
	public void cleanRestoreBgm()
	{
		this.restoreBgmName = null;
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00008BA3 File Offset: 0x00006FA3
	public void preActionForRestoreBgm()
	{
		if (this.testBgm != this.bgmsource.clip.name)
		{
			this.restoreBgmName = this.bgmsource.clip.name;
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00008BDB File Offset: 0x00006FDB
	public void actionForRestoreBgm()
	{
		if (this.restoreBgmName != null && this.testBgm != this.restoreBgmName)
		{
			this.PlayBGM(this.restoreBgmName, false);
		}
		this.restoreBgmName = null;
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00008C14 File Offset: 0x00007014
	public void PlayBGM(string name, bool reset = false)
	{
		AudioClip audioClip = this.findBGM(name);
		this.bgmsource.clip = audioClip;
		if (this.bgmsource.clip == null)
		{
			Debug.LogError("can't find bgm:" + name);
		}
		this.bgmsource.Play();
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00008C66 File Offset: 0x00007066
	public string GetNowPlayBGM()
	{
		return this.bgmsource.clip.name;
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00008C78 File Offset: 0x00007078
	public void CheckBGM()
	{
		if (this.bgmsource.clip == null)
		{
			Debug.LogError("can't find bgm:");
		}
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00008C9C File Offset: 0x0000709C
	public void PlayTestBgm()
	{
		AudioClip audioClip = this.findBGM(this.testBgm);
		this.bgmsource.clip = audioClip;
		this.bgmsource.Play();
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00008CCD File Offset: 0x000070CD
	public void PauseBgm()
	{
		this.bgmsource.Pause();
		if (this.bgmsource.isPlaying)
		{
			Debug.LogError("can't pause bgm");
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00008CF4 File Offset: 0x000070F4
	public void UnPauseBgm()
	{
		this.bgmsource.UnPause();
		if (!this.bgmsource.isPlaying)
		{
			Debug.LogError("can't unpause bgm");
		}
	}

	// Token: 0x0600027A RID: 634 RVA: 0x00008D1B File Offset: 0x0000711B
	public void StopBgm()
	{
		if (this.bgmsource != null)
		{
			this.bgmsource.Stop();
			Resources.UnloadAsset(this.bgmsource.clip);
			this.bgmsource.clip = null;
		}
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00008D55 File Offset: 0x00007155
	public void SetMute()
	{
		this.bgmsource.mute = !this.bgmsource.mute;
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00008D70 File Offset: 0x00007170
	public void ConfigSaveData(SaveData data)
	{
		if (this.bgmsource.isPlaying)
		{
			data.bgm = this.bgmsource.clip.name;
		}
		else
		{
			data.bgm = string.Empty;
		}
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00008DA8 File Offset: 0x000071A8
	public void LoadSaveData(SaveData data)
	{
		if (data.bgm != string.Empty)
		{
			this.PlayBGM(data.bgm, false);
		}
	}

	// Token: 0x040001AC RID: 428
	private AudioSource bgmsource;

	// Token: 0x040001AD RID: 429
	public BGMSTATUS status;

	// Token: 0x040001AE RID: 430
	public BaseAction nowAction;

	// Token: 0x040001AF RID: 431
	public float speed;

	// Token: 0x040001B0 RID: 432
	public string restoreBgmName;

	// Token: 0x040001B1 RID: 433
	private AssetBundle assetBundle;

	// Token: 0x040001B2 RID: 434
	private AssetBundle patchAssetBundle;

	// Token: 0x040001B3 RID: 435
	private string testBgm = "Luna Rhapsody";
}
