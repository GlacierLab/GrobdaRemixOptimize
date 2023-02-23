using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200009F RID: 159
public class BackGroundControlScript : MonoBehaviour
{
	// Token: 0x06000340 RID: 832 RVA: 0x0000BA57 File Offset: 0x00009E57
	private void Start()
	{
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0000BA59 File Offset: 0x00009E59
	private void Update()
	{
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0000BA5B File Offset: 0x00009E5B
	public void Init(float i)
	{
		this.slider.value = i;
		this.SliderChange(0f);
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0000BA74 File Offset: 0x00009E74
	public void SliderChange(float t)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.BgmVolume = this.slider.value;
		Singleton<BGMManager>.Instance.SetVolume(Singleton<GameConfigManager>.Instance.config.BgmVolume);
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0000BAEC File Offset: 0x00009EEC
	public void SetBgmMute()
	{
		Singleton<SystemSoundManager>.Instance.PlaySound2();
		this.slider.value = 0f;
		this.SliderChange(0f);
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0000BB13 File Offset: 0x00009F13
	public void PlayTest()
	{
		Singleton<BGMManager>.Instance.preActionForRestoreBgm();
		Singleton<BGMManager>.Instance.PlayTestBgm();
	}

	// Token: 0x0400021E RID: 542
	public Slider slider;

	// Token: 0x0400021F RID: 543
	public Text Value;
}
