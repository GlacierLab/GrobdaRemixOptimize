using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class CreateAction : BaseAction
{
	// Token: 0x06000031 RID: 49 RVA: 0x00002995 File Offset: 0x00000D95
	public CreateAction(string p)
	{
		this.name = p;
		this.LastTime = 0f;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x000029B0 File Offset: 0x00000DB0
	public static CreateAction Create(CreateScript p)
	{
		CreateAction createAction = new CreateAction(p.name);
		createAction.InitScript(p);
		return createAction;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x000029D4 File Offset: 0x00000DD4
	public override void FinishAction()
	{
		GameObject gameObject = Resources.Load<GameObject>("prefab/" + this.name);
		if (gameObject != null)
		{
			UnityEngine.Object.Instantiate<GameObject>(gameObject);
		}
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002A0A File Offset: 0x00000E0A
	public override void Action()
	{
	}

	// Token: 0x0400001D RID: 29
	public string name;
}
