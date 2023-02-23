using System;
using UnityEngine;

// Token: 0x02000026 RID: 38
public class SetPositionAction : BaseAction
{
	// Token: 0x060000B5 RID: 181 RVA: 0x00003E60 File Offset: 0x00002260
	public SetPositionAction(float _x, float _y)
	{
		this.x = _x;
		this.y = _y;
		this.LastTime = 0f;
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x00003E84 File Offset: 0x00002284
	public static SetPositionAction Create(SetPostionScript p)
	{
		SetPositionAction setPositionAction = new SetPositionAction(p.x, p.y);
		setPositionAction.InitScript(p);
		return setPositionAction;
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x00003EAC File Offset: 0x000022AC
	public override void FinishAction()
	{
		this.layout.transform.position = new Vector3(this.x, this.y, this.layout.transform.position.z);
		this.LiveTime = this.LastTime;
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00003EFE File Offset: 0x000022FE
	public override void Action()
	{
	}

	// Token: 0x04000054 RID: 84
	public float x;

	// Token: 0x04000055 RID: 85
	public float y;
}
