using System;

// Token: 0x0200002A RID: 42
public class StopBgmAction : BaseAction
{
	// Token: 0x060000C7 RID: 199 RVA: 0x00004084 File Offset: 0x00002484
	public StopBgmAction(StopBgmScript s)
	{
		this.script = s;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00004094 File Offset: 0x00002494
	public static StopBgmAction Create(StopBgmScript s)
	{
		StopBgmAction stopBgmAction = new StopBgmAction(s);
		stopBgmAction.InitScript(s);
		return stopBgmAction;
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x000040B0 File Offset: 0x000024B0
	public override void Action()
	{
	}

	// Token: 0x060000CA RID: 202 RVA: 0x000040B2 File Offset: 0x000024B2
	public override void FinishAction()
	{
		Singleton<BGMManager>.Instance.StopBgm();
	}

	// Token: 0x0400005A RID: 90
	private StopBgmScript script;
}
