using System;
using UnityEngine;

// Token: 0x02000021 RID: 33
public class RotateAction : BaseAction
{
	// Token: 0x0600009F RID: 159 RVA: 0x00003B0C File Offset: 0x00001F0C
	public static RotateAction Create(RotateScript s)
	{
		RotateAction rotateAction = new RotateAction();
		rotateAction.init(s);
		rotateAction.InitScript(s);
		return rotateAction;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00003B2E File Offset: 0x00001F2E
	public void init(RotateScript s)
	{
		this.LastTime = (float)s.time / 1000f;
		this.angle = s.angle;
		this.v_angle = this.angle / this.LastTime;
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x00003B68 File Offset: 0x00001F68
	public override void Action()
	{
		Vector3 vector = this.v_angle * Time.deltaTime;
		this.layout.gameObject.transform.Rotate(vector);
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00003B9C File Offset: 0x00001F9C
	public override void FinishAction()
	{
		this.layout.gameObject.transform.eulerAngles = this.angle;
	}

	// Token: 0x0400004C RID: 76
	private Vector3 angle;

	// Token: 0x0400004D RID: 77
	private Vector3 v_angle;
}
