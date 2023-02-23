using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class HistoryItemScript : MonoBehaviour
{
	// Token: 0x060003AF RID: 943 RVA: 0x0000CBC4 File Offset: 0x0000AFC4
	public void Init(VoiceScript s)
	{
		this.script = s;
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x0000CBCD File Offset: 0x0000AFCD
	public void ReplaySound()
	{
		if (this.script != null)
		{
			this.script.CreateAction().FinishAction();
		}
	}

	// Token: 0x04000247 RID: 583
	public VoiceScript script;
}
