using System;

// Token: 0x02000033 RID: 51
public class WaitAction : BaseAction
{
	// Token: 0x060000EE RID: 238 RVA: 0x000045AF File Offset: 0x000029AF
	public WaitAction(float t)
	{
		this.time = t;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x000045C0 File Offset: 0x000029C0
	public static WaitAction Create(WaitScript ws)
	{
		WaitAction waitAction = new WaitAction(ws.time);
		waitAction.InitScript(ws);
		return waitAction;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000045E1 File Offset: 0x000029E1
	public override void Action()
	{
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x000045E3 File Offset: 0x000029E3
	public override void FinishAction()
	{
		Singleton<AVGManager>.Instance.SetWaitTimeStatus(this.time);
	}

	// Token: 0x04000068 RID: 104
	private float time;
}
