using System;
using UnityEngine;

// Token: 0x02000023 RID: 35
public class SetAlphaAction : BaseAction
{
	// Token: 0x060000A9 RID: 169 RVA: 0x00003C2A File Offset: 0x0000202A
	public SetAlphaAction(Color _x)
	{
		this.c = _x;
		this.LastTime = 0f;
	}

	// Token: 0x060000AA RID: 170 RVA: 0x00003C44 File Offset: 0x00002044
	public static SetAlphaAction Create(SetAlphaScript p)
	{
		SetAlphaAction setAlphaAction = new SetAlphaAction(p.c);
		setAlphaAction.InitScript(p);
		return setAlphaAction;
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00003C65 File Offset: 0x00002065
	public override void FinishAction()
	{
		this.layout.SetColor(this.c);
		this.LiveTime = this.LastTime;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00003C84 File Offset: 0x00002084
	public override void Action()
	{
	}

	// Token: 0x0400004F RID: 79
	public Color c;

	// Token: 0x04000050 RID: 80
	public Color vc;
}
