using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A0 RID: 160
public class BiaoControlScript : MonoBehaviour
{
	// Token: 0x06000347 RID: 839 RVA: 0x0000BB31 File Offset: 0x00009F31
	private void Start()
	{
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0000BB33 File Offset: 0x00009F33
	private void Update()
	{
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0000BB35 File Offset: 0x00009F35
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0000BB50 File Offset: 0x00009F50
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.zhangVolume = this.slider.value;
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0000BBAF File Offset: 0x00009FAF
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x0600034C RID: 844 RVA: 0x0000BBCC File Offset: 0x00009FCC
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("K_156", false, 4);
	}

	// Token: 0x04000220 RID: 544
	public Slider slider;

	// Token: 0x04000221 RID: 545
	public Text Value;
}
