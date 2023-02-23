using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
public class VoiceManager : Singleton<VoiceManager>
{
	// Token: 0x060002F1 RID: 753 RVA: 0x0000AAF1 File Offset: 0x00008EF1
	protected VoiceManager()
	{
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x0000AAF9 File Offset: 0x00008EF9
	private void Awake()
	{
		this.se_source = base.gameObject.AddComponent<AudioSource>();
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x0000AB0C File Offset: 0x00008F0C
	public override void InitResource()
	{
		this.LoadResourceFromAB();
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x0000AB14 File Offset: 0x00008F14
	private void LoadResourceFromAB()
	{
		string text = Application.dataPath + "/data/voice";
		this.assetBundle = AssetBundle.LoadFromFile(text);
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0000AB40 File Offset: 0x00008F40
	public void PlaySe(string name, bool loop, int kind)
	{
		if (GameConfigManager.SkipMode && Singleton<GameConfigManager>.Instance.config.SkipVoiceStop)
		{
			return;
		}
		if (name == null)
		{
			return;
		}
		AudioClip audioClip = this.assetBundle.LoadAsset<AudioClip>(name);
		if (audioClip != null)
		{
			this.se_source.clip = audioClip;
			this.se_source.loop = loop;
			this.SetVolume(Singleton<GameConfigManager>.Instance.config.GetVolumeByKind(kind));
			this.se_source.Play();
		}
		else
		{
			Debug.LogError("can't load voice:" + name);
		}
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x0000ABDA File Offset: 0x00008FDA
	public void SetVolume(float v)
	{
		this.se_source.volume = v;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0000ABE8 File Offset: 0x00008FE8
	public void StopSE()
	{
		if (this.se_source != null)
		{
			this.se_source.Stop();
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0000AC06 File Offset: 0x00009006
	public void SetMute()
	{
		this.se_source.mute = !this.se_source.mute;
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0000AC21 File Offset: 0x00009021
	public bool GetPlayStatus()
	{
		return this.se_source.isPlaying;
	}

	// Token: 0x040001E6 RID: 486
	private AssetBundle assetBundle;

	// Token: 0x040001E7 RID: 487
	private AudioSource se_source;
}
