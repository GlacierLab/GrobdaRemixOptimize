using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AE RID: 174
public class MovieControlScript : MonoBehaviour
{
	// Token: 0x060003CC RID: 972 RVA: 0x0000D14F File Offset: 0x0000B54F
	private void Start()
	{
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0000D151 File Offset: 0x0000B551
	private void Update()
	{
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0000D154 File Offset: 0x0000B554
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.MovieVolume = this.slider.value;
		Singleton<MovieManager>.Instance.SetVolume(Singleton<GameConfigManager>.Instance.config.MovieVolume);
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0000D1CC File Offset: 0x0000B5CC
	public void SetMovieMute()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x0000D1F3 File Offset: 0x0000B5F3
	public void Init(float i)
	{
		this.slider.value = i;
		this.SliderChange(0f);
	}

	// Token: 0x04000257 RID: 599
	public Slider slider;

	// Token: 0x04000258 RID: 600
	public Text Value;
}
