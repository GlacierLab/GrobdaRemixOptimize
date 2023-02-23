using System;

// Token: 0x0200002D RID: 45
public class StopSeAction : BaseAction
{
	// Token: 0x060000D4 RID: 212 RVA: 0x00004140 File Offset: 0x00002540
	public static StopSeAction Create(StopBeScript s)
	{
		StopSeAction stopSeAction = new StopSeAction();
		stopSeAction.InitScript(s);
		return stopSeAction;
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x0000415B File Offset: 0x0000255B
	public override void Action()
	{
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x0000415D File Offset: 0x0000255D
	public override void FinishAction()
	{
		Singleton<SEManager>.Instance.StopSE();
	}
}
