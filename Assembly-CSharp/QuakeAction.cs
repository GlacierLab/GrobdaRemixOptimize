using System;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class QuakeAction : BaseAction
{
	// Token: 0x06000091 RID: 145 RVA: 0x0000384C File Offset: 0x00001C4C
	public QuakeAction(QuakeScript s)
	{
		base.InitScript(s);
		this.LastTime = s.LastTime;
		this.hmax = s.h;
		this.vmax = s.w;
		this.interval = s.interval;
		this.MainCamera = GameObject.Find("Main Camera");
		this.vx = (this.vy = 0f);
	}

	// Token: 0x06000092 RID: 146 RVA: 0x000038BC File Offset: 0x00001CBC
	public override void FinishAction()
	{
		Vector3 position = this.MainCamera.transform.position;
		position.x = 6.4f;
		position.y = -4f;
		this.MainCamera.transform.position = position;
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00003904 File Offset: 0x00001D04
	public override void Action()
	{
		Vector3 position = this.MainCamera.transform.position;
		if (this.temp == this.interval)
		{
			this.vx = this.hmax * UnityEngine.Random.Range(-1f, 1f);
			this.vy = this.vmax * UnityEngine.Random.Range(-1f, 1f);
			this.temp = 0;
			position.x += this.vx;
			position.y += this.vy;
			this.MainCamera.transform.position = position;
		}
		else
		{
			this.temp++;
		}
	}

	// Token: 0x04000041 RID: 65
	public float hmax;

	// Token: 0x04000042 RID: 66
	public float vmax;

	// Token: 0x04000043 RID: 67
	public int interval;

	// Token: 0x04000044 RID: 68
	public int temp;

	// Token: 0x04000045 RID: 69
	private GameObject MainCamera;

	// Token: 0x04000046 RID: 70
	private float vx;

	// Token: 0x04000047 RID: 71
	private float vy;
}
