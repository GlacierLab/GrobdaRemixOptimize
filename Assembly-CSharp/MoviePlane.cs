using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000078 RID: 120
public class MoviePlane : MonoBehaviour
{
	// Token: 0x0600022F RID: 559 RVA: 0x00007A24 File Offset: 0x00005E24
	public void SetMovie(MovieTexture t, AudioClip clip, bool skip = false)
	{
		Singleton<UIManager>.Instance.HideAllUi();
		base.gameObject.SetActive(true);
		Application.targetFrameRate = 30;
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.Movie);
		this.movie_source.clip = clip;
		this.movie_source.volume = Singleton<GameConfigManager>.Instance.config.MovieVolume;
		base.GetComponent<Renderer>().material.mainTexture = t;
		this.movie_texture = t;
		this.movie_texture = (MovieTexture)base.GetComponent<Renderer>().material.mainTexture;
		this.movie_texture.Play();
		this.movie_source.Play();
		this.time = Time.time;
		base.StartCoroutine(this.GetEnd());
	}

	// Token: 0x06000230 RID: 560 RVA: 0x00007AE0 File Offset: 0x00005EE0
	private IEnumerator GetEnd()
	{
		while (this.movie_texture.isPlaying)
		{
			if (Input.GetMouseButtonUp(0) && Time.time - this.time > 1f)
			{
				break;
			}
			yield return 0;
		}
		this.FinishMovie();
		yield break;
	}

	// Token: 0x06000231 RID: 561 RVA: 0x00007AFC File Offset: 0x00005EFC
	private void FinishMovie()
	{
		Singleton<AVGManager>.Instance.SetAvgStatus(AVGStatus.WAIT);
		base.gameObject.SetActive(false);
		Application.targetFrameRate = 60;
		this.movie_texture.Stop();
		this.movie_source.Stop();
		if (this.restoreUI)
		{
			Singleton<UIManager>.Instance.RestoreUi();
		}
	}

	// Token: 0x06000232 RID: 562 RVA: 0x00007B52 File Offset: 0x00005F52
	public void SetVolume(float v)
	{
		this.movie_source.volume = v;
	}

	// Token: 0x04000180 RID: 384
	public AudioSource movie_source;

	// Token: 0x04000181 RID: 385
	public MovieTexture movie_texture;

	// Token: 0x04000182 RID: 386
	public bool restoreUI;

	// Token: 0x04000183 RID: 387
	[SerializeField]
	private bool canSkip;

	// Token: 0x04000184 RID: 388
	private float time;
}
