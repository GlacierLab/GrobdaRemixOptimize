using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000BE RID: 190
public class TextAutoSpeed : MonoBehaviour
{
	// Token: 0x06000436 RID: 1078 RVA: 0x0000E466 File Offset: 0x0000C866
	private void Start()
	{
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0000E468 File Offset: 0x0000C868
	private void Update()
	{
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0000E46C File Offset: 0x0000C86C
	public void ValueChange(float s)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<GameConfigManager>.Instance.config.AutoTime = this.slider.value;
	}

	// Token: 0x04000284 RID: 644
	public Slider slider;

	// Token: 0x04000285 RID: 645
	public Text Value;
}
