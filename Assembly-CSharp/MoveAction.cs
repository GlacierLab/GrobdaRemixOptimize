using System;
using UnityEngine;

// Token: 0x0200001A RID: 26
public class MoveAction : BaseAction
{
	// Token: 0x06000080 RID: 128 RVA: 0x00003538 File Offset: 0x00001938
	public MoveAction(MoveScript script)
	{
		this.s = script;
		this.LastTime = (float)this.s.time / 1000f;
		this.vx = this.s.x / this.LastTime;
		this.vy = this.s.y / this.LastTime;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x0000359C File Offset: 0x0000199C
	public static MoveAction Create(MoveScript s)
	{
		MoveAction moveAction = new MoveAction(s);
		moveAction.InitScript(s);
		return moveAction;
	}

	// Token: 0x06000082 RID: 130 RVA: 0x000035B8 File Offset: 0x000019B8
	public override void FinishAction()
	{
		if (this.s.forward)
		{
			this.layout.transform.position = this.baseVector + new Vector3(this.s.x, this.s.y, 0f);
		}
		else
		{
			this.layout.transform.position = new Vector3(this.s.x, this.s.y, this.baseVector.z);
		}
		this.LiveTime = this.LastTime;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00003658 File Offset: 0x00001A58
	public override void Action()
	{
		float num = this.vx * Time.deltaTime;
		float num2 = this.vy * Time.deltaTime;
		this.layout.transform.position = this.layout.transform.position + new Vector3(num, num2, 0f);
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000036B0 File Offset: 0x00001AB0
	public override void Init()
	{
		base.Init();
		this.baseVector = this.layout.gameObject.transform.position;
		if (!this.s.forward)
		{
			float x = this.layout.gameObject.transform.position.x;
			float y = this.layout.gameObject.transform.position.y;
			this.vx = (this.s.x - x) / this.LastTime;
			this.vy = (this.s.y - y) / this.LastTime;
		}
	}

	// Token: 0x04000039 RID: 57
	private MoveScript s;

	// Token: 0x0400003A RID: 58
	private float vx;

	// Token: 0x0400003B RID: 59
	private float vy;

	// Token: 0x0400003C RID: 60
	private Vector3 baseVector;
}
