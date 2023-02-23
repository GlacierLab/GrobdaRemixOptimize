using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C4 RID: 196
public class ZWControlScript : MonoBehaviour
{
	// Token: 0x0600044F RID: 1103 RVA: 0x0000E8CB File Offset: 0x0000CCCB
	private void Start()
	{
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0000E8CD File Offset: 0x0000CCCD
	private void Update()
	{
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x0000E8CF File Offset: 0x0000CCCF
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x0000E8E8 File Offset: 0x0000CCE8
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.zwVolume = this.slider.value;
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x0000E947 File Offset: 0x0000CD47
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x0000E964 File Offset: 0x0000CD64
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("K_136", false, 5);
	}

	// Token: 0x04000293 RID: 659
	public Slider slider;

	// Token: 0x04000294 RID: 660
	public Text Value;
}
