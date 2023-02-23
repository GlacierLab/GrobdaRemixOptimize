using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000BD RID: 189
public class SystemSoundControlScript : MonoBehaviour
{
	// Token: 0x0600042F RID: 1071 RVA: 0x0000E3A1 File Offset: 0x0000C7A1
	private void Start()
	{
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0000E3A3 File Offset: 0x0000C7A3
	private void Update()
	{
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0000E3A8 File Offset: 0x0000C7A8
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<SystemSoundManager>.Instance.SetVolume(this.slider.value);
		Singleton<GameConfigManager>.Instance.config.SystemVolume = this.slider.value;
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0000E41C File Offset: 0x0000C81C
	public void SetSystemMute()
	{
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0000E439 File Offset: 0x0000C839
	public void PlayTest()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound1();
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0000E445 File Offset: 0x0000C845
	public void Init(float i)
	{
		this.slider.value = i;
		this.SliderChange(0f);
	}

	// Token: 0x04000282 RID: 642
	public Slider slider;

	// Token: 0x04000283 RID: 643
	public Text Value;
}
