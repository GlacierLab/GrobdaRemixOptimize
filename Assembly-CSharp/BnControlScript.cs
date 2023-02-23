using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A1 RID: 161
public class BnControlScript : MonoBehaviour
{
	// Token: 0x0600034E RID: 846 RVA: 0x0000BBE7 File Offset: 0x00009FE7
	private void Start()
	{
	}

	// Token: 0x0600034F RID: 847 RVA: 0x0000BBE9 File Offset: 0x00009FE9
	private void Update()
	{
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0000BBEB File Offset: 0x00009FEB
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0000BC04 File Offset: 0x0000A004
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.bnVolume = this.slider.value;
	}

	// Token: 0x06000352 RID: 850 RVA: 0x0000BC63 File Offset: 0x0000A063
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0000BC80 File Offset: 0x0000A080
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("K_253", false, 2);
	}

	// Token: 0x04000222 RID: 546
	public Slider slider;

	// Token: 0x04000223 RID: 547
	public Text Value;
}
