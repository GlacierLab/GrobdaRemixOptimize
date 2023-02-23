using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class FadeInAction : BaseAction
{
	// Token: 0x06000046 RID: 70 RVA: 0x00002B5D File Offset: 0x00000F5D
	public FadeInAction(int t, Layout l, float s = 0f, float e = 1f)
	{
		this.StartAlpha = s;
		this.EndAlpha = e;
		this.LastTime = (float)t / 1000f;
		this.layout = l;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002B8C File Offset: 0x00000F8C
	public static FadeInAction Create(FadeInScript s)
	{
		FadeInAction fadeInAction = new FadeInAction(s.LastTime, null, s.StartAplha, s.EndAplha);
		fadeInAction.InitScript(s);
		return fadeInAction;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002BBA File Offset: 0x00000FBA
	public override void FinishAction()
	{
		this.layout.SetAplha(this.EndAlpha);
		this.LiveTime = this.LastTime;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00002BDC File Offset: 0x00000FDC
	public override void Action()
	{
		float num = (this.StartAlpha - this.EndAlpha) / this.LastTime * Time.deltaTime;
		this.layout.SetColor(this.layout.GetColor() - new Color(0f, 0f, 0f, num));
	}

	// Token: 0x04000022 RID: 34
	public float StartAlpha;

	// Token: 0x04000023 RID: 35
	public float EndAlpha;
}
