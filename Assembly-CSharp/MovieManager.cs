using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000085 RID: 133
public class MovieManager : Singleton<MovieManager>
{
	// Token: 0x060002B4 RID: 692 RVA: 0x00009D50 File Offset: 0x00008150
	private void Awake()
	{
		this.plane = UnityEngine.Object.Instantiate<MoviePlane>(Resources.Load<MoviePlane>("prefab/movie_plane"));
		this.plane.transform.SetParent(base.gameObject.transform, false);
		this.plane.gameObject.SetActive(false);
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x00009D9F File Offset: 0x0000819F
	public override void InitResource()
	{
		this.LoadAssetBundle();
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00009DA7 File Offset: 0x000081A7
	public void SetVolume(float v)
	{
		this.plane.SetVolume(v);
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x00009DB8 File Offset: 0x000081B8
	public void PlayMovie(string name, bool restoreUI = false)
	{
		Singleton<SEManager>.Instance.StopSE();
		Singleton<BGMManager>.Instance.StopBgm();
		Singleton<VoiceManager>.Instance.StopSE();
		this.SetVolume(Singleton<GameConfigManager>.Instance.config.MovieVolume);
		if (this.materials.ContainsKey(name))
		{
			this.plane.restoreUI = restoreUI;
			this.plane.SetMovie(this.materials[name], this.audioClips[name + " audio"], MovieSaveDataManager.GetInstance().GetMovieStatus(name));
			MovieSaveDataManager.GetInstance().SetMovie(name);
		}
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x00009E58 File Offset: 0x00008258
	protected void LoadAssetBundle()
	{
		string text = Application.dataPath + "/data/movie";
		this.assetBundle = AssetBundle.LoadFromFile(text);
		MovieTexture[] array = this.assetBundle.LoadAllAssets<MovieTexture>();
		AudioClip[] array2 = this.assetBundle.LoadAllAssets<AudioClip>();
		foreach (MovieTexture movieTexture in array)
		{
			this.materials.Add(movieTexture.name, movieTexture);
		}
		foreach (AudioClip audioClip in array2)
		{
			this.audioClips.Add(audioClip.name, audioClip);
		}
	}

	// Token: 0x040001C5 RID: 453
	private AssetBundle assetBundle;

	// Token: 0x040001C6 RID: 454
	private Dictionary<string, MovieTexture> materials = new Dictionary<string, MovieTexture>();

	// Token: 0x040001C7 RID: 455
	private Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

	// Token: 0x040001C8 RID: 456
	private MoviePlane plane;
}
