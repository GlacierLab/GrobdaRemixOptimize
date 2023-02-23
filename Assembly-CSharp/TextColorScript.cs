using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000BF RID: 191
public class TextColorScript : MonoBehaviour
{
	// Token: 0x0600043A RID: 1082 RVA: 0x0000E4D3 File Offset: 0x0000C8D3
	private void Start()
	{
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0000E4D5 File Offset: 0x0000C8D5
	private void Update()
	{
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0000E4D8 File Offset: 0x0000C8D8
	public void ValueChange(float s)
	{
		this.Value.text = (int)(this.slider.value * 100f / this.slider.maxValue) + "%";
		Singleton<UIManager>.Instance.GetUi("text").GetComponent<GameButtonClick>().ChangeAlpha(this.slider.value);
	}

	// Token: 0x04000286 RID: 646
	public Slider slider;

	// Token: 0x04000287 RID: 647
	public Text Value;
}
