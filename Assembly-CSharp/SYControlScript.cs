using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B2 RID: 178
public class SYControlScript : MonoBehaviour
{
	// Token: 0x060003E9 RID: 1001 RVA: 0x0000D5BB File Offset: 0x0000B9BB
	private void Start()
	{
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0000D5BD File Offset: 0x0000B9BD
	private void Update()
	{
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0000D5BF File Offset: 0x0000B9BF
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0000D5D8 File Offset: 0x0000B9D8
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.syVolume = this.slider.value;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0000D637 File Offset: 0x0000BA37
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0000D654 File Offset: 0x0000BA54
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("K_35", false, 1);
	}

	// Token: 0x04000261 RID: 609
	public Slider slider;

	// Token: 0x04000262 RID: 610
	public Text Value;
}
