using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000AF RID: 175
public class NewHistoryItemScript : MonoBehaviour
{
	// Token: 0x060003D2 RID: 978 RVA: 0x0000D214 File Offset: 0x0000B614
	public void Init(TextGroupScript s)
	{
		this.script = s;
		this.nameText.text = s.nameScript.text;
		this.content.text = s.conTextScript.text;
		if (this.nameText.text == null || this.nameText.text == "琴语" || this.nameText.text == string.Empty || this.nameText.text == "青年")
		{
			this.icon.gameObject.SetActive(false);
		}
		else
		{
			this.icon.gameObject.SetActive(true);
		}
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0000D2D9 File Offset: 0x0000B6D9
	public void ReplaySound()
	{
		if (this.script != null)
		{
			this.script.voiceScript.CreateAction().FinishAction();
		}
	}

	// Token: 0x04000259 RID: 601
	public TextGroupScript script;

	// Token: 0x0400025A RID: 602
	public Text nameText;

	// Token: 0x0400025B RID: 603
	public Image icon;

	// Token: 0x0400025C RID: 604
	public Text content;
}
