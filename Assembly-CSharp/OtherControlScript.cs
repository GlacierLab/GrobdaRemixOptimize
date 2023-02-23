using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B1 RID: 177
public class OtherControlScript : MonoBehaviour
{
	// Token: 0x060003E2 RID: 994 RVA: 0x0000D507 File Offset: 0x0000B907
	private void Start()
	{
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0000D509 File Offset: 0x0000B909
	private void Update()
	{
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x0000D50B File Offset: 0x0000B90B
	public void Init(float t)
	{
		this.slider.value = t;
		this.SliderChange(0f);
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x0000D524 File Offset: 0x0000B924
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.otherVolume = this.slider.value;
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0000D583 File Offset: 0x0000B983
	public void SetMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0000D5A0 File Offset: 0x0000B9A0
	public void PlayTestVoice()
	{
		Singleton<VoiceManager>.Instance.PlaySe("MY_217", false, 5);
	}

	// Token: 0x0400025F RID: 607
	public Slider slider;

	// Token: 0x04000260 RID: 608
	public Text Value;
}
