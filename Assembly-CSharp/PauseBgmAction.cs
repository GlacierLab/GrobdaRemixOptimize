using System;

// Token: 0x0200002B RID: 43
public class PauseBgmAction : BaseAction
{
	// Token: 0x060000CB RID: 203 RVA: 0x000040BE File Offset: 0x000024BE
	public PauseBgmAction(PauseBgmScript s)
	{
		this.script = s;
	}

	// Token: 0x060000CC RID: 204 RVA: 0x000040D0 File Offset: 0x000024D0
	public static PauseBgmAction Create(PauseBgmScript s)
	{
		PauseBgmAction pauseBgmAction = new PauseBgmAction(s);
		pauseBgmAction.InitScript(s);
		return pauseBgmAction;
	}

	// Token: 0x060000CD RID: 205 RVA: 0x000040EC File Offset: 0x000024EC
	public override void Action()
	{
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000040EE File Offset: 0x000024EE
	public override void FinishAction()
	{
		Singleton<BGMManager>.Instance.PauseBgm();
	}

	// Token: 0x0400005B RID: 91
	private PauseBgmScript script;
}
