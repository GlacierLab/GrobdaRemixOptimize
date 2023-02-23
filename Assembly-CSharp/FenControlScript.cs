using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A6 RID: 166
public class FenControlScript : MonoBehaviour
{
	// Token: 0x06000385 RID: 901 RVA: 0x0000C481 File Offset: 0x0000A881
	private void Start()
	{
	}

	// Token: 0x06000386 RID: 902 RVA: 0x0000C483 File Offset: 0x0000A883
	private void Update()
	{
	}

	// Token: 0x06000387 RID: 903 RVA: 0x0000C485 File Offset: 0x0000A885
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0000C4A0 File Offset: 0x0000A8A0
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.fenVolume = this.slider.value;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x0000C4FF File Offset: 0x0000A8FF
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x0600038A RID: 906 RVA: 0x0000C51C File Offset: 0x0000A91C
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("K_412", false, 3);
	}

	// Token: 0x04000234 RID: 564
	public Slider slider;

	// Token: 0x04000235 RID: 565
	public Text Value;
}
