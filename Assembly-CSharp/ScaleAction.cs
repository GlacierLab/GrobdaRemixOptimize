using System;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class ScaleAction : BaseAction
{
	// Token: 0x06000099 RID: 153 RVA: 0x00003A14 File Offset: 0x00001E14
	public static ScaleAction Create(ScaleScript s)
	{
		ScaleAction scaleAction = new ScaleAction();
		scaleAction.init(s);
		scaleAction.InitScript(s);
		return scaleAction;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00003A36 File Offset: 0x00001E36
	public void init(ScaleScript s)
	{
		this.LastTime = (float)s.time / 1000f;
		this.angle = s.s;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x00003A58 File Offset: 0x00001E58
	public override void Init()
	{
		base.Init();
		this.baseVector = this.layout.gameObject.transform.localScale;
		this.v_angle = (this.angle - this.baseVector) / this.LastTime;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00003AA8 File Offset: 0x00001EA8
	public override void Action()
	{
		Vector3 vector = this.v_angle * Time.deltaTime;
		this.layout.gameObject.transform.localScale += vector;
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00003AE7 File Offset: 0x00001EE7
	public override void FinishAction()
	{
		this.layout.gameObject.transform.localScale = this.angle;
	}

	// Token: 0x04000049 RID: 73
	private Vector3 angle;

	// Token: 0x0400004A RID: 74
	private Vector3 v_angle;

	// Token: 0x0400004B RID: 75
	private Vector3 baseVector;
}
