using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000C2 RID: 194
public class TextSpeedScript : MonoBehaviour
{
	// Token: 0x06000448 RID: 1096 RVA: 0x0000E7D4 File Offset: 0x0000CBD4
	private void Start()
	{
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0000E7D6 File Offset: 0x0000CBD6
	private void Update()
	{
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0000E7D8 File Offset: 0x0000CBD8
	public void ValueChange(float s)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		if ((int)this.slider.value == (int)this.slider.maxValue)
		{
			Singleton<GameConfigManager>.Instance.config.TextSpeed = 100000;
		}
		else
		{
			Singleton<GameConfigManager>.Instance.config.TextSpeed = (int)this.slider.value;
		}
	}

	// Token: 0x0400028F RID: 655
	public Slider slider;

	// Token: 0x04000290 RID: 656
	public Text Value;
}
