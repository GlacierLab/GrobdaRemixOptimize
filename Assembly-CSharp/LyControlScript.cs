using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AC RID: 172
public class LyControlScript : MonoBehaviour
{
	// Token: 0x060003B2 RID: 946 RVA: 0x0000CBF2 File Offset: 0x0000AFF2
	private void Start()
	{
	}

	// Token: 0x060003B3 RID: 947 RVA: 0x0000CBF4 File Offset: 0x0000AFF4
	private void Update()
	{
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x0000CBF6 File Offset: 0x0000AFF6
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0000CC10 File Offset: 0x0000B010
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.lyVolume = this.slider.value;
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0000CC6F File Offset: 0x0000B06F
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0000CC8C File Offset: 0x0000B08C
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("K_50", false, 1);
	}

	// Token: 0x04000248 RID: 584
	public Slider slider;

	// Token: 0x04000249 RID: 585
	public Text Value;
}
