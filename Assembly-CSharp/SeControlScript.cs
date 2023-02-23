using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000B8 RID: 184
public class SeControlScript : MonoBehaviour
{
	// Token: 0x06000411 RID: 1041 RVA: 0x0000DE66 File Offset: 0x0000C266
	private void Start()
	{
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x0000DE68 File Offset: 0x0000C268
	private void Update()
	{
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0000DE6C File Offset: 0x0000C26C
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.SEVolume = this.slider.value;
		Singleton<SEManager>.Instance.SetVolume(this.slider.value);
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0000DEE0 File Offset: 0x0000C2E0
	public void SetSeMute()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0000DF07 File Offset: 0x0000C307
	public void PlayTest()
	{
		Singleton<SEManager>.Instance.PlayTestBgm();
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0000DF13 File Offset: 0x0000C313
	public void Init(float i)
	{
		this.slider.value = i;
		this.SliderChange(0f);
	}

	// Token: 0x04000273 RID: 627
	public Slider slider;

	// Token: 0x04000274 RID: 628
	public Text Value;
}
