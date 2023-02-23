using System;
using UnityEngine;

// Token: 0x02000010 RID: 16
internal class FadeOutAction : BaseAction
{
	// Token: 0x0600004A RID: 74 RVA: 0x00002C34 File Offset: 0x00001034
	public FadeOutAction(int t, Layout l, float s = 1f, float e = 0f)
	{
		this.StartAlpha = s;
		this.EndAlpha = e;
		this.LastTime = (float)t / 1000f;
		this.layout = l;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00002C60 File Offset: 0x00001060
	public static FadeOutAction Create(FadeOutScript s)
	{
		FadeOutAction fadeOutAction = new FadeOutAction(s.LastTime, null, s.StartAplha, s.EndAplha);
		fadeOutAction.InitScript(s);
		return fadeOutAction;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00002C8E File Offset: 0x0000108E
	public override void FinishAction()
	{
		this.layout.SetAplha(0f);
		this.LiveTime = this.LastTime;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002CAC File Offset: 0x000010AC
	public override void Action()
	{
		float num = (this.StartAlpha - this.EndAlpha) / this.LastTime * Time.deltaTime;
		this.layout.SetColor(this.layout.GetColor() - new Color(0f, 0f, 0f, num));
	}

	// Token: 0x04000024 RID: 36
	public float StartAlpha;

	// Token: 0x04000025 RID: 37
	public float EndAlpha;
}
